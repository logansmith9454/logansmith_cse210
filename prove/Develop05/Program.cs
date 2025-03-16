using System;
using System.IO.Enumeration;


class Program
{
    static int pointTotal = 0;
    static List<SimpleGoal> simpleGoalList = new List<SimpleGoal>();
    static List<EternalGoal> eternalGoalList = new List<EternalGoal>();
    static List<ChecklistGoal> checklistGoalList = new List<ChecklistGoal>();

    static void Main(string[] args)
    {
        Menu();
    }
    static void Menu()
    {
        bool quit = false;
        while (quit == false)
        {
            Console.WriteLine($"\nYou have {pointTotal} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            bool inputPass = false;

            while (inputPass == false)
            {
                inputPass = true;

                Console.Write("Please select an option: ");

                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    CreateGoalMenu();
                }
                else if (userInput == "2")
                {
                    ListGoals();
                }
                else if (userInput == "3")
                {
                    SaveGoals();
                }
                else if (userInput == "4")
                {
                    LoadGoals();
                }
                else if (userInput == "5")
                {
                    RecordEvent();
                }
                else if (userInput == "6")
                {
                    quit = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    inputPass = false;
                }
            }
        }
    }

    static void CreateGoalMenu()
    {
        Console.Clear();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        bool inputPass = false;

        while (inputPass == false)
        {
            inputPass = true;

            Console.Write("Which type of goal would you like to create? ");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                SimpleGoal newSimple = new SimpleGoal();
                simpleGoalList.Add(newSimple);
            }
            else if (userInput == "2")
            {
                EternalGoal newEternal = new EternalGoal();
                eternalGoalList.Add(newEternal);

            }
            else if (userInput == "3")
            {
                ChecklistGoal newChecklist = new ChecklistGoal();
                checklistGoalList.Add(newChecklist);
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }

        }
    }

    static void ListGoals()
    {
        if (simpleGoalList.Count() == 0 && eternalGoalList.Count() == 0 && checklistGoalList.Count() == 0)
        {
            Console.WriteLine("You do not have any goals. Please create or load goals.");
        }
        else
        {
            Console.WriteLine("The goals so far:");
            foreach (SimpleGoal goal in simpleGoalList)
            {
                goal.Display();
                Console.WriteLine();
            }
            foreach (EternalGoal goal in eternalGoalList)
            {
                goal.Display();
                Console.WriteLine();
            }
            foreach (ChecklistGoal goal in checklistGoalList)
            {
                goal.Display();
                Console.WriteLine();
            }
        }
    }

    static void LoadGoals()
    {

        var filesDict = new Dictionary<int, string>();

        // Retrieves the filenames and stores them in the dictionary
        string[] fileList = Directory.GetFiles("C:Goals");
        int fileCounter = 0;
        Console.WriteLine();

        if (fileList.Count() != 0)
        {
            foreach (string file in fileList)
            {
                string fileName = Path.GetFileName(file);
                filesDict.Add(fileCounter, file);
                fileCounter += 1;
                Console.WriteLine($"{fileCounter}: {fileName}");
            }

            int fileCount = filesDict.Count();
            bool passingValue = false; // passingValue indicates that a valid input has been given
            int fileSelection = 0;
            while (passingValue == false) // loops until a valid input is given
            {
                Console.Write($"Select a file (1-{fileCounter}): ");
                fileSelection = int.Parse(Console.ReadLine());
                if (fileSelection > 0 && fileSelection <= fileCount)
                {
                    passingValue = true;
                }
                else
                {
                    Console.WriteLine("Invalid value. Try again.");
                }
            }
            string filePath = filesDict[fileSelection - 1];
            filePath = Path.GetFullPath(filePath); // this ensures that the filepath is correct
            string[] data = System.IO.File.ReadAllLines(filePath);
            Console.WriteLine($"File loaded: {Path.GetFileName(filePath)}");
            simpleGoalList.Clear();
            eternalGoalList.Clear();
            checklistGoalList.Clear();

            foreach (string line in data) // separates the data into lines, stores each line in a Entry class
            {
                if (!line.Contains("`"))
                {
                    try
                    {
                        pointTotal = Convert.ToInt32(line);
                    }
                    catch
                    {
                        Console.WriteLine($"Invalid file format. {line} is not an int.");
                    }
                }
                else
                {
                    string[] values = line.Split('`');
                    if (values.Length != 0)
                    {
                        string goalType = values[0];
                        if (goalType == "SimpleGoal")
                        {

                            // SimpleGoal`sim`sim desc`1`False
                            string goalName = values[1];
                            string goalDesc = values[2];
                            string points = values[3];
                            string complete = values[4];

                            int newPoints = 0;

                            try
                            {
                                newPoints = Convert.ToInt32(points);
                            }
                            catch
                            {
                                Console.WriteLine($"Invalid file format. {points} is not an int.");
                            }

                            bool isComplete = false;
                            if (complete == "True")
                            {
                                isComplete = true;
                            }
                            SimpleGoal newSimple = new SimpleGoal(goalName, goalDesc, newPoints, isComplete);
                            simpleGoalList.Add(newSimple);
                        }

                        else if (goalType == "EternalGoal")
                        {
                            // EternalGoal`et goal`et desc`2
                            string goalName = values[1];
                            string goalDesc = values[2];
                            string points = values[3];
                            string numComplete = values[4];
                            int newPoints = 0;
                            try
                            {
                                newPoints = Convert.ToInt32(points);
                            }
                            catch
                            {
                                Console.WriteLine($"Invalid file format. {points} is not an int.");
                            }

                            int newNumComplete = 0;
                            try
                            {
                                newNumComplete = Convert.ToInt32(numComplete);
                            }
                            catch
                            {
                                Console.WriteLine($"Invalid file format. {numComplete} is not an int.");
                            }

                            EternalGoal newEternal = new EternalGoal(newNumComplete, goalName, goalDesc, newPoints, false);
                            eternalGoalList.Add(newEternal);

                        }
                        else if (goalType == "ChecklistGoal")
                        {

                            string goalName = values[1];
                            string goalDescription = values[2];
                            string pointValue = values[3];
                            string bonusPoints = values[4];
                            string targetCount = values[5];
                            string completedCount = values[6];
                            string isComplete = values[7];

                            int newCompletedCount = 0;
                            try
                            {
                                newCompletedCount = Convert.ToInt32(completedCount);
                            }
                            catch
                            {
                                Console.WriteLine($"Invalid file format. {completedCount} is not an int.");
                            }

                            int newTargetCount = 0;
                            try
                            {
                                newTargetCount = Convert.ToInt32(targetCount);
                            }
                            catch
                            {
                                Console.WriteLine($"Invalid file format. {targetCount} is not an int.");
                            }

                            int newBonusPoints = 0;
                            try
                            {
                                newBonusPoints = Convert.ToInt32(bonusPoints);
                            }
                            catch
                            {
                                Console.WriteLine($"Invalid file format. {bonusPoints} is not an int.");
                            }

                            int newPointValue = 0;
                            try
                            {
                                newPointValue = Convert.ToInt32(pointValue);
                            }
                            catch
                            {
                                Console.WriteLine($"Invalid file format. {pointValue} is not an int.");
                            }

                            bool newIsComplete = false;
                            if (isComplete == "True")
                            {
                                newIsComplete = true;
                            }

                            ChecklistGoal newChecklist = new ChecklistGoal(newCompletedCount, newTargetCount, newBonusPoints, goalName, goalDescription, newPointValue, newIsComplete);
                            checklistGoalList.Add(newChecklist);

                        }
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("No journals have been saved.");
        }

    }

    static void SaveGoals()
    {
        Console.Write("Please enter the filepath (csv): ");
        string _fileName = Console.ReadLine();
        if (!_fileName.EndsWith(".csv")) // appends .csv if it is not entered by the user
        {
            _fileName += ".csv";
        }
        string _filePath = $"C:Goals/{_fileName}"; // combines the full filepath
        string _name = _fileName;
        if (File.Exists(_filePath))
        {
            Console.Write("The filepath already exists. Overwrite? (y/n): ");
            string _isOverwrite = Console.ReadLine();

            // Checks multiple possible options for "y"
            if (_isOverwrite == "y" || _isOverwrite == "Y" || _isOverwrite == "yes" || _isOverwrite == "Yes" || _isOverwrite == "1" || _isOverwrite == "true")
            {
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    writer.WriteLine(pointTotal);
                    foreach (SimpleGoal goal in simpleGoalList)
                    {
                        writer.WriteLine($"SimpleGoal`{goal.GetName()}`{goal.GetDescription()}`{goal.GetPointValue()}`{goal.GetIsComplete()}");
                    }
                    foreach (EternalGoal goal in eternalGoalList)
                    {
                        writer.WriteLine($"EternalGoal`{goal.GetName()}`{goal.GetDescription()}`{goal.GetPointValue()}`{goal.getNumComplete()}");
                    }
                    foreach (ChecklistGoal goal in checklistGoalList)
                    {
                        writer.WriteLine($"ChecklistGoal`{goal.GetName()}`{goal.GetDescription()}`{goal.GetPointValue()}`{goal.GetBonusPoints()}`{goal.GetTargetCount()}`{goal.GetCompletedCount()}`{goal.GetIsComplete()}");
                    }
                    Console.WriteLine($"File overwritten: {_fileName}");
                }
            }
            else
            {
                Console.WriteLine("File will not be overwritten.");
            }
        }
        else
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.WriteLine(pointTotal);
                foreach (SimpleGoal goal in simpleGoalList)
                {
                    writer.WriteLine($"SimpleGoal`{goal.GetName()}`{goal.GetDescription()}`{goal.GetPointValue()}`{goal.GetIsComplete()}");
                }
                foreach (EternalGoal goal in eternalGoalList)
                {
                    writer.WriteLine($"EternalGoal`{goal.GetName()}`{goal.GetDescription()}`{goal.GetPointValue()}`{goal.getNumComplete()}");
                }
                foreach (ChecklistGoal goal in checklistGoalList)
                {
                    writer.WriteLine($"ChecklistGoal`{goal.GetName()}`{goal.GetDescription()}`{goal.GetPointValue()}`{goal.GetBonusPoints()}`{goal.GetTargetCount()}`{goal.GetCompletedCount()}`{goal.GetIsComplete()}");
                }
                Console.WriteLine($"File saved: {_fileName}");
            }
        }
    }

    static void RecordEvent()
    {
        List<Goal> allGoals = new List<Goal>();
        allGoals.AddRange(simpleGoalList);
        allGoals.AddRange(eternalGoalList);
        allGoals.AddRange(checklistGoalList);
        Console.WriteLine("The goals are:");
        int i = 1;
        if (allGoals.Count() == 0)
        {
            Console.WriteLine("You do not have any goals. Please create or load goals.");
        }
        else
        {

            foreach (Goal goal in allGoals)
            {
                Console.WriteLine($"{i}. {goal.GetName()}");
                i++;
            }

            bool inputPass = false;
            int accInt = 0;
            while (inputPass == false)
            {
                Console.Write("Which goal did you accomplish? ");
                string accString = Console.ReadLine();
                try
                {
                    accInt = Convert.ToInt32(accString);
                    inputPass = true;
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }
            }


            pointTotal += allGoals[accInt - 1].MarkComplete();

        }
    }

    static void CalculatePoints()
    {

    }

}