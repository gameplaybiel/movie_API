using Microsoft.AspNetCore.Mvc;
using movie_API.Data;
using movie_API.Models;
using movie_API.Services;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace movie_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly AuthService _authService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthController(AppDbContext context, AuthService authService, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _authService = authService;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginData)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == loginData.Email);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginData.PasswordHash);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return Unauthorized("Invalid credentials");
            }

            var token = _authService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }
    }
}
