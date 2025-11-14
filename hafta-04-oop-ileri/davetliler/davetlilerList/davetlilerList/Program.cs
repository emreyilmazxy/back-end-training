using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<string> davetliler = new List<string>() { "1- Bülent Ersoy", "2 - Ajda Pekkan", "3- Ebru Gündeş" };//değerlerin bir kısmını başlangıçta oluştururdum

        davetliler.Add("4- Hadise"); //bir kısmını add metoduyla ekledim
        davetliler.Add("5- Hande Yener");
        davetliler.Add("6- Tarkan");
        davetliler.Add("7- Funda Arar");
        davetliler.Add("8- Demet Akalın");

        Console.WriteLine("**Davetliler**");
        foreach (string davetli in davetliler)
        {
            Console.WriteLine(davetli);
        }

    }
}