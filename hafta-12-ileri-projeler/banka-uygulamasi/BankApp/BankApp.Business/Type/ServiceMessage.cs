using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.Type
{
    public class ServiceMessage
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
       
    }// end of class ServiceMessage

    public class ServiceMessage<T> : ServiceMessage
    {
        public T Data { get; set; }

    }// end of class ServiceMessage<T>
}
