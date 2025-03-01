class Activity
{
    protected int _duration;
    private string _name;
    private string _description;
    private List<string> _animationStrings = new List<string> { "/", "-", "\\", "|" };

    public Activity()
    {

    }

    public Activity(int duration, string name, string description)
    {
        _duration = duration;
        _name = name;
        _description = description;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public void PromptDuration()
    {
        bool goodInput = false;
        while (goodInput == false)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string inputDuration = Console.ReadLine();
            bool success = int.TryParse(inputDuration, out _duration);
            if (success)
            {
                goodInput = true;
            }
        }
    }

    public void Welcome()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine($"{_description}\n");
    }

    public void Spinner(int duration)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            foreach (string symbol in _animationStrings)
            {
                Console.Write($"\b{symbol}");
                Thread.Sleep(500);
            }
            Console.Write("\b ");
        }
    }

    public void GetReady()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        Spinner(5);
    }

    public void EndMessage()
    {
        Console.WriteLine("\n\nWell done!");
        Spinner(5);
        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_name}.");
        Spinner(5);
    }
}