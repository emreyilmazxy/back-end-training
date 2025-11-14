namespace _4week
{

    public class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;               // tüm programın Döngü kontrolü için boolean değişken // boolean variable to control the whole program loop

            while (isRunning)
            {

                int choice;

                do
                {
                    Console.WriteLine("Telefon üretmek için: 1\nLaptop üretmek için: 2 giriniz");

                    bool isValid = int.TryParse(Console.ReadLine(), out choice);

                    if (!isValid || (choice != 1 && choice != 2))                   // Kullanıcıdan geçerli bir sayı girmesini isteyen döngü // loop asking the user to enter a valid number
                    {
                        Console.WriteLine("Geçerli bir sayı giriniz (1 ya da 2).");
                    }

                } while (choice != 1 && choice != 2);

                if (choice == 1)                               // Kullanıcı 1 girerse telefon üretme işlemi başlar // if user enters 1, phone production starts
                {
                    Console.WriteLine("Telefon seçtiniz.");
                    Console.WriteLine("Telefon adı giriniz: ");
                    string _Name = Console.ReadLine();
                    int _SerialNumber;
                    do  // Kullanıcıdan 5 haneli seri numarası isteyen döngü // loop asking the user for a 5-digit serial number
                    {
                        Console.WriteLine(" 5 haneli telefon seri no belirle:");
                        bool Iscorect = int.TryParse(Console.ReadLine(), out _SerialNumber);
                        if (!Iscorect || _SerialNumber < 10000 || _SerialNumber > 99999)
                        {
                            Console.WriteLine("Hatalı giriş! Lütfen 5 haneli bir sayı girin.");
                        }

                    } while (_SerialNumber < 10000 || _SerialNumber > 99999);
                    Console.WriteLine("telefon açıklaması girin");
                    string _Description = Console.ReadLine();

                    Console.WriteLine("işletim sistemi belirtin IOS ya da ANDROİD");
                    string _OperatingSystem = Console.ReadLine();

                    Console.WriteLine("lisans terhici yapın: TR ya da Yurt Dışı");
                    string _IsTurkishLicensed = Console.ReadLine();

                    Console.WriteLine("telefon üretildi");
                    Telephone phone = new Telephone();     // Telefon sınıfından yeni bir nesne oluşturma // creating a new object from the Telephone class

                    phone.ProductName(_Name);
                    phone.SerialNumber = _SerialNumber;
                    phone.Description = _Description;
                    phone.OperatingSystem = _OperatingSystem;
                    phone.IsTurkishLicensed = _IsTurkishLicensed;
                    phone.ShowInfo();

                    Console.WriteLine("başka bir ürün üretmek ister misiniz ? EVET ya da HAYIR");
                    string response = Console.ReadLine().ToUpper();
                    if (response == "HAYIR")
                    {
                        isRunning = false;     // Kullanıcı "HAYIR" derse program döngüsünden çıkar // if the user says "HAYIR", exit the loop
                    }

                }
                else if (choice == 2)      // Kullanıcı 2 girerse laptop üretme işlemi başlar // if user enters 2, laptop production starts
                {
                    Console.WriteLine("Laptop seçtiniz.");
                    Console.WriteLine("laptop adı giriniz: ");
                    string _Name = Console.ReadLine();
                    int _SerialNumber;
                    do       // Kullanıcıdan 5 haneli seri numarası isteyen döngü // loop asking the user for a 5-digit serial number
                    {
                        Console.WriteLine(" 5 haneli laptop seri no belirle:");
                        bool Iscorect = int.TryParse(Console.ReadLine(), out _SerialNumber);
                        if (!Iscorect || _SerialNumber < 10000 || _SerialNumber > 99999)
                        {
                            Console.WriteLine("Hatalı giriş! Lütfen 5 haneli bir sayı girin.");
                        }

                    } while (_SerialNumber < 10000 || _SerialNumber > 99999);

                    Console.WriteLine("laptop açıklaması girin");
                    string _Description = Console.ReadLine();

                    Console.WriteLine("işletim sistemi belirtin WİNDOWS ya da MAC");
                    string _OperatingSystem = Console.ReadLine();
                    Console.WriteLine("bluetooth içersin mi ? EVET ya da HAYIR ");

                    string HaveBluetooth = Console.ReadLine().ToUpper().Trim();
                    int _UsbNumber;  // Kullanıcıdan USB sayısını isteyen değişken // variable to get USB count from user

                    do
                    {
                        Console.WriteLine("USB Sayısını girin 2 ve ya 4 ");
                        bool IscorectUsb = int.TryParse(Console.ReadLine(), out _UsbNumber);
                        if (!IscorectUsb || (_UsbNumber != 2 && _UsbNumber != 4))
                        {
                            Console.WriteLine("Hatalı giriş! Lütfen 2 ya da 4 girin.");
                        }

                    } while (_UsbNumber != 2 && _UsbNumber != 4);

                    Console.WriteLine("laptop üretildi");
                    Laptop laptop = new Laptop();
                    laptop.ProductName(_Name);
                    laptop.SerialNumber = _SerialNumber;
                    laptop.Description = _Description;   // kullanıcıdan alınan değerlerin ataması // assigning values received from the user
                    laptop.OperatingSystem = _OperatingSystem;
                    laptop.UsbNumber = _UsbNumber;
                    laptop.Bluetooth = HaveBluetooth;
                    laptop.ShowInfo();

                    Console.WriteLine("başka bir ürün üretmek ister misiniz ? EVET ya da HAYIR");
                    string response = Console.ReadLine().ToUpper();
                    if (response == "HAYIR")
                    {
                        isRunning = false;
                    }
                }
            }
        }
    }
}
