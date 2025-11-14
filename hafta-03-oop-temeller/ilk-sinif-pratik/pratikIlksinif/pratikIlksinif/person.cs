using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pratikIlksinif
{
    public class Person
    {
        private string _ad;
        private string _soyad;
        private string _dogumTarihi;

        public string ad
        {
            get { return _ad; }
            set { _ad = value; }
        }
        public string soyad
        {
            get { return _soyad; }
            set { _soyad = value; }
        }
        public string dogumTarihi
        {
            get { return _dogumTarihi; }
            set { _dogumTarihi = value; }
        }
        
    }
}