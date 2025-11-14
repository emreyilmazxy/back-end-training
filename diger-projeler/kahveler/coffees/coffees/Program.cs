
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<string> coffeeOptions = new List<string>();

        Console.WriteLine("5 farklı kahve ismi giriniz.");

        for (int i = 0; i < 5; i++) //for döngüsü ile 5 defa (0'dan 4'e kadar) aynı işlemi yapıcam
        {
            Console.Write($"Kahve {i + 1}: "); //i+1 çünkü i, 0 ile başlar 4'te biter 1'den 5'e kadar olucak.
            coffeeOptions.Add(Console.ReadLine());//girilen değerleri Add metoduyla listeye ekliyorum
        }

        Console.WriteLine("Girilen kahve isimleri:");
        foreach (string coffee in coffeeOptions) //foreach döngüsüyle listedeki elemanları yazdırıyorum.
        {
            Console.WriteLine(coffee);
        }
    }
}
