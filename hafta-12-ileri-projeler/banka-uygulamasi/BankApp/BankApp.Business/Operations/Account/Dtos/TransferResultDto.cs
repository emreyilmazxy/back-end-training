using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.Account.Dtos
{
    public class TransferResultDto
    {
        public int SenderAccountId { get; set; }
        public int ReceiverAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string? Description { get; set; }
        public DateTime Timestamp { get; set; }

        public string SenderFullName { get; set; }
        public string ReceiverFullName { get; set; }

    }
}
