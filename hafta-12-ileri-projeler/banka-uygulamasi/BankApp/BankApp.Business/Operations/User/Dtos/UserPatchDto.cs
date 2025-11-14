using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.User.Dtos
{
    public class UserPatchDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public bool IstwoFactorEnable { get; set; } = false;
        public string? email { get; set; }
    }
}
