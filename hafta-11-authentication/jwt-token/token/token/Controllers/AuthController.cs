using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using token.Data;
using token.Entities;

namespace token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TokenDbContext _context;

        public AuthController(TokenDbContext context ,IConfiguration configuration )
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]

        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                     Email = user.Email,
                        password = user.password

                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return Ok("User registered successfully");
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("login")]
      
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var token = Helper.GenerateJwtToken(user.Email, _configuration["Jwt:Key"], _configuration["Jwt:Issuer"], _configuration["Jwt:Audience"]);
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == user.Email && u.password == user.password);

                if (existingUser != null)
                {
                    return Ok( new {message = "login succesful", token = token});
                }

                return Unauthorized("Invalid email or password");
            }

            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpGet("secret-data")]
        public IActionResult GetSecretData()
        {
            var userEmail = User.Identity?.Name; // Token'dan gelen kullanıcı bilgisi
            return Ok($"Bu veri sadece token ile erişilebilen gizli veridir. Giriş yapan: {userEmail}");
        }

    }
}
