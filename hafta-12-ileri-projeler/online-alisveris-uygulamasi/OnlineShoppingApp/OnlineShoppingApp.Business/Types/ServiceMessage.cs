using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingApp.Business.Types
{
    public class ServiceMessage
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

    } // end of ServiceMessage class

    public class ServiceMessage<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public T? Data { get; set; }

    } // end of ServiceMessage class2
}
