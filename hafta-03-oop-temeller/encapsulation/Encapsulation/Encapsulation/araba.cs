

namespace Encapsulation
{
    public class araba
    {

        public string Marka;
        public string Model;
        public string Renk;
        public int KapiSayisi;

        public int _kapiSayisi
        {
            get
            {
                return KapiSayisi;
            }
            set {
                if (value == 2 || value == 4)
                {
                    KapiSayisi = value;
                }
                else
                {
                    Console.WriteLine("Kapı sayısı 2 veya 4 olmalıdır.");
                    KapiSayisi = -1; 
                }
            }
        }

    }
}
