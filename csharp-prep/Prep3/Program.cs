using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        string response = "yes";
        int guesses = 0;
        bool correct = false;
        string plural = "";
        do
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 11);
            correct = false;
            guesses = 0;
            do
            {
                guesses++;
                if (guesses >= 2)
                {
                    plural = "es";
                }
                Console.Write("What is your guess? ");
                string guess = Console.ReadLine();
                int guessInt = int.Parse(guess);
                if (guessInt == number)
                {
                    correct = true;
                    Console.WriteLine($"You guessed it in {guesses} guess{plural}!");
                }
                else if (guessInt > number)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Higher");
                }
            } while (correct == false);
            Console.Write("Play again? (Yes/No): ");
            response = Console.ReadLine();
        } while (response == "yes");
    }
}