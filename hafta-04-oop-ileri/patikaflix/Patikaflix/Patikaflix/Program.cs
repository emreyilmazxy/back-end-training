using System;
using System.Collections.Generic;
using System.Linq;

namespace Patikaflix
{
    class Program
    {
        public static int IsInt()  // Bu metot, kullanıcının girdiği değerin tamsayı olup olmadığını kontrol eder.
        {
            while (true)
            {
                bool isValid = int.TryParse(Console.ReadLine(), out int num);

                if (!isValid)
                {
                    Console.WriteLine("lürfen rakamsal ifadeler girin");
                    continue;
                }
                else
                    return num; // Geçerli bir tamsayı girişi yapıldı
            }
        }

        static void Main(string[] args)
        {
            List<TVSeries> seriesList = new List<TVSeries>();
            bool isRunning = true;
            while (isRunning)
            {
            begining:
                Console.WriteLine("dizi oluşturmak ister misiniz ? -e - h");
                string answer = Console.ReadLine().ToLower();
                if (answer != "e" && answer != "h")
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen 'e' veya 'h' girin.");
                    goto begining;
                }
                if (answer == "h")
                {
                    Console.WriteLine("Programdan çıkılıyor...");
                    isRunning = false;
                }
                else
                {

                    TVSeries newSeries = new TVSeries();

                    Console.WriteLine("dizinin adını girin");
                    newSeries.Title = Console.ReadLine();

                    Console.WriteLine("yapım yılı nedir ?");
                    newSeries.ProductionYear = IsInt();

                    Console.WriteLine("dizinin türünü girin");
                    newSeries.Genre = Console.ReadLine().Trim().ToLower();

                    Console.WriteLine("dizinin yayınlanmaya başlama yılını girin");
                    newSeries.ReleaseYear = IsInt();

                    Console.WriteLine("dizinin yönetmenini girin");
                    newSeries.Director = Console.ReadLine();

                    Console.WriteLine("dizinin ilk yayınlandığı platformu girin");
                    newSeries.FirstBroadcastPlatform = Console.ReadLine();

                   
                    seriesList.Add(newSeries); // Yeni dizi nesnesini listeye ekle

                    Console.WriteLine("Dizi başarıyla eklendi!");

                    Console.WriteLine("Yeni bir dizi eklemek ister misiniz? (e/h)");
                    string continueAnswer = Console.ReadLine().ToLower();
                    while (continueAnswer != "e" && continueAnswer != "h")
                    {
                        Console.WriteLine("Geçersiz giriş. Lütfen 'e' veya 'h' girin.");
                        continueAnswer = Console.ReadLine().ToLower();
                    }
                    if (continueAnswer == "h")
                    {
                        isRunning = false;
                    }
                }
            } //ana while bitişi

            var komediSeries = seriesList
               .Where(s => s.Genre.Equals("komedi", StringComparison.OrdinalIgnoreCase))
                .Select(s => new Komedi
                {
                    SeriesName = s.Title,
                    SeriesGentre = s.Genre,
                    Director = s.Director
                })
                .OrderBy(s => s.SeriesName)
                .ThenBy(s => s.Director)
                .ToList();

            Console.WriteLine($" Toplam komedi dizisi: {komediSeries.Count} ");

            foreach (var komedi in komediSeries)
            {
                Console.WriteLine($"Dizi Adı: {komedi.SeriesName}, Tür: {komedi.SeriesGentre}, Yönetmen: {komedi.Director}");
            }
        }
    }




}
