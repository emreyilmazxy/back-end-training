using Asp.Versioning;
using BankApp.Business.Operations.Bill;
using BankApp.Business.Operations.Bill.Dtos;
using BankApp.Data.Enums;
using BankApp.WepApi.Helpers;
using BankApp.WepApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BankApp.WepApi.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BillsController : ControllerBase
    {
        private readonly IBillService _billservice;
        private readonly UserLoggerHelper _userLoggerHelper;

        public BillsController(IBillService billservice,UserLoggerHelper userLoggerHelper ) // methodbeginning
        {
            _billservice = billservice;
            _userLoggerHelper = userLoggerHelper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirstValue("id");

            var bills = await _billservice.GetAllBills(int.Parse(userId));

            if (!bills.IsSuccess)
            {
                return NoContent();
            }

            await _userLoggerHelper.LogAsync(int.Parse(userId), UserActionType.BillViewed);

            return Ok(bills.Data);

        } // end of GetAll

        [HttpPost]
        [Route("pay/{id}")]
        public async Task<IActionResult> PayBill(int id, PayBillRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirstValue("id");
            if (string.IsNullOrEmpty(userId))
                return BadRequest("Kullanıcı kimliği alınamadı");

            var dto = new PayBillDto
            {
                BillId = id,
                UserId = int.Parse(userId),
                AccountId = request.AccountId,
                Amount = request.Amount,  
            };

            var result = await _billservice.PayBillAsync(dto.UserId, dto);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            await _userLoggerHelper.LogAsync(dto.UserId, UserActionType.BillPaid);


            return Ok(result.Data);
        } // end of PayBill 

        [HttpPost("create")]
        public async Task<IActionResult> CreateBill(CreateBillRequest request) // for test end point
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirstValue("id");
            if (string.IsNullOrEmpty(userId))
                return BadRequest("Kullanıcı kimliği alınamadı");

            var dto = new CreateBillDto
            {
                UserId = int.Parse(userId),
                BillType = request.BillType,
                Amount = request.Amount,
                DueDate = request.DueDate,
            };

            var result = await _billservice.CreateBillAsync(dto);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Data); 
        } // end of createBill


    } // end of controller
}
