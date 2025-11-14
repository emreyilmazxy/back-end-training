namespace Inheritance
{

    public class Program
    {
        static void Main(string[] args)
        {

            Ogrenci ogrenci = new Ogrenci();
            ogrenci.Ad = "Ali";
            ogrenci.Soyad = "Veli";
            ogrenci.OgrenciNo = 123;
            Ogretmen ogretmen = new Ogretmen();
            ogretmen.Ad = "Ayse";
            ogretmen.Soyad = "Yılmaz";
            ogretmen.Maas = 5000;

            ogretmen.ogretmenBilgileri();
            ogrenci.OgrenciBilgileri();
        }
    }
}