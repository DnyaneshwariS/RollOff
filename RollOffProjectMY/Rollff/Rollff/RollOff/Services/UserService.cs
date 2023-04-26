using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RollOff.Models;
using RollOff.Models.Domain;
using RollOff.Models.DTO;
using RollOff.Models.Response;
using RollOff.Repository;

namespace RollOff.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        public UserService(IUserRepository userRepo, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = userRepo;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<bool> SaveUser(UserDetailsDto userMasterDto)
        {
            var userMaster = _mapper.Map<UserDetails>(userMasterDto);
            userMaster.Salt = GenerateSalt();
            userMaster.Password = ComputeHash(Encoding.UTF8.GetBytes(userMaster.Password), Encoding.UTF8.GetBytes(userMaster.Salt));
            return await _userRepository.SaveUser(userMaster).ConfigureAwait(false);
        }

        public async Task<UserResponse> AuthenticateUser(string username, string password)
        {
            var userDetails = await _userRepository.AuthenticateUser(username);

            if (userDetails == null)
                throw new UnauthorizedAccessException("Invalid Login Credentials");

            string logingPassword = ComputeHash(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(userDetails.Salt));

            if (userDetails.Password != logingPassword)
                throw new UnauthorizedAccessException("Invalid Login Credentials");

            // authentication successful so generate jwt token
            var claims = new List<Claim>() {
                        new Claim(ClaimTypes.Name, userDetails.Email),
                        new Claim(ClaimTypes.Role, userDetails.Role)};

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = _configuration.GetSection("JsonWebTokenKeys").GetSection("IssuerSigningKey").Value;
            var issuer = _configuration.GetSection("JsonWebTokenKeys").GetSection("ValidIssuer").Value;
            var audience = _configuration.GetSection("JsonWebTokenKeys").GetSection("ValidAudience").Value;
            var timeSpan = TimeSpan.FromMinutes(10);

            var token = JwtHelper.GetJwtToken(userDetails.Email, key, issuer, audience, timeSpan, claims.ToArray());

            return new UserResponse()
            {
                Name = userDetails.Name,
                Id = userDetails.Id,
                Email = userDetails.Email,
                Role = userDetails.Role,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ValidTo = token.ValidTo
            }; ;
        }

        private string GenerateSalt()
        {
            var bytes = new byte[128 / 8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
        private string ComputeHash(byte[] bytesToHash, byte[] salt)
        {
            var byteResult = new Rfc2898DeriveBytes(bytesToHash, salt, 10000);
            return Convert.ToBase64String(byteResult.GetBytes(24));
        }
    }
}
