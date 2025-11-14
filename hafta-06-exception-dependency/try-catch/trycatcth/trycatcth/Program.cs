

using trycatcth;

try
{
    Console.WriteLine("sayi gir");
    int sayi = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine(sayi * sayi);
}
catch (Exception ex)
{

    Console.WriteLine("geçersiz giriş! lütfen bir sayı giriniz");
}

//Users user = new Users();
//try
//{
// user.setAge(-1);                    burayı fazladan pratik yaptım sadece

//}
//catch (UserAgeExeption ex)
//{
//    Console.WriteLine(ex.Message);

//}
