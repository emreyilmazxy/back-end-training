using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.Account.Dtos
{
    public class DepositRequestDto
    {
        public int AccountId { get; set; }      
        public int UserId { get; set; }         
        public decimal Amount { get; set; }     
        public string? Description { get; set; }
    }
}
