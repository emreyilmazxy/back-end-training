using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.Security.Dtos
{
    public class TwoFactorDto
    {
        public int UserId { get; set; }
        public bool IsTwoFactorEnabled { get; set; }
    }
}
