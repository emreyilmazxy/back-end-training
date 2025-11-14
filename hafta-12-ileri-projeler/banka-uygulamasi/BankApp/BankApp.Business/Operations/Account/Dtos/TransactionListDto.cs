using BankApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankApp.Business.Operations.Account.Dtos
{
    public class TransactionListDto
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }
        public string Currency { get; set; }              

        public string TransactionType { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Description { get; set; }

        public string SenderFullName { get; set; }
        public string SenderAccountNumber { get; set; }   

        public string ReceiverFullName { get; set; }
        public string ReceiverAccountNumber { get; set; } 

        public bool IsSender { get; set; }
        public string OtherPartyFullName { get; set; }    
    }
}
