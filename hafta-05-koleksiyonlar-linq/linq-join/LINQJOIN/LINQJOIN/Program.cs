using System;

namespace LINQJOIN
{
    class Program
    {   static void Main(string[] args)
        {
            List<Author> authors = new List<Author>
{
    new Author { AuthorId = 1, Name = "Orhan Pamuk" },
    new Author { AuthorId = 2, Name = "Elif Şafak" },
    new Author { AuthorId = 3, Name = "Ahmet Ümit" },
    new Author { AuthorId = 4, Name = "Sabahattin Ali" },
    new Author { AuthorId = 5, Name = "Ayşe Kulin" },
    new Author { AuthorId = 6, Name = "Zülfü Livaneli" },
    new Author { AuthorId = 7, Name = "ahmet mehmet kelalaka" }  // kitap yazmayan yazar
};


            // Kitap listesi
            List<Book> books = new List<Book>
{
    new Book { BookId = 1, Title = "Masumiyet Müzesi", AuthorId = 1 },
    new Book { BookId = 2, Title = "Aşk", AuthorId = 85 },
    new Book { BookId = 3, Title = "Beyoğlu Rapsodisi", AuthorId = 3 },
    new Book { BookId = 4, Title = "Kürk Mantolu Madonna", AuthorId = 4 },
    new Book { BookId = 5, Title = "Sahipsiz Kitap", AuthorId = 99 },  
    new Book { BookId = 6, Title = "Serenad", AuthorId = 36 },
    new Book { BookId = 7, Title = "Adı: Aylin", AuthorId = 5 }
};

            //Kitapları ve yazarları birleştiren bir LINQ sorgusu oluşturun. Bu sorgu, her kitabın başlığını ve yazarının adını içermelidir.
            // Kitap ve yazarları birleştiren LINQ sorgusu

            var together = authors.Join(books, authorr => authorr.AuthorId, book => book.AuthorId ,
                                        (authorr,book) => new { 
                                        
                                        bookName = book.Title,
                                        authorName = authorr.Name
                                        });

            foreach (var item in together)
            {
                Console.WriteLine($"Kitap: {item.bookName}, Yazar: {item.authorName}");
            }


            //var togetherr = from author in authors
            //                join book in books on author.AuthorId equals book.AuthorId     SORGU YAPISI HALİ
            //                select new
            //                {
            //                    bookName = book.Title,
            //                    authorName = author.Name
            //                };

        }
    }

}