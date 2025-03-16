abstract class Goal
{
    private string _goalName;
    private string _goalDescription;
    private int _pointValue;
    private bool _isComplete;


    public Goal(string goalName, string goalDescription, int pointValue, bool isComplete)
    {
        _goalName = goalName;
        _goalDescription = goalDescription;
        _pointValue = pointValue;
        _isComplete = isComplete;

    }
    public Goal()
    {
        Console.Write("What is the name of your goal? ");
        _goalName = Console.ReadLine();

        Console.Write("What is a short description of your goal? ");
        _goalDescription = Console.ReadLine();
        _isComplete = false;
        bool inputPass = false;
        while (inputPass == false)
        {
            Console.Write("What is the number of points awarded for completing this goal? ");
            string _pointString = Console.ReadLine();
            try
            {
                _pointValue = Convert.ToInt32(_pointString);
                inputPass = true;
            }
            catch
            {
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }

        }

    }
    public virtual void Display()
    {
        string checkbox = "";
        if (_isComplete == false)
        {
            checkbox = "[ ]";
        }
        else
        {
            checkbox = "[x]";
        }
        Console.Write($"{checkbox} {_goalName} ({_goalDescription})");
    }


    public string GetName()
    {
        return _goalName;
    }

    public string GetDescription()
    {
        return _goalDescription;
    }

    public int GetPointValue()
    {
        return _pointValue;
    }

    public bool GetIsComplete()
    {
        return _isComplete;
    }

    public void SetIsComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }

    public abstract int MarkComplete();
}