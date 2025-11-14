
using BankApp.Business.Operations.UserActivityy.Dtos;
using BankApp.Business.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.UserActivityy
{
    public interface IUserActivityService
    {
        Task<ServiceMessage<List<UserActivityListDto>>> GetAllLogsAsync();
    }
}
