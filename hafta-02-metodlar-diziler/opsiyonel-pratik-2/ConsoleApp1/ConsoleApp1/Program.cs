double urunFiyatlari()
{
    Console.WriteLine("lütfen 3 adet ürün fiyatı girin ");
    Console.WriteLine("birinci ürün");
   double sayi1 = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("ikinci ürün");
    double sayi2 = Convert.ToDouble(Console.ReadLine());                //ürünlerin toplamını ekrana yazdıran method
    Console.WriteLine("üçüncü ürün");
    double sayi3 = Convert.ToDouble(Console.ReadLine());

    double toplam = sayi1 + sayi2 + sayi3;
    Console.WriteLine($"ürünlerin toplam indirimsiz fiyatı > {toplam}");

    return toplam;
}
void indirim(double indirim)
{
    indirim -=indirim *0.20;

    Console.WriteLine($"ürünlerin toplam fiyatı üzerinden %20 indirim uygulanmıştır indirimli fiyat >{indirim}  ");

    //ürünlerin toplam fiyatı üzerinden %20 indirim uygulayan method
}

void indirimVeTotal()
{
    Console.WriteLine("lütfen toplam ürün fiyatı ve indirim miktarı girin");
    Console.WriteLine("toplam ürün fiyatını aşşağı girin");
     double sayi1 = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("uygulanmak istenen indirim miktarını aşşağı girin");  //ürün fiyatı üzerinden indirim uygulayan method
    double sayi2 = Convert.ToDouble(Console.ReadLine());

    sayi1 -= (sayi1 * sayi2) / 100;

    Console.WriteLine($"uygulanan indirim sonrası ürün fiyatı > {sayi1}");
}


 double toplamfiyat = urunFiyatlari();

 indirim(toplamfiyat);

indirimVeTotal();