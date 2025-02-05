using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction Fraction1 = new Fraction();
        Console.WriteLine(Fraction1.GetFractionString());
        Console.WriteLine(Fraction1.GetDecimalValue());

        Fraction Fraction2 = new Fraction(5);
        Console.WriteLine(Fraction2.GetFractionString());
        Console.WriteLine(Fraction2.GetDecimalValue());

        Fraction Fraction3 = new Fraction(3, 4);
        Console.WriteLine(Fraction3.GetFractionString());
        Console.WriteLine(Fraction3.GetDecimalValue());

        Fraction Fraction4 = new Fraction(1, 3);
        Console.WriteLine(Fraction4.GetFractionString());
        Console.WriteLine(Fraction4.GetDecimalValue());
    }
}