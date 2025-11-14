using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4week
{
    public interface ILisance
    {
        public string IsTurkishLicensed { get; set; }       // Türkçe lisans bilgisi // Turkish license information
    }

    public interface IUsb
    {
        public int UsbNumber { get; set; }       // USB port sayısı // Number of USB ports
    }

    public interface Ibluetooth
    {
        public string Bluetooth { get; set; }        // Bluetooth özelliği bilgisi // Bluetooth feature information
    }
}
