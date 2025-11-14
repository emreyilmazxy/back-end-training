using OnlineShoppingApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Operations.User.Dtos
{
    public class AddUserDto
    {  
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
       
        public DateTime BirthDate { get; set; }

        public UserType UserType { get; set; } = UserType.Customer; // Default to Customer type

        public string PhoneNumber { get; set; }
    } // end of AddUserDto class
}
