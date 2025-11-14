
//kullanıcının başka bir tatil planlamak isteyip istemediğini tutacağım değer
string answer = "";
//uygulamaya ilk girdiğinde answer boş bir string olacağı için (uygulama bir kez çalıştıktan sonra değeri atayacağım) boş olması durumunda ve uygulamanın sonunda evet yeni bir tatil planlamak istiyorum derse gerekli sorular sorulur.
while (answer == "evet" || answer == "")
{
    Console.WriteLine("Gitmek istediğiniz lokasyonu seçin:\n1 - Bodrum (Paket başlangıç fiyatı 4000 TL) \n2 - Marmaris (Paket başlangıç fiyatı 3000 TL) \n3 - Çeşme (Paket başlangıç fiyatı 5000 TL)");
    string location = Console.ReadLine().ToLower();

    while (location != "marmaris" && location != "bodrum" && location != "çeşme")
    {
        //istenilen değerleri girmediği sürece tekrar girmesini istiyorum.
        Console.WriteLine("Geçersiz değer girdiniz lütfen seçeneklerde olan lokasyonlardan birini giriniz: ");
        location = Console.ReadLine().ToLower();
    }

    Console.WriteLine("Kaç kişilik bir tatil planlıyorsunuz?: ");
    int number = Convert.ToInt32(Console.ReadLine());

    while (number < 0)
    {
        //sayıyı eksili bir değer girmesi halinde yeniden girmesini istiyorum
        Console.Write("Lütfen geçerli bir sayı giriniz: ");
        number = Convert.ToInt32(Console.ReadLine());
    }
    Console.WriteLine("Ulaşım için 2 seçeneğimiz var: \n1 - Kara yolu ( Kişi başı ulaşım tutarı gidiş-dönüş 1500 TL ) \n2 - Hava yolu ( Kişi başı ulaşım tutarı gidiş-dönüş 4000 TL) ");
    Console.WriteLine("Lütfen yukarıdaki seçeneklerden bir tanesini seçiniz (1/2): ");
    int transport = Convert.ToInt32(Console.ReadLine());

    while (transport != 1 && transport != 2)
    {
        //ulaşım için geçersiz bir değer girerse yeniden girmesini istiyorum
        Console.Write("Lütfen geçerli bir sayı giriniz (1/2): ");
        transport = Convert.ToInt32(Console.ReadLine());
    }
    //location ücreti ve transport ücretleri için değer tanımlıyorum
    int locationCost;
    int transportCost;
    //gerekli atamalar yapılıyor
    if (location == "bodrum")
    {
        locationCost = 4000;
    }
    else if (location == "marmaris")
    {
        locationCost = 3000;
    }
    else
    {
        locationCost = 5000;
    }

    if (transport == 1)
    {
        transportCost = 1500;
    }
    else
    {
        transportCost = 4000;
    }
    //toplam fiyat hesaplanıyor
    int cost = (locationCost * number) + (transportCost * number);
    Console.WriteLine("Toplam ücret: " + cost);
    //başka bir tatil planlamak isteyip istemediğini soruyorum
    Console.WriteLine("Başka bir tatil planlamak ister misiniz (evet/hayır)");
    answer = Console.ReadLine().ToLower();
    while (answer != "evet" && answer != "hayır")
    {
        Console.WriteLine("Lütfen geçerli bir değer giriniz (evet/hayır)");
        answer = Console.ReadLine().ToLower();
    }
}
//answer'ın hayır olması durumunda iyi günler mesajı
Console.WriteLine("İyi günler..");