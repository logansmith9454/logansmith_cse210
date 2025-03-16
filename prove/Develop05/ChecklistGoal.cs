using System.Numerics;
using System.Reflection;

class ChecklistGoal : Goal
{
    private int _completedCount;
    private int _targetCount;
    private int _bonusPoints;


    public ChecklistGoal(int completedCount, int targetCount, int bonusPoints, string goalName, string goalDescription, int pointValue, bool isComplete) : base(goalName, goalDescription, pointValue, isComplete)
    {
        _completedCount = completedCount;
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
    }

    public ChecklistGoal() : base()
    {
        _completedCount = 0;

        bool inputPass = false;
        while (inputPass == false)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            string _targetString = Console.ReadLine();
            try
            {
                _targetCount = Convert.ToInt32(_targetString);
                inputPass = true;
            }
            catch
            {
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }
        }
        inputPass = false;
        while (inputPass == false)
        {
            Console.Write("What is the bonus for accomplishing it that many times? ");
            string _bonusString = Console.ReadLine();
            try
            {
                _bonusPoints = Convert.ToInt32(_bonusString);
                inputPass = true;
            }
            catch
            {
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }
        }

    }

    public int GetCompletedCount()
    {
        return _completedCount;
    }

    public int GetTargetCount()
    {
        return _targetCount;
    }

    public int GetBonusPoints()
    {
        return _bonusPoints;
    }


    public override int MarkComplete()
    {
        if (GetIsComplete() == true)
        {
            Console.WriteLine("You have already accomplished this goal.");
            return 0;
        }
        else
        {
            _completedCount++;
            if (_completedCount == _targetCount)
            {
                SetIsComplete(true);
                Console.WriteLine($"Congratulations! You have earned {GetPointValue() + _bonusPoints} points!");
                return GetPointValue() + _bonusPoints;
            }
            else
            {
                Console.WriteLine($"Congratulations! You have earned {GetPointValue()} points!");
                return GetPointValue();
            }
        }
    }

    public override void Display()
    {
        base.Display();
        Console.Write($" -- Currently completed: {_completedCount}/{_targetCount}");
    }
}