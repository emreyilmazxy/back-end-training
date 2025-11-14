using System;

namespace FiveWeekClosed
{
    class Program
    {
        static void Main(string[] args)
        {
             
                   
            List<Car> cars = new List<Car>();
            bool programRunning = true;
            while (programRunning)
            {
                Console.WriteLine("araba üretmek istermisiniz ? -e  - h");
                string answer = Console.ReadLine().ToLower();
                while (answer != "e" && answer != "h")
                {
                    Console.WriteLine("Lütfen geçerli bir cevap giriniz (e/h): ");
                    answer = Console.ReadLine().ToLower();
                }
          
                if (answer == "e"  )
                {

                again:  // eğer kullanıcı yeni bir araba eklemek isterse tekrar başa dönmesi için label kullandık ilk consele sorusu çıkmaması için burada kullandım.
                    Car car = new Car();

                    Console.WriteLine("marka girin");
                    car.Brand = Console.ReadLine();

                    Console.WriteLine("model giriniz");
                    car.Model = Console.ReadLine();

                    Console.WriteLine("arabanın rengini giriniz");
                    car.Color = Console.ReadLine();

                    Console.WriteLine("arabanın seri numarasını girin");
                    bool isValidSeriNo = int.TryParse(Console.ReadLine(), out int seriNo);
                    seriNo = isValidSeriNo ? seriNo : 0; // Default to 0 if parsing fails
                    car.SeriNo = seriNo;

                CarDoor: // eğer kullanıcı kapı sayısını yanlış girerse tekrar sorulması için label kullandık.

                    Console.WriteLine("lüffen araç kapı sayısı girin -2 veya -4");
                     bool isValidDoorNumber = int.TryParse(Console.ReadLine(), out int doorNumber);

                    if (isValidDoorNumber && (doorNumber == 2 || doorNumber == 4))
                    {
                        car.DoorNumber = doorNumber;
                    }
                    else
                    {
                        Console.WriteLine("lütfen geçerli bir sayı giriniz");
                        goto CarDoor;
                    }

                    cars.Add(car);  // yeni araba eklemek için listeye ekliyoruz

                    Console.WriteLine("başka bir araç eklemek ister misiniz ? -e - h");
                    string answer2 = Console.ReadLine().ToLower();

                    while (answer2 != "e" && answer2 != "h")
                    {
                        Console.WriteLine("Lütfen geçerli bir cevap giriniz (e/h): ");
                        answer2 = Console.ReadLine().ToLower();
                    }
                    if (answer2 == "e")
                    {
                        goto again;  // eğer kullanıcı yeni bir araba eklemek isterse tekrar başa dönmesi için goto kullandık.   
                    }
                    else if (answer2 == "h")
                    {
                        Console.WriteLine("Araçlarınız: ");
                        foreach (var c in cars)
                        {
                            Console.WriteLine($"Marka: {c.Brand},  Seri No: {c.SeriNo},");
                        }
                    }

                    programRunning = false; // if bittikten sonra programı kapatmak için false yapıyoruz
                }
                else  // en baştaki ifin else kısmı
                {
                    Console.WriteLine("Programdan çıkılıyor...");

                    programRunning = false;

                }

            }


        }
    }
}