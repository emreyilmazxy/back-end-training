using BankApp.Business.Operations.TwoFactor;
using System;
using System.Threading.Tasks;

namespace BankApp.WepApi.Helpers
{
    public class OtpSender : IOtpSender
    {
        public Task SendOtpAsync(string provider, string destination, string otpCode)
        {
            Console.WriteLine($"Sending OTP {otpCode} via {provider} to {destination}");
            return Task.CompletedTask;
        }
    }
}

