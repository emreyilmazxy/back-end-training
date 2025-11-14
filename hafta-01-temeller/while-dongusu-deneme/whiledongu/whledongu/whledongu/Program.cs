int sayi;
do
{
    Console.WriteLine("Lütfen bir sayı girin: ");
    sayi = Convert.ToInt32(Console.ReadLine());

    if (sayi <= 5)
    {
        Console.WriteLine("Lütfen 5'ten büyük bir sayı girin.");
    }
} while (sayi <= 5);

Console.WriteLine("Tebrikler, girdiğiniz sayı 5'ten büyük!");