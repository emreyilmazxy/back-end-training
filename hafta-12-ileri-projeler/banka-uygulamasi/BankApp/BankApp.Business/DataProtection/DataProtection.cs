using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.DataProtection
{
    public class DataProtection : IDataProtection
    {
        private readonly IDataProtector _dataProtector;

        public DataProtection(IDataProtectionProvider provider)
        {
            _dataProtector = provider.CreateProtector("BankApp");
        }

        public string Protect(string text)
        {
            return _dataProtector.Protect(text);
        }

        public string Unprotect(string text)
        {
            return _dataProtector.Unprotect(text);
        }
    } // end of class DataProtection
}
