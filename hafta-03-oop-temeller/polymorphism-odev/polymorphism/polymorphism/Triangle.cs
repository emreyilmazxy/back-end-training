using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polymorphism
{
    public class Triangle : BaseGeometrikSekil
    {

        public override double AlanHesapla()
        {
            double alan = (Heigh * Wide) / 2;
            return alan;
        }
    }
}
