using BankApp.Business.Operations.Security.Dtos;
using BankApp.Business.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.Security
{
    public interface ISecurityService
    {
        Task<ServiceMessage<string>> SetTwoFactorAsync(TwoFactorDto dto);

        Task<ServiceMessage<string>> ChangePasswordAsync(ChangePasswordDto dto);

    }
}
