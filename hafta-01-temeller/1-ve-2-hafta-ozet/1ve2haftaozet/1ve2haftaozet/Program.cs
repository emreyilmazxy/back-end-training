using System;

// 1-) aşağıdaki çıktıyı yazan program

// Console.WriteLine(@"Merhaba
// Nasılsın ?
// İyiyim
// Sen nasılsın ?");

//-------------------------------------------------

// 2-)Bir adet metinsel , bir adet tam sayı verisi tutmak için 2 adet değişken tanımlayınız. Bunların değerlerini atayıp , ekrana yazdırınız.

// string name = "emre";
// int age = 32;
// Console.WriteLine(name);
// Console.WriteLine(age);

//-----------------------------------------------------

// 3-) Rastgele bir sayı üretip , ekrana yazdırınız.

// int sayi = new Random().Next(1, 100);
// Console.WriteLine(sayi);

//----------------------------------------------------------

// 4-) rasgele sayı üretip kalanı ekrana yazdırınız.

// int sayi1 = new Random().Next(1, 100);  
// int kalan = sayi1 % 3;
// Console.WriteLine(kalan);

//--------------------------------------

// 5-)  Kullanıcıya yaşını sorup , 18'den büyükse "+" küçükse "-" yazdıran bir uygulama.

// Console.WriteLine("kaç yaşındasın gardaş?");
// int sayi1 = Convert.ToInt32(Console.ReadLine());

// if (sayi1 > 18)
// {
//     Console.WriteLine("+");
// }
// else
// {
//     Console.WriteLine("-");
// }

//------------------------------------------------------

// 6-) Ekrana 10 defa " Sen Vodafone gibi anı yaşarken , ben Turkcell gibi seni her yerde çekemem." yazan bir uygulama.

// for (int i = 0; i < 10; i++)
// {
//     Console.WriteLine("Sen Vodafone gibi anı yaşarken , ben Turkcell gibi seni her yerde çekemem.");
// }

//-----------------------------------------

// 7 - Kullanıcıdan 2 adet metinsel değer alıp "Gülse Birsel" , "Demet Evgar" , bunların yerlerini değiştiriniz.

// Console.WriteLine("ilk isim soy isim gir ");
// string ilkIsim = Console.ReadLine();

// Console.WriteLine("ikinci isim soy isim gir ");
// string ikinciIsim = Console.ReadLine();

// string[] name = { ilkIsim, ikinciIsim };
// Array.Reverse(name);

// foreach (string isimler in name)
// {
//     Console.WriteLine(isimler);
// }

//------------------------------------------------------

// 8 - Değer döndürmeyen ismi BenDegerDondurmem olan bir metot tanımlayınız.
// Ekrana "Ben değer döndürmem , benim bir karşılığım yok , beni değişkene atamaya çalışma" yazsın.

/*class Program
{
    static void BenDegerDondurmem()
    {
        Console.WriteLine("Ben değer döndürmem , benim bir karşılığım yok , beni değişkene atamaya çalışma");
    }

    static void Main(string[] args)
    {
        BenDegerDondurmem(); // Metot çağrısı burada yapılır
    }
}
*/
//-------------------------------------------------------       

//9 - İki sayıyı alıp bunların toplam değerini geriye döndüren bir metot yazınız.

/*class Program
{
     static int Topla( int a ,int b)
    {
        return a + b;

    }

    static void Main(string[] args)
    {
        
        Console.WriteLine(Topla(5, 10));
    }
}*/

//-------------------------------------------------

//   10 - Kullanıcıdan true ya da false değeri alıp string bir değer dönen bir metot tanımlayınız.

using System;

/*class Program
{
    static string DurumaGoreYanit(bool durum)
    {
        if (durum)
            return "Kullanıcı evet dedi.";
        else
            return "Kullanıcı hayır dedi.";
    }

    static void Main(string[] args)
    {
        Console.Write("true ya da false yaz: ");
        bool kullaniciGirisi = Convert.ToBoolean(Console.ReadLine());

        string sonuc = DurumaGoreYanit(kullaniciGirisi);
        Console.WriteLine(sonuc);
    }
}*/

//-------------------------------------
//11 - 3 Kişinin yaşlarını alıp en yaşlı olanının yaş bilgisini dönen bir metot yazınız.

/*{
using System;

class Program
    static int EnYasliyiBul(int yas1, int yas2, int yas3)
    {
        return Math.Max(yas1, Math.Max(yas2, yas3));
    }

    static void Main(string[] args)
    {
        Console.WriteLine("1. kişinin yaşını girin:");
        int yas1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("2. kişinin yaşını girin:");
        int yas2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("3. kişinin yaşını girin:");
        int yas3 = Convert.ToInt32(Console.ReadLine());

        int enYasli = EnYasliyiBul(yas1, yas2, yas3);
        Console.WriteLine("En yaşlı kişinin yaşı: " + enYasli);
    }
}*/



//12 - Kullanıcıdan sınırsız sayıda sayı alıp , bunlardan en büyüğünü ekrana yazdıran ve aynı zamanda geriye dönen bir metot yazınız.

/*using System;
class Program
{

     static int EnBuyukSayiBul(params int[] sayilar)
    {
        while (true)
        {

           int sayi = Convert.ToInt32(Console.ReadLine();
            if (sayi == 0)

        }
    }
        static void Main(string[] args)

    {


tek mi çift mi 


    }
}


using System;

class Program
{
    static bool TekMi(int sayi)
    {
        return sayi % 2 != 0;
    }

    static void Main(string[] args)
    {
        Console.Write("Bir sayı girin: ");
        int sayi = Convert.ToInt32(Console.ReadLine());

        bool sonuc = TekMi(sayi);

        Console.WriteLine("Sayı tek mi? " + sonuc);
    }
}