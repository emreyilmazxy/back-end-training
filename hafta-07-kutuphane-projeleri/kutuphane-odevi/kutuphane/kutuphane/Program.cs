using kutuphane;

namespace CalismaAlani
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Books book1 = new Books();
            book1.bookName = "insanın anlam arayışı";
            book1.name = "Viktor";
            book1.surname = "Frankl";   //parametreless constructor
            book1.pageNumber = "170";
            book1.publisher = "İş Bankası Yayınları";
            //parametreli constructor
            Books book2 = new Books("sevme sanatı", "erik", "fromm", "200", "say yayınları");
            Books book3 = new Books("insan olmak", "john&mary", "griffen", "408", "alfa yayınları");
            Books book4 = new Books("Suç ve Ceza", "Fydor", "Dostoyevski", "704", "İş Bankası Yayınları");
            Books book5 = new Books("İnsan ve Davranışı", "doğan", "cüceloğlu", "501", "remzi kitapevi");
            Books book6 = new Books("İnsan Ne ile Yaşar", "lev", "tolstoy", "80", "bilge kültür sanat");


            //class : alanlar ,özellikler, metodları içinde barındıran bir şablondur
            //property : alanların özelliklerini tanımlamak için kullanılır.kapsülleme sağlar.sınıf yapısının bozulmasını önler.
            //methodlar: sınıfın işlevselliğini artırır. belirli bir işlevi yerine getiren kod bloklarıdır.
            //constructor: sınıfın bir örneği oluşturulduğunda çalışan özel bir metoddur. sınıfın özelliklerini başlatmak için kullanılır.varsayılan değerleri atar.
        }
    }
}