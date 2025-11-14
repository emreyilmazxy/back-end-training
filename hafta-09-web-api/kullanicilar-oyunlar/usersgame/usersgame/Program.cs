static int guess1(string mesaj)
{
    int sayi;
    bool valid;

    do
    {
        Console.WriteLine(mesaj);
        string input = Console.ReadLine();
        valid = int.TryParse(input, out sayi) && sayi >= 1 && sayi <= 100;           //method.Verifies if the user's input is valid (for 1 st game)

        if (!valid)
        {
            Console.WriteLine("Geçerli bir sayı giriniz (1 - 100 arası).");
        }

    } while (!valid);

    return sayi;
}


static int guess2(string mesaj)
{
    int sayi;
    bool valid;

    do
    {
        Console.WriteLine(mesaj);
        string input = Console.ReadLine();
        valid = int.TryParse(input, out sayi);           // method .Verifies if the user's input is valid (for 2 st PROGRAM)

        if (!valid)
        {
            Console.WriteLine("Geçerli bir sayı giriniz");
        }

    } while (!valid);

    return sayi;
}

static int guess3(string mesaj)
{
    int sayi;
    bool valid;

    do
    {
        Console.WriteLine(mesaj);
        string input = Console.ReadLine();
        valid = int.TryParse(input, out sayi) && sayi >= 0 && sayi <= 100;           //method.Verifies if the user's input is valid (for 3 st game)

        if (!valid)
        {
            Console.WriteLine("Geçerli bir sayı giriniz (0 - 100 arası).");
        }

    } while (!valid);

    return sayi;
}


Console.WriteLine("lütfen oynamak istediğiniz oyunu seçin");
Console.WriteLine("1-) Rasgele sayı bulma oyunu");
Console.WriteLine("2-) Hesap makinesi");
Console.WriteLine("3-) Ortalama bulma aracı");
string userInput = Console.ReadLine();
while (userInput != "1" && userInput != "2" && userInput != "3")             // the loop continues until a valid number is entered
{
    Console.WriteLine("lütfen geçerli bir sayı giriniz");
     userInput = Console.ReadLine();

}
if (userInput == "1")
{
    Console.WriteLine("Rasgele sayı bulma oyunu seçtiniz");
    Random random = new Random();

    int randomNumber = random.Next(1, 101);                 // generates a random number between 1 and 100
    int attempts = 0;
    int userGuess;


    userGuess = guess1("lütfen 1 ile 100 arasında bir tahminde bulunun");

    while (userGuess >= 1 && userGuess <= 100)
    {
        attempts++;

        if (userGuess > randomNumber)
        {
            Console.WriteLine($"rasgele sayı daha küçük bir sayıdır.KALAN HAK >{5-attempts}");
        }
        else if (userGuess < randomNumber)
        {
            Console.WriteLine($"rasgele sayı daha büyük bir sayıdır.KALAN HAK >{5-attempts}");
        }
        else
        {
            Console.WriteLine($"tebrikler doğru tahmin ettiniz  ");
            return;            //The return statement is used to prevent the if block from executing when the correct guess is made on the 5th attempt.
        }

        if (attempts == 5)
        {
            Console.WriteLine($"5 tahminde bulundunuz, oyunu kaybettiniz doğru sayı > {randomNumber}  ");
            return;
        }

        userGuess = guess1("lütfen 1 ile 100 arasında bir tahminde bulunun");
    }


}
else if (userInput == "2")
{
    Console.WriteLine("hesap makinesi kullanmayı seçtiniz");

    int number1 = guess2("lütfen ilk sayıyı girin");
    int number2 = guess2("lütfen ikinci sayıyı girin");

    Console.WriteLine(@"lütfen işlem seçin
   toplama için '+' 
   çıkarma için '-'
   bölme için '/' 
   çarpma için '*'");

    string operation = Console.ReadLine();
    if (operation == "+")

        Console.WriteLine($"toplama işlemi sonucu >{number1 + number2}");
    else if (operation == "-")
        Console.WriteLine($"çıkarma işlemi sonucu >{number1 - number2}");
    else if (operation == "/")
    {
        if (number2 == 0)   // Check if the denominator is zero before performing division

        {
            Console.WriteLine("bir sayı sıfıra bölünemez");
            return;
        }
        Console.WriteLine($"bölme işlemi sonucu >{number1 / number2}");
    }
    else if (operation == "*")
        Console.WriteLine($"çarpma işlemi sonucu >{number1 * number2}");
    else
        Console.WriteLine("geçersiz işlem");
}

else if (userInput == "3")
{
    Console.WriteLine("ortalama hesaplama aracını seçtiniz");

    int not1 = guess3("lütfen 1. notu girin");
    int not2 = guess3("lütfen 2. notu girin");
    int not3 = guess3("lütfen 3. notu girin");

    double average = (not1 + not2 + not3) / 3.0; // Calculate the average of the three grades

    if (average >= 90 && average <= 100)

        Console.WriteLine($"ders notunuz AA ORTALAMA > {average}");

    else if (average >= 85 && average <= 89)

        Console.WriteLine($"ders notunuz BA ORTALAMA > {average}");
    else if (average >= 80 && average <= 84)

        Console.WriteLine($"ders notunuz BB ORTALAMA > {average}");
    
    else if (average >= 75 && average <= 79)

        Console.WriteLine($"ders notunuz CB ORTALAMA > {average}");
    
    else if (average >= 70 && average <= 74)

        Console.WriteLine($"ders notunuz CC ORTALAMA > {average}");
    
    else if (average >= 65 && average <= 69)

        Console.WriteLine($"ders notunuz DC ORTALAMA > {average}");
    
    else if (average >= 60 && average <= 64)

        Console.WriteLine($"ders notunuz DD ORTALAMA > {average}");
    
    else if (average >= 55 && average <= 59)

        Console.WriteLine($"ders notunuz FD ORTALAMA > {average}");
    
    else
        Console.WriteLine($"ders notunuz FF ORTALAMA > {average}");
}   


