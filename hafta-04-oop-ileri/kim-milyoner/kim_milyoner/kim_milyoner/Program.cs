Console.WriteLine("kim milyoner olmak istere hoş geldiniz!");
Console.WriteLine(@"Kurallar: 3 sorunun en az 2 side doğru cevap verirseniz milyonersiniz.BAŞLIYORUZ!");
Console.WriteLine(@" 1-) Kızınca tüküren hayvan hangisidir ?
      A-) LAMA  B-) DEVE");
Console.WriteLine();
string answer1 = Console.ReadLine().ToLower().Trim();

int counter = 0;
if ((answer1 == "lama" || answer1 == "a"))
{
    counter++;
    Console.WriteLine("Tebrikler doğru cevap verdiniz!");
}

else
{
    Console.WriteLine("üzgünüz yanlış cevap! doğru cevap 'LAMA' ");
}
Console.WriteLine();
Console.WriteLine(@" 2-) Dünya'ya en yakın gezegen hangisidir ?
          A-) MARS   B-)MERKÜR ");
string answer2 = Console.ReadLine().ToLower().Trim();

//eğer iki soruda yanlış cevap ise bu if bloğu çalışır 
if (((answer2 == "mars" || answer2 == "a" ) && counter == 0))
{

    Console.WriteLine("üzgünüz yarışmayı kazanamadınız");
    return;
}
//ilk soru doğru cevaplandıysa veya 2 inci soru doğruysa if yapısının içine girer 

else if (((answer2 == "merkür" || answer2 == "b") || counter == 1))
{
    //ilk ve 2. soru soru olduğunda çalışır else if bloğunun içindedir. 
    if (((answer2 == "merkür" || answer2 == "b") && counter == 1))
    {
        Console.WriteLine("tebrikler 1 milyon TL kazandınız");
        return;
    }
    else if ((answer2 == "merkür" || answer2 == "b"))
    {
        Console.WriteLine("tebrikler doğru cevap");
        counter++;
    }
    else { Console.WriteLine("üzgünüm yanlış cevap verdiniz"); }
}

Console.WriteLine();
Console.WriteLine(@"3-) 5 * 2 + 8 / 2 - 2 işleminin sonucu kaçtır ?
           A-) 7      B-)12");
Console.WriteLine();
string answer3 = Console.ReadLine().ToLower().Trim();

if ((answer3 == "12" || answer3 =="b"))
{
    Console.WriteLine("tebrikler 1 milyon tl kazandınız");
}
else { Console.WriteLine("üzgünüz yarışmayı kaybettiniz"); }


