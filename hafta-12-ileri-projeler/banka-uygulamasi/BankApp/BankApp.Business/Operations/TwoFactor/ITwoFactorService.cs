using BankApp.Business.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.TwoFactor
{
    public interface ITwoFactorService
    {
        Task<ServiceMessage> GenerateOtpAsync(int userId, string provider);
        Task<ServiceMessage<bool>> VerifyOtpAsync(int userId, string otpCode);

        string GenerateOtpCode();
    }
}
