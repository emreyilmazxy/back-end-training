using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Ogrenci : BaseKisi
    {
        public int OgrenciNo { get; set; }

        public void OgrenciBilgileri() 
        {

            Yazdir();
            Console.WriteLine($"ogrenci no={OgrenciNo}");       
        }


    }

}

