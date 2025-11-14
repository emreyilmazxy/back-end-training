using BankApp.Data.Entities;
using BankApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Operations.User.Dtos
{
    public class UserInfoDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public UserType UserType { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; } 
        public bool IsTwoFactorEnable { get; set; }

      
    } // end of class getuserdto 
}
