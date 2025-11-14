using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.Account.Dtos
{
    public class TransferRequestDto
    {
        public string ReceiverAccountNumber { get; set; }   
        public int SenderAccountId { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }
}
