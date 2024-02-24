using CleanProj.API.ExternalServices;
using CleanProj.Application.Services.UserProfileServices;
using CleanProj.Domain.Entities.DTOs;
using CleanProj.Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanProj.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IUserProfileService _userService;

        public UserController(IUserProfileService userProfileService, IWebHostEnvironment env)
        {
            _userService = userProfileService;
            _env = env;

        }
        [HttpGet]
        public async Task<List<UserProfile>> GetAllUsers()
        {
            return _userService.GetAllUserProfileAsync().Result;
        }

        [HttpGet]
        public async Task<UserProfile> GetUserById(int id)
        {
            return _userService.GetByIdUserProfileAsync(id).Result;
        }

        [HttpGet]
        public async Task<IActionResult> GetPictureById(int id)
        {
            return File(await _userService.GetPictureById(id),"application/elyor","rasm.png");
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateUser([FromForm] UserProfileDTO userProfileDTO, IFormFile picture)
        {
            UserProfileExternalService service = new UserProfileExternalService(_env);

            string picturePath = await service.AddPictureAndGetPath(picture);

            var result = _userService.CreateUserProfileAsync(userProfileDTO, picturePath).Result;
            return Ok(result);
        }

        [HttpPut]
        public async Task<string> UpdatePictureById(int id,IFormFile picture)
        {
            UserProfileExternalService service = new UserProfileExternalService(_env);
            string picturePath = await service.AddPictureAndGetPath(picture);
            return _userService.UpdatePictureByIdAsync(id, picturePath).Result;
        }

        [HttpPut]
        public async Task<UserProfile> UpdateUserProfileByIdAsync(int id,UserProfileDTO model)
        {
            return _userService.UpdateUserProfileAsync(id,model).Result;
        }

        [HttpDelete]
        public async Task<bool> DeleteUserProfileByIdAsync(int id)
        {
            return _userService.DeleteUserProfileAsync(id).Result;
        }
    }
}
