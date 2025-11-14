using System;

namespace Patikafy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Artist> artists = new List<Artist>
            {
    new Artist { Name = "Ajda", Lastname = "Pekkan", Genre = "Pop", ReleaseYear = 1968, AlbumSales = 20000000 },
    new Artist { Name = "Sezen", Lastname = "Aksu", Genre = "Türk Halk Müziği / Pop", ReleaseYear = 1971, AlbumSales = 10000000 },
    new Artist { Name = "Funda", Lastname = "Arar", Genre = "Pop", ReleaseYear = 1999, AlbumSales = 3000000 },
    new Artist { Name = "Sertab", Lastname = "Erener", Genre = "Pop", ReleaseYear = 1994, AlbumSales = 5000000 },
    new Artist { Name = "Sıla", Lastname = "", Genre = "Pop", ReleaseYear = 2009, AlbumSales = 3000000 },
    new Artist { Name = "Serdar", Lastname = "Ortaç", Genre = "Pop", ReleaseYear = 1994, AlbumSales = 10000000 },
    new Artist { Name = "Tarkan", Lastname = "", Genre = "Pop", ReleaseYear = 1992, AlbumSales = 40000000 },
    new Artist { Name = "Hande", Lastname = "Yener", Genre = "Pop", ReleaseYear = 1999, AlbumSales = 7000000 },
    new Artist { Name = "Hadise", Lastname = "", Genre = "Pop", ReleaseYear = 2005, AlbumSales = 5000000 },
    new Artist { Name = "Gülben", Lastname = "Ergen", Genre = "Pop / Türk Halk Müziği", ReleaseYear = 1997, AlbumSales = 10000000 },
    new Artist { Name = "Neşet", Lastname = "Ertaş", Genre = "Türk Halk Müziği / Türk Sanat Müziği", ReleaseYear = 1960, AlbumSales = 2000000 }

            };

            // Adı 'cwS' ile başlayan şarkıcılar


            Console.WriteLine("s ile başlayan şarkıcalar");
            var s = artists.Where(s => s.Name.StartsWith("s", StringComparison.OrdinalIgnoreCase));

            foreach (var item in s)
            {
                Console.WriteLine($"{item.Name} {item.Lastname}");
            }
            Console.WriteLine("Albüm satışları 10 milyon'un üzerinde olan şarkıcılar");
            //Albüm satışları 10 milyon'un üzerinde olan şarkıcılar

            var sales = artists.Where(s => s.AlbumSales > 10000000);

            foreach (var item in sales)
            {
                Console.WriteLine($"{item.Name} {item.Lastname} - {item.AlbumSales} sales");
            }

            Console.WriteLine("---------2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar--------------------");

            //2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar. ( Çıkış yıllarına göre gruplayarak, alfabetik bir sıra ile yazdırınız.

            var releaseAndGenre = artists.Where(b => b.ReleaseYear <= 2000 && b.Genre == "Pop")
                                          .OrderBy(b => b.Name)
                                          .GroupBy(b => b.ReleaseYear);

            foreach (var group in releaseAndGenre) {

                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine($"{item.Name} {item.Lastname} - {item.ReleaseYear}");

                }
            }

            Console.WriteLine("--------En çok albüm satan şarkıcı-------------");
                //En çok albüm satan şarkıcı

                var topArtist = artists.OrderByDescending(a => a.AlbumSales).FirstOrDefault();

                Console.WriteLine($"{topArtist.Name} {topArtist.Lastname} {topArtist.AlbumSales} ");



                Console.WriteLine("-----En yeni çıkış yapan şarkıcı ve en eski çıkış yapan şarkıcı----------------");

                //En yeni çıkış yapan şarkıcı ve en eski çıkış yapan şarkıcı

                var newAndOld = artists.Where(a => a.ReleaseYear == artists.Max(x => x.ReleaseYear) || a.ReleaseYear == artists.Min(y => y.ReleaseYear))
                                        .OrderBy(g => g.Name);     //okuması biraz zor oldu yada sıralıp tek tek bir değişkene atanabilir.
                                                                   //ilk a ile çıkış yıllarını maximum ve minimum olarak alıp, sonra bu yıllara göre filtreleme yapıldı.

                foreach (var item in newAndOld)                 
                    Console.WriteLine($"{item.Name} {item.Lastname} - {item.ReleaseYear}");
                }

            }



        }
    
