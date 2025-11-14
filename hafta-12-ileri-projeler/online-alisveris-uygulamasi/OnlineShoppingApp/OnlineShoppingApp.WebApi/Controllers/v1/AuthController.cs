using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingApp.Business.Operations.User;
using OnlineShoppingApp.Business.Operations.User.Dtos;
using OnlineShoppingApp.WebApi.Jwt;
using OnlineShoppingApp.WebApi.Models;
using System.Reflection.Metadata.Ecma335;
using System.Runtime;

namespace OnlineShoppingApp.WebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (request.Password != request.ConfirmPassword)
            {
                return BadRequest(new { message = "Şifreler eşleşmiyor." });
            }

            var AdduserDto = new AddUserDto
            {
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate
            };

            var result = await _userService.AddUserAsync(AdduserDto);
            if (!result.IsSuccess)
            {
               
                return BadRequest(new { message = result.Message });
            }


            return Ok();

        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } //todo action filter

            var result = await _userService.LoginUserAsync(new LoginUserDto
            {
                Email = request.Email,
                Password = request.Password
            });
            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Message });
            }

            var user = result.Data;

            var configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            

            var token = JwtHelper.GenerateJwtToken(new JwtDto 
            {
               Id = user.Id,
               Audience = configuration["Jwt:Audience"],
                Issuer = configuration["Jwt:Issuer"],
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserType = user.UserType,
                SecretKey = configuration["Jwt:SecretKey"],
                ExpireMinutes = int.Parse(configuration["Jwt:ExpireMinutes"])
            });

            return Ok( new LoginResponse {
               Message = "Giriş başarılı.",
                Token = token,
            });
        
        }

      

        } // AuthController class done
}
