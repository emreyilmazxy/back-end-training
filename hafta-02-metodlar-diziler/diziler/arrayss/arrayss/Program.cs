int[] integers = new int[10];

for (int i = 0; i < integers.Length; i++)
{
    integers[i] = i;
}

foreach (var  number in integers)
{
    Console.WriteLine(number);
}

Console.WriteLine("diziye eklemek istediğin sayıyı gir ");

bool islem = int.TryParse(Console.ReadLine(), out int sayi);

int[] yeniDizi = new int[11];

Array.Copy(integers, yeniDizi, integers.Length); //eski diziyi yeni diziye kopyaladım

yeniDizi[10] = sayi; //yeni dizinin sonuna kullanıcıdan aldığım sayıyı ekledim

Array.Sort(yeniDizi); //diziyi sıraladım
Array.Reverse(yeniDizi); //diziyi ters çevirdim

foreach (var number in yeniDizi)
{
    Console.WriteLine(number);
}

// resize method ile de olan versiyonu yaptım altta.

//Array.Resize(ref integers, 11);  //intees dizisinin boyutunu 11 elemanlı yaptım

//integers[10] = sayi; //yeni dizinin sonuna kullanıcıdan aldığım sayıyı ekledim