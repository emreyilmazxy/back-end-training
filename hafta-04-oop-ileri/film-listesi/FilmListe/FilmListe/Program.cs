using Imdb;

public class Program
{
    public static void Main(string[] args)
    {
        List<Movie> movies = new List<Movie>();

        string choice;

        while (true)
        {
            Console.WriteLine("Film adı: ");
            string name = Console.ReadLine();
            Console.WriteLine("IMDB puanı: ");
            double imdb;
            bool isValid = double.TryParse(Console.ReadLine(), out imdb);
            while (!isValid || imdb < 0.0 || imdb > 10.0)
            {
                Console.WriteLine("Geçerli bir IMDB puanı giriniz :");
                isValid = double.TryParse(Console.ReadLine(), out imdb);

            }
            Movie movie = new Movie(name, imdb);
            movies.Add(movie);

            Console.WriteLine("Başka bir film oluşturmak ister misiniz (evet/hayır):");
            choice = Console.ReadLine();
            if (choice != "evet")
            {
                break;

            }
        }


        Console.WriteLine("Tüm Filmler:");
        foreach (var i in movies)
        {
            Console.WriteLine(i.Name);
        }
        Console.WriteLine("IMDB 4-9 arası filmler: ");
        foreach (var i in movies)
        {
            if (i.Imdb > 4 && i.Imdb < 9)
            {
                Console.WriteLine(i.Name);

            }
        }
        Console.WriteLine("İsmi A ile başlayan filmler: ");
        foreach (var i in movies)
        {
            if (i.Name.ToLower().StartsWith("a"))
            {
                Console.WriteLine("Film: " + i.Name + " Imdb puanı: " + i.Imdb);

            }
        }


    }
}
