using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polymorphism
{
    public class BaseGeometrikSekil
    {

        public double Heigh { get; set; }
        public double Wide { get; set; }

        public virtual double AlanHesapla()
        {

            double alan = Heigh * Wide;
            return alan;
        }

     

       

    }
}
