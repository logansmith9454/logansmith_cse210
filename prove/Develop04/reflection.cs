class Reflection : Activity
{
    private List<string> _promptList = new List<string> { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless." };
    private List<string> _questionList = new List<string> { "Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?" };

    public Reflection() : base()
    {
        SetName("Reflection Activity");
        SetDescription("This activity will help you reflect on times in your life when you have shown strength and resilience. THis will help you recognize the power you have and how you can use it in other aspects of your life.");
    }

    public void MainLoop()
    {
        Console.Clear();
        Welcome();
        PromptDuration();
        GetReady();
        ReflectionLoop();
        EndMessage();
    }


    public void ReflectionLoop()
    {
        var random = new Random();
        int promptIndex = random.Next(_promptList.Count());
        string prompt = _promptList[promptIndex];
        _promptList.RemoveAt(promptIndex);

        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.Write("Now ponder on each of the following questions as they relate to this experence.\nYou may begin in:  ");
        for (int i = 5; i > 0; i--)
        {
            Console.Write($"\b{i}");
            Thread.Sleep(1000);
        }
        Console.Clear();

        DateTime startQuestion = DateTime.Now;
        DateTime stopQuestion = startQuestion.AddSeconds(_duration);

        while (DateTime.Now < stopQuestion)
        {
            QuestionLoop();
            Console.WriteLine();
        }
    }

    public void QuestionLoop()
    {
        var random = new Random();
        int questionIndex = random.Next(_questionList.Count());
        string question = _questionList[questionIndex];
        _questionList.RemoveAt(questionIndex);
        Console.Write($"{question}  ");
        Spinner(15);

    }
}