using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RollOff.Models.DTO;
using RollOff.Services;
using System.Threading.Tasks;

namespace RollOff.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Authenticate(string username, string password)
        {
            var result = await _userService.AuthenticateUser(username, password);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDetailsDto userDetailsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _userService.SaveUser(userDetailsDto);
            return Ok(result);
        }
    }
}
