using CleanProj.Domain.Entities.DTOs;
using CleanProj.Domain.Entities.Models;

namespace CleanProj.Application.Services.UserProfileServices
{
    public interface IUserProfileService
    {
        public Task<string> CreateUserProfileAsync(UserProfileDTO userDTO, string picturePath);
        public Task<List<UserProfile>> GetAllUserProfileAsync();
        public Task<UserProfile> GetByIdUserProfileAsync(int id);
        public Task<bool> DeleteUserProfileAsync(int id);
        public Task<UserProfile> UpdateUserProfileAsync(int id, UserProfileDTO modelDTO);

        public Task<byte[]> GetPictureById(int id);

        public Task<string> UpdatePictureByIdAsync(int id, string picturePath);
    }
}
