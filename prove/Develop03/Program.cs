using System;

class Program
{
    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        Scripture scripture = new Scripture();

        bool quit = false;
        while (quit == false)
        {
            scripture.DisplayScripture();
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string userInput = Console.ReadLine();
            if (userInput == "quit")
            {
                quit = true;
            }
            else
            {
                scripture.RemoveWord();
                scripture.DisplayScripture();
            }

            if (scripture.IsFinished())
            {
                quit = true;
            }
        }
    }
}