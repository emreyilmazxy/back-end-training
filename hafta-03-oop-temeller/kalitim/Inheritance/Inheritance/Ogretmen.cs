using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Ogretmen : BaseKisi
    {


        public int Maas { get; set; }

        public void ogretmenBilgileri()
        {
            Yazdir();
            Console.WriteLine($"Maas: {Maas}");
        }

    }
}
