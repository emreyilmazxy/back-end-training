using System.Threading.Tasks;

namespace BankApp.Business.Operations.TwoFactor
{
    public interface IOtpSender
    {
        Task SendOtpAsync(string provider, string destination, string otpCode);
    }
}

