using polymorphism;


namespace Polymorphism
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Rectangle rectangle = new Rectangle();
            rectangle.Wide = 10;
            rectangle.Heigh = 20;
            Triangle triangle = new Triangle();
            triangle.Wide = 5;
            triangle.Heigh = 10;
            Square square = new Square();
            square.Wide = 10;
            square.Heigh = 10;
            Console.WriteLine("diktörgenin alanı >" + rectangle.AlanHesapla());
            Console.WriteLine("karenin >" + square.AlanHesapla());
            Console.WriteLine("diküçgen alanı >" + triangle.AlanHesapla());
           
        }
    }
}