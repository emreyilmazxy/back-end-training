using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.UserActivityy.Dtos
{
    public class UserActivityListDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Action { get; set; }
        public string IpAddress { get; set; }
        public string? Device { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
