using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        TextInfo textInfo = new CultureInfo("tr-TR", false).TextInfo;
        string name = textInfo.ToTitleCase("ahmet mehmet");
        Console.WriteLine(name);  // Ahmet Mehmet
    }
}
