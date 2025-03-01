class Breathe : Activity
{

    private const int _inTime = 4;
    private const int _outTime = 5;

    public Breathe() : base()
    {
        SetName("Breathing Activity");
        SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
    }

    public void MainLoop()
    {
        Console.Clear();
        Welcome();
        PromptDuration();
        GetReady();
        BreatheLoop();
    }


    public void BreatheLoop()
    {
        DateTime startBreathe = DateTime.Now;
        DateTime stopBreathe = startBreathe.AddSeconds(_duration);

        while (DateTime.Now < stopBreathe)
        {
            BreatheIn();
            BreatheOut();
        }
        EndMessage();
    }

    public void BreatheIn()
    {
        Console.Write("\n\n");
        Console.Write("Breathe in... ");
        for (int i = _inTime; i > 0; i--)
        {
            Console.Write($"\b{i}");
            Thread.Sleep(1000);
        }
        Console.Write("\b ");
    }

    public void BreatheOut()
    {
        Console.Write("\n");
        Console.Write("Breathe out... ");
        for (int i = _outTime; i > 0; i--)
        {
            Console.Write($"\b{i}");
            Thread.Sleep(1000);
        }
        Console.Write("\b ");
    }

}