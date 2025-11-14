using BankApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.Bill.Dtos
{
    public class PayBillDto
    {
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public int BillId { get; set; }

        public decimal Amount { get; set; }

    }
}
