using System;

class Program
{
    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        bool stop = false;
        while (stop == false)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Breathing activity");
            Console.WriteLine(" 2. Reflection activity");
            Console.WriteLine(" 3. Listing activity");
            Console.WriteLine(" 4. Quit");
            Console.Write("Enter your choice: ");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Breathe breatheExercise = new Breathe();
                breatheExercise.MainLoop();
            }
            else if (userInput == "2")
            {
                Reflection reflectionExercise = new Reflection();
                reflectionExercise.MainLoop();
            }
            else if (userInput == "3")
            {
                Listing listingExercise = new Listing();
                listingExercise.MainLoop();
            }
            else if (userInput == "4")
            {
                stop = true;
            }
        }
    }
}