using System;

namespace Greengrocer
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(@"rüya manavına hoş geldiniz!
Elma = 2 TL
Armut = 3 TL
Çilek = 2 TL
Muz = 3 TL
Diğer bütün meyveler = 4 tL ");

            Console.WriteLine();
            Console.Write("Hangi meyveyi satıl almak istersiniz?(Elma/Armut/Çilek/Muz/diğer): ");

            string meyve = Console.ReadLine().ToLower().Trim();

            if (meyve == "elma") { Console.WriteLine("seçtiğiniz meyvenin fiyatı = 2 TL "); }

            else if (meyve == "armut") { Console.WriteLine("seçtiğiniz meyvenin fiyatı = 3 TL "); }

            else if (meyve == "çilek") { Console.WriteLine("seçtiğiniz meyvenin fiyatı = 2 TL "); }

            else if (meyve == "muz") { Console.WriteLine("seçtiğiniz meyvenin fiyatı = 3 TL "); }


            else if (meyve == "diğer") { Console.WriteLine("seçtiğiniz meyvenin fiyatı = 4 TL "); }
            else { Console.WriteLine("elimizde kalmadı taze bitti"); }

            //buradan itibaren switch case versiyonu başlıyor 
            Console.WriteLine();
            Console.WriteLine(@"rüya manavına hoş geldiniz!
Elma = 2 TL
Armut = 3 TL
Çilek = 2 TL
Muz = 3 TL
Diğer bütün meyveler = 4 tL ");

            Console.WriteLine();
            Console.Write("Hangi meyveyi satıl almak istersiniz?(Elma/Armut/Çilek/Muz/diğer): ");

            meyve = Console.ReadLine().ToLower().Trim();

            switch (meyve)
            {

                case "elma":
                    Console.WriteLine("seçtiğiniz meyvenin fiyatı = 2 TL ");
                    break;
                case "armut":
                    Console.WriteLine("seçtiğiniz meyvenin fiyatı = 3 TL");
                    break;
                case "muz":
                    Console.WriteLine("seçtiğiniz meyvenin fiyatı = 3 TL ");
                    break;
                case "çilek":
                    Console.WriteLine("seçtiğiniz meyvenin fiyatı = 2 TL");
                    break;
                case "diğer":
                    Console.WriteLine("seçtiğiniz meyvenin fiyatı = 4 TL");
                    break;
                default:
                    Console.WriteLine("elimizde kalmadı taze bitti");
                    break;
                     
                      /*Buffer çalışmada switch case kontrol yapısının kullanılmasının daha uygun olduğunu düşünüyorum.her ne kadar if else yapısında iç içe geçmiş ifler ve kod okunabilirliği zor olmasada
                       çoktan seçmeli tek bir yapı olduğu için switch caseler daha okunabilirliği kolay ve pratik
                       
                       */
            }
        }

    }
}
