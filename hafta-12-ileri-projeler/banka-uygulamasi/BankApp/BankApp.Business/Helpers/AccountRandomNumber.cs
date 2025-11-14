using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Helpers
{
    public static class AccountRandomNumber
    {
        public static string GenerateRandomNumber(int length)
        {
            var random = new Random();
            var builder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                builder.Append(random.Next(0, 10)); // 0 ile 9 arası rakam ekler
            }

            return "TR" + builder.ToString();
        }

    }
}
