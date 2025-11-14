using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trycatcth
{
    public class Users
    {
        public void setAge(int age)
        {
            if (age < 0)
            {
                throw new UserAgeExeption("Yaş negatif olamaz!"); 
            }

        }

    }

    public class UserAgeExeption : Exception
    {
        public UserAgeExeption(string message) : base(message)
        {

        }

    }
}
