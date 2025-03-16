class EternalGoal : Goal
{
    private int _numComplete = 0;

    public EternalGoal(int numComplete, string goalName, string goalDescription, int pointValue, bool isComplete) : base(goalName, goalDescription, pointValue, isComplete)
    {
        _numComplete = numComplete;
    }
    public EternalGoal() : base()
    {
        _numComplete = 0;
    }


    public int getNumComplete()
    {
        return _numComplete;
    }
    public override int MarkComplete()
    {
        Console.WriteLine($"Congratulations! You have earned {GetPointValue()} points!");
        return GetPointValue();
    }
}