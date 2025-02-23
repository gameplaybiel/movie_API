using movie_API.Data;
using movie_API.Models;
using movie_API;
using movie_API.Services;
using System.Linq;

namespace movie_API.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        
        public User AddUser(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                throw new InvalidOperationException("Email already in use.");
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User? GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }


        public User? GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User UpdateUser(int id, User updatedUser)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            existingUser.PasswordHash = updatedUser.PasswordHash;
            _context.SaveChanges();

            return existingUser;
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
