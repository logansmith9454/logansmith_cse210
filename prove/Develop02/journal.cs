
using System.IO;

class Journal
{
    public string _name; // the name of the journal (fileName)
    public string _filePath;
    public List<Entry> _entryList = new List<Entry>(); // a list of all Entries in the Journal
    public List<string> _promptList = new List<string>(); // a list of all prompts that are given


    public void Save()
    /*
    Asks for a filename, and then saves all Journal Entries to a .csv
    file with that name. If the filename does not exist it creates a
    new file. If it already exists, it asks if the user wants to overwrite
    the file.

    Parameters: none

    Returns: none
    */
    {
        Console.Write("Please enter the filepath (csv): ");
        string _fileName = Console.ReadLine();
        if (!_fileName.EndsWith(".csv")) // appends .csv if it is not entered by the user
        {
            _fileName += ".csv";
        }
        _filePath = $"C:..//..//..//JournalEntries/{_fileName}"; // combines the full filepath
        _name = _fileName;
        if (File.Exists(_filePath))
        {
            Console.Write("The filepath already exists. Overwrite? (y/n): ");
            string _isOverwrite = Console.ReadLine();

            // Checks multiple possible options for "y"
            if (_isOverwrite == "y" || _isOverwrite == "Y" || _isOverwrite == "yes" || _isOverwrite == "Yes" || _isOverwrite == "1" || _isOverwrite == "true")
            {
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    foreach (Entry _entry in _entryList)
                    {
                        writer.WriteLine($"{_entry._date}`{_entry._prompt}`{_entry._text}");
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
                foreach (Entry _entry in _entryList)
                {
                    writer.WriteLine($"{_entry._date}`{_entry._prompt}`{_entry._text}");
                    Console.WriteLine($"File saved: {_fileName}");
                }
            }
        }

    }

    public void DisplayJournal()
    /*
    Displays all Entries in the currently loaded Journal.

    Parameters: none

    Returns: none
    */
    {
        if (_entryList.Count() != 0)
        {
            Console.WriteLine("Journal Entries:");
            foreach (Entry _entry in _entryList)
            {
                _entry.DisplayEntry();
            }
        }
        else
        {
            Console.WriteLine("The journal is empty.");
        }
    }


    public void AddEntry()
    /*
    Adds a new Entry to the current journal.

    Parameters: none

    Returns: none
    */
    {
        Entry _currentEntry = new Entry();
        var rnd = new Random();

        _promptList.Add("Who was the most interesting person I interacted with today?");
        _promptList.Add("What was the best part of my day?");
        _promptList.Add("How did I see the hand of the Lord in my life today?");
        _promptList.Add("What was the strongest emotion I felt today?");
        _promptList.Add("If I had one thing I could do over today, what would it be?");
        _promptList.Add("What is something that I am excited to do tomorrow?");
        _promptList.Add("How did I serve someone else today?");
        _promptList.Add("What did I learn from the scriptures today?");
        _promptList.Add("What did I do today that I am the most proud of?");
        _promptList.Add("Did I meet anyone today?");
        _promptList.Add("What did I pray for today?");

        DateTime _dateTime = DateTime.UtcNow.Date; // stores the current date as the date
        string today = _dateTime.ToString("d");
        _currentEntry._date = today;
        Console.WriteLine(today);

        int _promptIndex = rnd.Next(_promptList.Count); // gets a random prompt and stores the prompt and response
        _currentEntry._prompt = _promptList[_promptIndex];
        Console.Write($"{_currentEntry._prompt}\n>");
        _currentEntry._text = Console.ReadLine();
        _entryList.Add(_currentEntry);
    }
}