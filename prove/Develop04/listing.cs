class Listing : Activity
{
    private int _count;
    private List<string> _promptList = new List<string> { "Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you hae helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?" };

    public Listing() : base()
    {
        SetName("Listing Activity");
        SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
    }

    public void MainLoop()
    {
        Console.Clear();
        Welcome();
        PromptDuration();
        GetReady();
        BeginListing();
        ListingLoop();
        EndMessage();
    }

    public void BeginListing()
    {
        var random = new Random();
        int promptIndex = random.Next(_promptList.Count());
        string prompt = _promptList[promptIndex];
        _promptList.RemoveAt(promptIndex);


        Console.Clear();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in:  ");
        for (int i = 5; i > 0; i--)
        {
            Console.Write($"\b{i}");
            Thread.Sleep(1000);
        }
        Console.Write("\b ");

    }

    public void ListingLoop()
    {
        Console.WriteLine();
        DateTime startListing = DateTime.Now;
        DateTime endListing = startListing.AddSeconds(_duration);

        while (DateTime.Now < endListing)
        {
            Console.Write("> ");
            Console.ReadLine();
            _count++;
        }
        Console.Write($"You listed {_count} items!");
    }
}