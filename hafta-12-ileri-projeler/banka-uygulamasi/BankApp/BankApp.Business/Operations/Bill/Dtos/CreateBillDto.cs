using BankApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.Bill.Dtos
{
    public class CreateBillDto
    {
        public int UserId { get; set; } 
        public BillType BillType { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
       
    }
}
