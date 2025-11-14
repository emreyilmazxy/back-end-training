

using System;

class Program
{
    static public void SarkiSozu()
    {
        Console.WriteLine("yaprak döker bir yanımız,bir yanımız bahar bahçe. "); // şark metodu
    }

    static  int KalanSayi( ) 
    {
        Random random = new Random();
         int rndNumber = random.Next(1, 20) % 2; // 1 ile 20 arasında rastgele bir sayı üretir
        return rndNumber;
    }

    static public int carpma(int a, int b) // çarpma metodu 
    {
         return  a*b;
    
    }

    static public void name(string isim, string soyisim) // isim ve soyisim metodu tanımlama
    {
        Console.WriteLine("İsim: " + isim);
        Console.WriteLine("Soyisim: " + soyisim);

    }
     static void Main(string[] args)   // main metodu

    {
        int ekran = KalanSayi();
   SarkiSozu(); 
        Console.WriteLine(ekran);
   
    carpma(5, 6); // çarpma metodunu çağırdık
        Console.WriteLine("Çarpma sonucu: " + carpma(5, 6)); // çarpma metodunu çağırdık ve sonucu ekrana yazdırdık
        
        name("emre", "yılmaz"); // isim ve soyisim metodunu çağırdık

    }
    
    
}