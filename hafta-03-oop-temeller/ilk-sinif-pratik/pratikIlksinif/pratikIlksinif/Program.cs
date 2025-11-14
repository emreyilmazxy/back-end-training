using pratikIlksinif;

namespace kisiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Person ogrenci1 = new Person();
            ogrenci1.ad = "Ali";
            ogrenci1.soyad = "Yılmaz";
            ogrenci1.dogumTarihi = "24.03.1993";
            
            Person ogrenci2 = new Person();
            ogrenci2.ad = "Ayşe";
            ogrenci2.soyad = "Yılmaz";
            ogrenci2.dogumTarihi = "15.03.1998";
            
            Person ogretmen = new Person();
            ogretmen.ad = "mehmet";
            ogretmen.soyad = "Yılmaz";
            ogretmen.dogumTarihi = "12.03.1980";

            Console.WriteLine($"ilk öğrenci bilgileri ad: {ogrenci1.ad} soyad:{ogrenci1.soyad} doğum tarihi:{ogrenci1.dogumTarihi} ");
           
            Console.WriteLine($"ikinci öğrenci bilgileri ad: {ogrenci2.ad} soyad:{ogrenci2.soyad} doğum tarihi:{ogrenci2.dogumTarihi} ");
            
            Console.WriteLine($" öğretmen bilgileri ad: {ogretmen.ad} soyad:{ogretmen.soyad} doğum tarihi:{ogretmen.dogumTarihi} ");
            

        }
    }
}