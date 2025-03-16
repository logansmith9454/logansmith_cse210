class SimpleGoal : Goal
{
    public SimpleGoal(string goalName, string goalDescription, int pointValue, bool isComplete) : base(goalName, goalDescription, pointValue, isComplete)
    {
    }

    public SimpleGoal() : base()
    {

    }
    public override int MarkComplete()
    {
        if (GetIsComplete() == false)
        {
            SetIsComplete(true);
            Console.WriteLine($"Congratulations! You have earned {GetPointValue()} points!");
            return GetPointValue();
        }
        else
        {
            Console.WriteLine("You have already accomplished this goal.");
            return 0;
        }
    }
}