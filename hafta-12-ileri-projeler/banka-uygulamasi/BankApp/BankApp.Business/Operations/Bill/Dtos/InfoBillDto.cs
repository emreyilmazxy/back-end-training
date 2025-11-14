using BankApp.Data.Entities;
using BankApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.Bill.Dtos
{
    public class InfoBillDto
    {
        public  int Id  { get; set; }
        public int UserId { get; set; }
        public string BillType { get; set; }
        public decimal Amount { get; set; }

        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaymentDate { get; set; }

        public string FullName { get; set; }


    }
}
