using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.DataProtection
{
    // Interface for text encryption and decryption
    public interface IDataProtection
    {
        string protect(string text);
        string Unprotect(string text);
    } // IDataProtection interface done
}
