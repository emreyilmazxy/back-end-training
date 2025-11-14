using Asp.Versioning;
using BankApp.Business.Operations.Account;
using BankApp.Business.Operations.Account.Dtos;
using BankApp.Data.Enums;
using BankApp.WepApi.Helpers;
using BankApp.WepApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace BankApp.WepApi.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly UserLoggerHelper _userLoggerHelper;

        public AccountsController(IAccountService accountService, UserLoggerHelper userLoggerHelper)
        {
            _accountService = accountService;
            _userLoggerHelper = userLoggerHelper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllAccount() // method beginning
        {
            var userIdString = User.FindFirstValue("id");
            if (!int.TryParse(userIdString, out int userId))
            {
                return BadRequest("Kullanıcı kimliği alınamadı.");
            }

            var AccountList = await _accountService.AllAccountAsync(userId);

            if (!AccountList.IsSuccess)
            {
                return BadRequest(AccountList.Message);
            }
           
            await _userLoggerHelper.LogAsync(userId, UserActionType.AccountViewed);

            return Ok(AccountList.Data);

        } // end of GetAllAccount

        [HttpGet]
        [Route("{id}/balance")]

        public async Task<IActionResult> GetBalanceById(int id) // method beginning
        {
            if (id < 1)
                return BadRequest("Geçersiz ID değeri");

            var userIdStr = User.FindFirstValue("id");
            if (!int.TryParse(userIdStr, out int userId))
                return Unauthorized("Kullanıcı doğrulanamadı");

            var balance = await _accountService.GetBalanceAsync(id ,userId);

            if (!balance.IsSuccess)
            {
                return BadRequest(balance.Message);
            }

            await _userLoggerHelper.LogAsync(userId, UserActionType.BalanceViewed);

            return Ok(balance.Data);

        

        } // end of GetBalanceById

        [HttpGet]
        [Route("{userId}/transactions")]
        public async Task<IActionResult> GetUserTransactions(int userId) // method beginning
        {
            if (userId <= 0)
            {
                return BadRequest("Geçersiz kullanıcı ID");
            }

            var result = await _accountService.GetUserTransactionsAsync(userId);

            if (!result.IsSuccess || result.Data == null || !result.Data.Any())
            {
                return NotFound(result.Message ?? "İşlem bulunamadı.");
            }

            await _userLoggerHelper.LogAsync(userId, UserActionType.TransactionsViewed);

            return Ok(result.Data);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(AddAccountRequest add) // method beginning
        {
            var userId = User.FindFirstValue("id");

            if (string.IsNullOrEmpty(userId))
                return BadRequest("Kullanıcı bulunamadı");

            var dto = new AccountInfoDto
            {
                UserId = int.Parse(userId),
                Currency = add.Currency,
                Balance = 0
            };

            var result = await _accountService.AddAccountAsync(int.Parse(userId), dto);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            await _userLoggerHelper.LogAsync(int.Parse(userId), UserActionType.AccountCreated);


            return CreatedAtAction(nameof(GetBalanceById), new { id = result.Data.Id }, result);
        } // end of add

        [HttpPost]
        [Route("{id}/transfer")]
        public async Task<IActionResult> Transfer(int id, TransferRequest request) // method beginning
        {

            var userId = User.FindFirstValue("id");

            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Kullanıcı doğrulanamadı.");

            if (int.Parse(userId) != id)
                return Unauthorized("Kendi dışınızdaki bir kullanıcı için işlem yapamazsınız.");


            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var dto = new TransferRequestDto
            {
                SenderAccountId = request.SenderAccountId,
                ReceiverAccountNumber = request.ReceiverAccountNumber,
                Amount = request.Amount,
                Description = request.Description
            };


            var result = await _accountService.TransferAsync(dto);


            if (!result.IsSuccess)
                return BadRequest(result.Message);

            await _userLoggerHelper.LogAsync(int.Parse(userId), UserActionType.TransferMade);

            return CreatedAtAction(nameof(GetUserTransactions), new { userId = id }, result.Data);
        } // end of Transfer

        [HttpPost("{id}/deposit")]
        public async Task<IActionResult> Deposit(int id, DepositRequest request) // method beginning
        {
            var userId = User.FindFirstValue("id");

            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Kullanıcı doğrulanamadı.");

            var dto = new DepositRequestDto
            {
                AccountId = id,
                UserId = int.Parse(userId),
                Amount = request.Amount,
                Description = request.Description
            };

            var result = await _accountService.DepositAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            await _userLoggerHelper.LogAsync(int.Parse(userId), UserActionType.DepositMade);

            return Ok(result.Data);
        } // end of deposit

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest("hesap id negatif olamaz");

            }

            var userIdString = User.FindFirstValue("id");
            if (!int.TryParse(userIdString, out int userId))
            {
                return Unauthorized("Kullanıcı doğrulanamadı");
            }

            var result = await _accountService.DeleteAccountAsync(id, userId);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            await _userLoggerHelper.LogAsync(userId, UserActionType.AccountDeleted);

            return NoContent();
        }


    } // end of AccountController
}
