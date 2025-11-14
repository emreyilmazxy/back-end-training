using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.Account.Dtos
{
    public class AccountBalanceDto
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
