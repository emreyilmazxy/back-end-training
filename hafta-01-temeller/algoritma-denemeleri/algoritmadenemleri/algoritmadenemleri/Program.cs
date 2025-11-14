for (int i =1; i <=10; i++) 
{

    Console.WriteLine($"{i} kendime inanıyorum ben bu işi hallederim");
}

Console.WriteLine();

for (int i = 1; i <= 20; i++)
{

    Console.WriteLine($"{i}");
}

for (int i = 0; i <= 20; i+=2)
{

    Console.WriteLine($"{i}");
}

//aradaki ardaşık sayıların toplamı 
int sonuc = 0;
for (int i = 51; i < 150; i++)
{
    sonuc += i;
    Console.WriteLine($"{sonuc}");
}
//tek ve çift sayıların topları ayrı ayrı verildi 1 ve 120 dahil edilmemiştir 
int oddNumber = 0;
int evenNumber = 0;
for (int i = 3; i < 120; i += 2)
{
    oddNumber += i;

}
for (int i = 0; i < 120; i += 2)
{
    evenNumber += i;

}
Console.WriteLine($"tek sayıların toplamı {oddNumber}");
Console.WriteLine($"çift sayıların toplamı {evenNumber}");












