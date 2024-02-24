using CleanProj.Domain.Entities.DTOs;
using CleanProj.Domain.Entities.Models;
using CleanProj.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CleanProj.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;


        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateUserProfileAsync(UserProfile userProfile)
        {
            _context.AddAsync(userProfile);
            await _context.SaveChangesAsync();
            return "Yaratildi";
        }

        public async Task<List<UserProfile>> GetAllUserProfileAsync()
        {
            var allUsers = _context.Users.ToListAsync();
            return allUsers.Result;
        }
        public async Task<UserProfile> GetByIdUserProfileAsync(int id)
        {
            var person = _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (person != null)
            {
                return person.Result;
            }
            return null;
        }

        public async Task<UserProfile> UpdateUserProfileAsync(int id, UserProfileDTO modelDTO)
        {
            var person = _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (person != null)
            {
                person.Result.FullName = modelDTO.FullName;
                person.Result.Phone = modelDTO.Phone;
                person.Result.UserRole = modelDTO.UserRole;
                person.Result.Login = modelDTO.Login;
                person.Result.Password = modelDTO.Password;

                await _context.SaveChangesAsync();
                return person.Result;
            }
            return null;
        }

        public async Task<bool> DeleteUserProfileAsync(int id)
        {
            var person = _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (person != null)
            {
                _context.Users.Remove(person.Result);
                File.Delete(person.Result.PicturePath);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<byte[]> GetPictureById(int id)
        {
            var person = _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (!File.Exists(person.Result.PicturePath))
            {
                return null;
            }
            return await File.ReadAllBytesAsync(person.Result.PicturePath);
        }

        public async Task<string> UpdatePictureByIdAsync(int id, string picturePath)
        {
            var person = _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            var oldPicturePath = person.Result.PicturePath;
            if (person.Id != null)
            {
                person.Result.PicturePath = picturePath;
                await _context.SaveChangesAsync();
                File.Delete(oldPicturePath);
                return "o'zgartirildi";
            }
            return null;
        }
    }
}
