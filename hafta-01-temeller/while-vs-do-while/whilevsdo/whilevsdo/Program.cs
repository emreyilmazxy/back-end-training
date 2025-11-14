
using System;

namespace KimMilyonerOlmakİster
{
    class Program
    {
        static void Main(string[] args)
        {

            // Bu while döngüsü, kullanıcıya soruları baştan sona tekrar sorabilmek ve
            // iki yanlış yaptığında veya tüm soruları yanıtlayıp kazandığında döngüden çıkmak için gerekli kontrol akışını sağlamaktadır.


            // BİRİNCİ SORU
            Console.WriteLine("Kim Milyoner Olmak İster Yarişmasina Hoş Geldiniz..!!");
            Console.WriteLine("2 Şikli 3 adet sorumuz var. Bunlardan 2'sine doğru cevap verirseniz 1 Milyon TL'nin Sahibi Olacaksiniz..");
            Console.WriteLine("1. Soru : Türkiye'nin Başkenti Hangisidir?");
            Console.WriteLine("A: Ankara ");
            Console.WriteLine("B: İstanbul");

            // 2. Kullanıcının girdiğini al, boşluklardan kurtul ve küçük harfe çevir
            string cevap = Console.ReadLine().Trim().ToLower();

            // 3. Geçerli seçenek mi kontrol et                     // Burda kullanicinin girdiği cevabi sinirlamak için cevabin a harfi veya b harfi haricinde                    
            if (cevap != "a" && cevap != "b")                       //birşey girilmesi durumunda hata vermesini istiyoruz. Eğer kullanici a veya b harfinden başka birşey yazarsa if komutu çalışıcak ve
            {                                                       //kullaniciya bir hata mesaji iletip return komutuyla programı kapaticak
                Console.WriteLine("Geçersiz seçim. Lütfen sadece A veya B girin.");
                return;                                             // Programı sonlandırıyoruz
            }

            //                                                      // 1. Soruda Yapmiş olduğumuz her işlemi diğer sorularda da aynisini yapiyoruz. 
            //                                                      //   dogruSayisi ve yanlisSayisi tanımlarini bir kez tanımlıyoruz.
            string dogru = "Girmiş olduğunuz cevap doğru";          // doğru cevabina bir metin tanımladık daha kolay olmasi için tekrar tekrar yazmamak için
            string yanliş = "Girmiş olduğunuz cevap yanliş";         // yanlış cevabina bir metin tanımladık daha kolay olmasi için tekrar tekrar yazmamak için
            int dogruSayisi = 0;                                    // doğru sayisini sayıcağımız için 0'dan başlayarak doğruSayisini int olarak tanımladık
            int yanlisSayisi = 0;                                   // yanlış sayisini sayıcağımız için 0'dan başlayarak yanlişSayisini int olarak tanımladık

            if (cevap == "a")                                       // birinci soru için cevap doğru mu yanlış mi diye kontrol ediyoruz.
            {                                                       // eğer cevap doğru ise dogruSayisi++ bizim dogruSayisi tanımımıza +1 ekliyor ve doğruSayisi = 1 oluyor
                Console.WriteLine(dogru);                           // eğer cevap yanliş ise else komutu çalışıyor ve yanlisSayisi++ tanımıyla bizim yanlisSayisi = 1 oluyor
                dogruSayisi++;
            }
            else  // cevap == b
            {
                Console.WriteLine(yanliş);
                yanlisSayisi++;
            }




            // İKİNCİ SORU !! 
            Console.WriteLine("***** 2 Sorumuz *****");
            Console.WriteLine("2. Soru : Kocaeli Plaka Kodu ?");
            Console.WriteLine("A: 41 ");
            Console.WriteLine("B: 34");

            // 2. Kullanıcının girdiğini al, boşluklardan kurtul ve küçük harfe çevir
            cevap = Console.ReadLine().Trim().ToLower();

            // 3. Geçerli seçenek mi kontrol et
            if (cevap != "a" && cevap != "b")
            {
                Console.WriteLine("Geçersiz seçim. Lütfen sadece A veya B girin.");
                return;
            }



            if (cevap == "a")
            {
                Console.WriteLine(dogru);
                dogruSayisi++;
            }
            else  // girdi == b
            {
                Console.WriteLine(yanliş);
                yanlisSayisi++;
            }
            if (yanlisSayisi >= 2)                                               // Kullanici eğer ilk 2 soruyu yanliş yaparsa otomatik olarak elenmiş olucak bu yüzden 
            {                                                                   // 2. sorudan sonra da if ile yanlisSayisini kontrol ediyoruz. Eğer ilk 2 soru yanliş yapildiysa yanlisSayisi = 2 olucak ve
                Console.WriteLine("2 yanliş yaptiniz, aday başarisiz sayildi.");    // kullanici elenmiş sayilacak.           

                return;                                                             // burdaki return; bu if bloğu çalıştıysa sistemin artık çalışmasina gerek olmadığını düşünüp sistemi durduruyor.                                                            
            }




            // ÜÇÜNCÜ SORU !! 
            Console.WriteLine("***** 3 Sorumuz *****");
            Console.WriteLine("3. Soru : TÜRKİYENİN EKONOMİSİ İYİ MİDİR ?");
            Console.WriteLine("A: ......... ");
            Console.WriteLine("B: UÇUYORUZ");

            // 2. Kullanıcının girdiğini al, boşluklardan kurtul ve küçük harfe çevir
            cevap = Console.ReadLine().Trim().ToLower();

            // 3. Geçerli seçenek mi kontrol et
            if (cevap != "a" && cevap != "b")
            {
                Console.WriteLine("Geçersiz seçim. Lütfen sadece A veya B girin.");
                return;  // Programı sonlandırıyoruz
            }


            if (cevap == "a")
            {
                Console.WriteLine(dogru);
                dogruSayisi++;
            }
            else  // girdi == b
            {
                Console.WriteLine(yanliş);
                yanlisSayisi++;
            }


            if (yanlisSayisi >= 2)
            {
                Console.WriteLine("2 yanliş yaptiniz, aday başarisiz sayildi.");
                return;
            }

            else
            {
                Console.WriteLine("YETERLİ SAYİDA SORUYA DOĞRU CEVAP VERDİNİZ...");
                Console.WriteLine("************KAZANDINIZ************");
                return;
            }






        }


    }
}

