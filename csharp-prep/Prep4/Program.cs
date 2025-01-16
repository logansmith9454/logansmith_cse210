using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numberList = new List<int>;
        do
        {
            Console.WriteLine("Enter number: ");
            int number = Console.ReadLine();
            numberList.add(number);
        } while (number != 0)
        Console.WriteLine("It is finished");
    }
}