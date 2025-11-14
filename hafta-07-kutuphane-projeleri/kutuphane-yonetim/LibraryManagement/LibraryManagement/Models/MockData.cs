namespace LibraryManagement.Models
{
    public class MockData
    {
       public static List<Author> authors = new List<Author>
{
    new Author { Id = 1, FirstName = "Sabahattin", LastName = "Ali", DateOfBirth = new DateTime(1907, 2, 25) },
    new Author { Id = 2, FirstName = "Ahmet Hamdi", LastName = "Tanpınar", DateOfBirth = new DateTime(1901, 6, 23) },
    new Author { Id = 3, FirstName = "Yaşar", LastName = "Kemal", DateOfBirth = new DateTime(1923, 10, 6) },
    new Author { Id = 4, FirstName = "Yusuf", LastName = "Atılgan", DateOfBirth = new DateTime(1921, 6, 27) },
    new Author { Id = 5, FirstName = "Oğuz", LastName = "Atay", DateOfBirth = new DateTime(1934, 10, 12) }
};

      public static  List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Kürk Mantolu Madonna", AuthorId = 1, Genre = "Roman", PublishDate = new DateTime(1943, 1, 1), Isbn = "9789753638020", CopiesAvailable = 5 },
            new Book { Id = 2, Title = "Saatleri Ayarlama Enstitüsü", AuthorId = 2, Genre = "Roman", PublishDate = new DateTime(1961, 1, 1), Isbn = "9789753632127", CopiesAvailable = 3 },
            new Book { Id = 3, Title = "İnce Memed", AuthorId = 3, Genre = "Macera", PublishDate = new DateTime(1955, 1, 1), Isbn = "9789755081435", CopiesAvailable = 8 },
            new Book { Id = 4, Title = "Aylak Adam", AuthorId = 4, Genre = "Roman", PublishDate = new DateTime(1959, 1, 1), Isbn = "9789750804664", CopiesAvailable = 2 },
            new Book { Id = 5, Title = "Tutunamayanlar", AuthorId = 5, Genre = "Roman", PublishDate = new DateTime(1972, 1, 1), Isbn = "9789754700115", CopiesAvailable = 4 }
        };
    }
}
