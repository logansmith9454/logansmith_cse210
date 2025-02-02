using System;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Menu();
    }



    static void Menu()
    /*
    Displays all the menu items and gets user input. This repeats in a loop
    until the user stops the program by selecting 5.

    Parameters: none

    Returns: none
    */
    {
        Console.Write("Welcome to the Journal!");

        // creates a new journal from the Journal class
        Journal currentJournal = new Journal();
        bool quit = false;
        while (quit == false)
        {
            Console.Write("\n1. New Entry\n2. Display Journal\n3. Save Journal\n4. Load Journal\n5. Quit\nSelect option: ");
            int menuChoice = int.Parse(Console.ReadLine());
            if (menuChoice == 1)
            {
                currentJournal.AddEntry();
            }
            else if (menuChoice == 2)
            {
                Console.WriteLine($"\nDisplaying journal: {currentJournal._name}");
                currentJournal.DisplayJournal();
            }
            else if (menuChoice == 3)
            {
                currentJournal.Save();
            }
            else if (menuChoice == 4)
            {
                currentJournal = Load();
            }
            else if (menuChoice == 5)
            {
                quit = true;
            }
            else
            {
                Console.WriteLine("Invalid input received. Try again.");
            }
        }
    }



    static Journal Load()
    /*
    Finds all the filenames in the journal entries folder, and asks for the user's
    choice. The selected journal is loaded into the Journal class and Entry classes.
    
    Parameters: none

    Returns:
        currentJournal (Journal): the journal that is selected and loaded
    */
    {
        // Creates a dictionary to store filenames from the journal folder
        var filesDict = new Dictionary<int, string>();

        // Retrieves the filenames and stores them in the dictionary
        string[] journalList = Directory.GetFiles("C:/Users/Smith/cse210/logansmith_cse210/prove/Develop02/JournalEntries");
        int journalCounter = 0;
        Console.WriteLine();
        Journal currentJournal = new Journal();

        if (journalList.Count() != 0)
        {
            foreach (string file in journalList)
            {
                string fileName = Path.GetFileName(file);
                filesDict.Add(journalCounter, file);
                journalCounter += 1;
                Console.WriteLine($"{journalCounter}: {fileName}");
            }

            int numberOfJournals = filesDict.Count();
            bool passingValue = false; // passingValue indicates that a valid input has been given
            int journalSelection = 0;
            while (passingValue == false) // loops until a valid input is given
            {
                Console.Write($"Select a file (1-{journalCounter}): ");
                journalSelection = int.Parse(Console.ReadLine());
                if (journalSelection > 0 && journalSelection <= numberOfJournals)
                {
                    passingValue = true;
                }
                else
                {
                    Console.WriteLine("Invalid value. Try again.");
                }
            }
            string filePath = filesDict[journalSelection];
            filePath = Path.GetFullPath(filePath); // this ensures that the filepath is correct
            string[] data = System.IO.File.ReadAllLines(filePath);
            currentJournal._name = Path.GetFileName(filePath);
            Console.WriteLine($"File loaded: {currentJournal._name}");

            foreach (string line in data) // separates the data into lines, stores each line in a Entry class
            {
                string[] values = line.Split('`');
                if (values.Length != 0)
                {
                    Entry entry = new Entry();
                    entry._date = values[0];
                    entry._prompt = values[1];
                    entry._text = values[2];
                    currentJournal._entryList.Add(entry);
                }
            }
        }
        else
        {
            Console.WriteLine("No journals have been saved.");
        }

        return currentJournal;
    }
}