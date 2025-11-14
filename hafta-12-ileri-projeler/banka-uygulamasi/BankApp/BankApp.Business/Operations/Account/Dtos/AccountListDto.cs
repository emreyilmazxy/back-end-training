using BankApp.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.Account.Dtos
{
    public class AccountListDto
    {
        public int UserId { get; set; }
        public List<AccountInfoDto> Accounts { get; set; } = new();
    }
}
