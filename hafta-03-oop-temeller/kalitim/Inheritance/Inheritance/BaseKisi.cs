using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class BaseKisi
    {
        public String Ad { get; set; }
        public string Soyad { get; set; }

        public void Yazdir()
        {
            Console.WriteLine($"Ad:  { Ad} Soyad: {Soyad}");
            
        }
    }
}
