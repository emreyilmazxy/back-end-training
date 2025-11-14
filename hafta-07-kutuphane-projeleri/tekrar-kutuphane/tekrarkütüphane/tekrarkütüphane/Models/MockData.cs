namespace tekrarkütüphane.Models
{
    public class MockData
    {
     public static   List<Book> books = new List<Book>
{
    new Book { Id = 1, Title = "Yalnızız", AuthorId = 1, Genre = "Roman", PublishDate = new DateTime(1951, 3, 15), ISBN = 978975080, CopiesAvailable = 4 },
    new Book { Id = 2, Title = "Tutunamayanlar", AuthorId = 2, Genre = "Modern Türk Edebiyatı", PublishDate = new DateTime(1971, 6, 1), ISBN = 978975080, CopiesAvailable = 2 },
    new Book { Id = 3, Title = "Beyaz Diş", AuthorId = 3, Genre = "Macera", PublishDate = new DateTime(1906, 5, 3), ISBN = 978975140, CopiesAvailable = 7 },
    new Book { Id = 4, Title = "Sefiller", AuthorId = 4, Genre = "Klasik", PublishDate = new DateTime(1862, 4, 1), ISBN = 978975210, CopiesAvailable = 3 },
    new Book { Id = 5, Title = "1984", AuthorId = 5, Genre = "Distopya", PublishDate = new DateTime(1949, 6, 8), ISBN = 978605360, CopiesAvailable = 6 },
    new Book { Id = 6, Title = "Hayvan Çiftliği", AuthorId = 5, Genre = "Allegori", PublishDate = new DateTime(1945, 8, 17), ISBN = 978975071, CopiesAvailable = 5 }
};

        public static List<Author> authors = new List<Author>
{
    new Author { Id = 1, FirstName = "Peyami", LastName = "Safâ", DateOfBirth = new DateTime(1899, 4, 2) },
    new Author { Id = 2, FirstName = "Oğuz", LastName = "Atay", DateOfBirth = new DateTime(1934, 10, 12) },
    new Author { Id = 3, FirstName = "Jack", LastName = "London", DateOfBirth = new DateTime(1876, 1, 12) },
    new Author { Id = 4, FirstName = "Victor", LastName = "Hugo", DateOfBirth = new DateTime(1802, 2, 26) },
    new Author { Id = 5, FirstName = "George", LastName = "Orwell", DateOfBirth = new DateTime(1903, 6, 25) },
    new Author { Id = 6, FirstName = "Sabahattin", LastName = "Ali", DateOfBirth = new DateTime(1907, 2, 25) }
};


    }
}
