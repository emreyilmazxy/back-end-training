
using BankApp.Business.Operations.UserActivityy;
using BankApp.Business.Operations.UserActivityy.Dtos;
using BankApp.Business.Type;
using BankApp.Data.Entities;
using BankApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.UserActivityy
{
    public class UserActivityService : IUserActivityService
    {
        private readonly IRepository<UserActivity> _activityRepo;

        public UserActivityService(IRepository<UserActivity> activityRepo)
        {
            _activityRepo = activityRepo;
        }

        public async Task<ServiceMessage<List<UserActivityListDto>>> GetAllLogsAsync() // method beginning
        {
            var logs = await _activityRepo.GetAll()
                .Include(x => x.User)
                .OrderByDescending(x => x.Timestamp)
                .Select(x => new UserActivityListDto
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    FullName = x.User.FirstName + " " + x.User.LastName,
                    Action = x.Action.ToString(),
                    IpAddress = x.IpAddress,
                    Device = x.Device,
                    Timestamp = x.Timestamp
                })
                .ToListAsync();

            return new ServiceMessage<List<UserActivityListDto>>
            {
                IsSuccess = true,
                Data = logs
            };
        } // end of GetAllLogsAsync
    } // end of class
}
