using System;

namespace controlStructure
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("lütfen bir sayı giriniz ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number > 10)
            {
                Console.WriteLine("giren sayı 10 dan büyüktür");
            }

            else if (number == 10)
            {
                Console.WriteLine("girilen sayı 10'a eşittir");
            }

            else { Console.WriteLine("girilen sayı 10dan küçüktür"); }

            if (number % 2 == 0)
            {
                Console.WriteLine(
                "giren sayı çifttir");
            }
            else { Console.WriteLine("girilen sayı tektir"); }
        }
    }
}