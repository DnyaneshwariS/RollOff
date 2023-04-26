using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RollOff.Models.DTO;
using RollOff.Models.Response;

namespace RollOff.Services
{
    public interface IUserService
    {
        Task<bool> SaveUser(UserDetailsDto userMasterDto);
        Task<UserResponse> AuthenticateUser(string username, string password);
    }
}
