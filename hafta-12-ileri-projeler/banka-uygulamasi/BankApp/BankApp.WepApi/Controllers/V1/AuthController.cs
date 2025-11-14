using Asp.Versioning;
using Azure;
using BankApp.Business.Operations.TwoFactor;
using BankApp.Business.Operations.User;
using BankApp.Business.Operations.User.Dtos;
using BankApp.Data.Entities;
using BankApp.Data.Enums;
using BankApp.WepApi.Helpers;
using BankApp.WepApi.Jwt;
using BankApp.WepApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BankApp.WepApi.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserLoggerHelper _userLoggerHelper;
        private readonly ITwoFactorService _twoFactorService;
        public AuthController(IUserService userService, UserLoggerHelper userLoggerHelper, ITwoFactorService twoFactorService)
        {
            _userService = userService;
            _userLoggerHelper = userLoggerHelper;
            _twoFactorService = twoFactorService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest request) // method beginning
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerDto = new RegisterDto
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Password = request.Password,
                BirthDate = request.BirthDate
            };
            var result = await _userService.RegisterAsync(registerDto);
            if (!result.IsSuccess)
            {
                return BadRequest(new { message = result.Message });
            }

            return CreatedAtAction(nameof(GetUserById), new { id = result.Data.Id }, result.Data);

        }

        [HttpPost]
        [Route("login")]
       
        public async Task<IActionResult> Login(LoginRequest request) // method beginning
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDto = new LoginRequestDto()
            {
                Email = request.Email,
                Password = request.Password,
            };

            var user = await _userService.LoginUserAsync(userDto);

            if (!user.IsSuccess)
            {
                return BadRequest(user.Message);
            }

            if (user.Data.IsTwoFactorEnable)
            {
                var otpResult = await _twoFactorService.GenerateOtpAsync(user.Data.Id, "Email"); // veya SMS

                if (!otpResult.IsSuccess)
                    return BadRequest(otpResult.Message);

                return Ok(new
                {
                    message = "İki faktörlü doğrulama aktif. OTP kodunu girin.",
                    twoFactorRequired = true
                });
            }
            await _userLoggerHelper.LogAsync(user.Data.Id, UserActionType.Login);

            var configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var token = JwtHelper.GenerateJwtToken(new JwtDto()
            {
                FirstName = user.Data.FirstName,
                LastName = user.Data.LastName,
                Email = user.Data.Email,
                Id = user.Data.Id,
                UserType = user.Data.UserType,
                Audience = configuration["Jwt:Audience"],
                Issuer = configuration["Jwt:Issuer"],
                SecretKey = configuration["Jwt:SecretKey"],
                ExpireMinutes = int.Parse(configuration["Jwt:ExpireMinutes"])
            });

           


            return Ok(new LoginResponse()
            {
                Message = "giriş başarılı",
                Token = token,
            });
        }

        [HttpPost]
        [Route("logout")]

        public async Task<IActionResult> Logout()   // method beginning
        {
            var userId = User.FindFirstValue("id");
            if (int.TryParse(userId, out int id))
            {
                await _userLoggerHelper.LogAsync(id, UserActionType.Logout);
            }
            // Token is deleted on the client side. There is no token management on the server.
            return Ok(new { message = "çıkış yapıldı" });
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetUserById(int id) // method beginning
        {
            if (id <= 0)
            {
                return NotFound("geçersiz kullanıcı id");
            }
            var userDto = await _userService.GetUserIdAsync(id);

            if (!userDto.IsSuccess)
            {
                return BadRequest(userDto.Message);
            }

            return Ok(userDto.Data);

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUser request)  // method beginning
        {
            if (id <= 0)
            {
                return BadRequest("geçersiz kullanıcı");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userInfo = new UserInfoDto()
            {
                Id = id,
                BirthDate = request.BirthDate,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
            };
            var response = await _userService.UpdateUserAsync(userInfo);

            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }

            await _userLoggerHelper.LogAsync(id, UserActionType.ProfileUpdate);


            return NoContent();
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> PatchUser(int id, [FromBody] UserPatchDto dto) // method beginning
        {
            if (dto == null)
                return BadRequest("Güncelleme verisi gönderilmedi");

            var result = await _userService.PatchUserAsync(id, dto);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            await _userLoggerHelper.LogAsync(id, UserActionType.ProfileUpdate);


            return NoContent();
        } // end of PatchUser

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteUser(int id) // method beginning
        {
            if (id <= 0)
            {
                return BadRequest("geçersiz kullanıcı");
            }

            var response = await _userService.DeleteUserIdAsync(id);

            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);      
            }

            return NoContent();
        }
    }// end of  AuthController
}