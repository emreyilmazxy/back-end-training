using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.DataProtection
{
    // Handles encryption and decryption using IDataProtection
    public class DataProtection : IDataProtection
    {
        private readonly IDataProtector _dataProtector;

        public DataProtection(IDataProtectionProvider provider)
        {
            // Purpose string is used to isolate this protector's encryption scope
            _dataProtector = provider.CreateProtector("OnlineShopping");
        }

        public string protect(string text)
        {
            return _dataProtector.Protect(text);
        }

        public string Unprotect(string ProductedText)
        {
            return _dataProtector.Unprotect(ProductedText);
        }
    } // DataProtection class done
}
