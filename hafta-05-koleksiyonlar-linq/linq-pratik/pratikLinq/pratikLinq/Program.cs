using System;
namespace PratikLinq
{

    public class Program
    {
        static void Main(string[] args)
        {

            //Çift olan sayılar
            List<int> numbers = new List<int> { 4, -3, 9, -1, 1, 7, -6, 2, 6, -10, 30, 18, -8, 8, 5, -2 };

            var evenNum = numbers.Where(num => num % 2 == 0);
            foreach (var number in evenNum)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("----------------------");
            //tek sayılar 
            var oddNum = numbers.Where(num => num % 2 != 0);
            foreach (var number in oddNum)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("-------------------------------");
            //pozitif sayıları 
            var positiveNum = numbers.Where(num => num > 0);
            foreach (var number in positiveNum)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("--------------");
            //negatif sayılar
            var negativeNum = numbers.Where(num => num < 0);
            foreach (var number in negativeNum)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("-----------------");
            //15 ile 22 arasındaki sayılar
            var betweenNum = numbers.Where(num => num > 15 && num < 22);
            foreach (var number in betweenNum)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("-----------------");

            //sayıların kareleri


            var squareNum = numbers.Select(num => num * num).ToList();
            foreach (var number in squareNum)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("-----------------");

            var orderAsc = squareNum.OrderBy(x => x);
            // kareleri küçükten büyüğe sıralama
            foreach (var number in orderAsc)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("-----------------");
            //grouping işlemi
            var groupedNum = numbers.GroupBy(sayi =>
            {
                if (sayi < 0)
                {
                    return "Negatif Sayılar";

                }
                else if (sayi > 0)
                { return "Pozitif Sayılar"; }

                else return "Sıfır";
            });
            foreach (var group in groupedNum)
            {
                Console.WriteLine(group.Key);
                foreach (var number in group)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }

}
