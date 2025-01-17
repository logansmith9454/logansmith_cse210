using System;

class Program
{
    static void Main(string[] args)
    {
        int number = 1;
        int sum = 0;
        double average;
        int largest;
        List<int> numberList = new List<int>();
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numberList.Add(number);
            }
        } while (number != 0);
        Console.WriteLine("It is finished");
        foreach (int num in numberList)
        {
            sum += num;
        }
        average = sum / numberList.Count();
        numberList.Sort();
        largest = numberList.Last();
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");

    }
}