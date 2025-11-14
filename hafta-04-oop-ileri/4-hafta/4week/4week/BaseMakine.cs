using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4week
{

    public abstract class BaseMakine
    {
        public DateTime ProductionDate { get; set; }       // Üretim Tarihi // Production Date
        public int SerialNumber { get; set; }           // Seri Numarası // Serial Number
        public string Name { get; set; }                   // Ad // Name
        public string Description { get; set; }            // Açıklama // Description
        public string OperatingSystem { get; set; }        // İşletim Sistemi // Operating System

        public BaseMakine()
        {
            ProductionDate = DateTime.Now;  // Üretim tarihini şu anki zamana ayarlar // Sets production date to current time
            Console.WriteLine($"Üretim Tarihi: {ProductionDate.ToShortDateString()}");

        }

        public abstract void ProductName(string name);  // Alt sınıfların ürün adını belirlemesini zorunlu kılar // Forces derived classes to implement product name method

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Açıklama: {Description}");   // Açıklama yazdırılır // Prints description
            Console.WriteLine($"Seri Numarası: {SerialNumber}");   // Seri numarası yazdırılır // Prints serial number
            Console.WriteLine($"İşletim Sistemi: {OperatingSystem}");   // İşletim sistemi yazdırılır // Prints operating system
        }
    }

    public class Telephone : BaseMakine, ILisance
    {
        public string IsTurkishLicensed { get; set; }  // Türkçe lisans durumu // Turkish license status

        public override void ProductName(string name)  // Ürün adını ayarlar // Sets product name
        {
            Name = name;
            Console.WriteLine($"Ad: {Name}");
        }

        public override void ShowInfo()  // Tüm bilgileri gösterir // Displays all information
        {
            base.ShowInfo();  // Üst sınıftaki bilgileri göster // Show base class info
            Console.WriteLine($"Türkçe Lisanslı: {IsTurkishLicensed}");  // Türk lisansı bilgisi // Turkish license info
        }
    }

    public class Laptop : BaseMakine, IUsb, Ibluetooth
    {

        public string Bluetooth { get; set; }   // Bluetooth özelliği bilgisi // Bluetooth property

        private int _usbNumber;

        public int UsbNumber
        {
            get => _usbNumber;
            set
            {
                if (value == 2 || value == 4)  // USB sayısı sadece 2 veya 4 olabilir // Only 2 or 4 USB ports allowed
                {
                    _usbNumber = value;
                }
                else
                {
                    Console.WriteLine("USB sayısı 2 veya 4 olmalıdır.");  // Geçersiz değer uyarısı // Invalid value warning
                }
            }
        }

        public override void ProductName(string name)   // Ürün adını belirler // Sets product name
        {
            Name = name;
            Console.WriteLine($"Ad: {Name}");
        }

        public override void ShowInfo()  // Bilgileri ekrana yazdırır // Prints all properties
        {
            base.ShowInfo();  // Üst sınıf bilgilerini göster // Show base class info
            Console.WriteLine($"USB Sayısı: {UsbNumber}");  // USB sayısını gösterir // Prints USB count
            Console.WriteLine($"Bluetooth: {Bluetooth}");   // Bluetooth durumunu gösterir // Prints Bluetooth status
        }

    }
}
