using Asp.Versioning;
using BankApp.Business.Operations.Security;
using BankApp.Business.Operations.Security.Dtos;
using BankApp.Business.Operations.TwoFactor;
using BankApp.Business.Operations.User;
using BankApp.Business.Operations.UserActivityy;
using BankApp.Data.Enums;
using BankApp.WepApi.Helpers;
using BankApp.WepApi.Jwt;
using BankApp.WepApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BankApp.WepApi.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IUserActivityService   _userActivityService;
        private readonly UserLoggerHelper _userLoggerHelper;
        private readonly ITwoFactorService _twoFactorService;
        private readonly IUserService _userService;
        
      

        public SecurityController(ISecurityService securityService,IUserActivityService userActivityService, UserLoggerHelper userLoggerHelper,ITwoFactorService twoFactorService,IUserService userService )
        {
            _securityService = securityService;
            _userActivityService = userActivityService;
            _userLoggerHelper = userLoggerHelper;
            _twoFactorService = twoFactorService;
            _userService = userService;
        }

        [HttpPost]
        [Route("two-factor-auth")]

        public async Task<IActionResult> SetTwoFactor(TwoFactorRequest request) // method beginning
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirstValue("id");
            if (string.IsNullOrEmpty(userId))
                return BadRequest("Kullanıcı kimliği alınamadı.");

            var dto = new TwoFactorDto
            {
                UserId = int.Parse(userId),
                IsTwoFactorEnabled = request.IsTwoFactorEnabled
            };

            var result = await _securityService.SetTwoFactorAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            await _userLoggerHelper.LogAsync(dto.UserId, UserActionType.TwoFactorUpdated);

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto request) // method beginning
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirstValue("id"); 
            if (string.IsNullOrEmpty(userId))
                return BadRequest("Kullanıcı kimliği alınamadı.");

            request.UserId = int.Parse(userId); 

            var result = await _securityService.ChangePasswordAsync(request);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            await _userLoggerHelper.LogAsync(request.UserId, UserActionType.PasswordChange);

            return Ok(result.Data);
        }

        [HttpGet("logs")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetLogs() // method beginning
        {
            var result = await _userActivityService.GetAllLogsAsync();

            if (!result.IsSuccess || result.Data == null || !result.Data.Any())
                return NotFound("Herhangi bir kullanıcı hareketi bulunamadı.");

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("verify-otp")]
        public async Task<IActionResult> VerifyOtp(VerifyOtpRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.GetUserIdAsync(request.UserId);

            if (!user.IsSuccess)
                return BadRequest("Kullanıcı bulunamadı.");

            var result = await _twoFactorService.VerifyOtpAsync(request.UserId, request.OtpCode);

            if (!result.IsSuccess)
                return BadRequest(result.Message);


            var configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            var token = JwtHelper.GenerateJwtToken(new JwtDto
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

            return Ok(new
            {
                Message = "Doğrulama başarılı",
                Token = token
            });
        }

    } // en of contoroller
}
