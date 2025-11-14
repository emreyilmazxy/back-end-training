using BankApp.Data.Entities;
using BankApp.Data.Enums;
using BankApp.Data.UnitOfWork;
using System;
using System.Net;

namespace BankApp.WepApi.Helpers
{
    public class UserLoggerHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public UserLoggerHelper(IUnitOfWork unitOfWork,IHttpContextAccessor contextAccessor )
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task LogAsync(int userId, UserActionType action) 
        {
            var context = _contextAccessor.HttpContext;

            var ipAddress = context?.Connection?.RemoteIpAddress?.ToString() ?? "unknown IP";
            var userAgent = context?.Request?.Headers["User-Agent"].ToString() ?? "Unknown Device";

            var log = new UserActivity
            {
                UserId = userId,
                Action = action,
                IpAddress = ipAddress,
                Device = userAgent,
                Timestamp = DateTime.Now
            };

            await _unitOfWork.GetRepository<UserActivity>().AddAsync(log);
            await _unitOfWork.SaveChangesAsync();
        }


    } // end of UserLoggerHelper
}
