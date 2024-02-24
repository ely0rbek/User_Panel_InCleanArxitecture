using CleanProj.Domain.Entities.DTOs;
using CleanProj.Domain.Entities.Models;
using CleanProj.Infrastructure.Repositories;

namespace CleanProj.Application.Services.UserProfileServices
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserRepository _userRepository;

        public UserProfileService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> CreateUserProfileAsync(UserProfileDTO userDTO, string picturePath)
        {

            var model = new UserProfile()
            {
                FullName = userDTO.FullName,
                Phone = userDTO.Phone,
                UserRole = userDTO.UserRole,
                Login = userDTO.Login,
                Password = userDTO.Password,
                PicturePath = picturePath,
            };

            var result = _userRepository.CreateUserProfileAsync(model);
            return result.Result;
        }
        public Task<List<UserProfile>> GetAllUserProfileAsync()
        {
            return _userRepository.GetAllUserProfileAsync();
        }

        public Task<UserProfile> GetByIdUserProfileAsync(int id)
        {
            return _userRepository.GetByIdUserProfileAsync(id);
        }

        public Task<UserProfile> UpdateUserProfileAsync(int id, UserProfileDTO modelDTO)
        {
            return _userRepository.UpdateUserProfileAsync(id, modelDTO);
        }
        public Task<bool> DeleteUserProfileAsync(int id)
        {
            return _userRepository.DeleteUserProfileAsync(id);
        }

        public Task<byte[]> GetPictureById(int id)
        {
            return _userRepository.GetPictureById(id);
        }

        public Task<string> UpdatePictureByIdAsync(int id, string picturePath)
        {
            return _userRepository.UpdatePictureByIdAsync(id, picturePath);
        }
    }
}
