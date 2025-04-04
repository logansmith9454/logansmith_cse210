class LR : Edge
{
    private char _solvedLocation;

    public LR() : base()
    {
        _solvedLocation = 'a';
    }

    public LR(char location, bool orientation, char solvedLocation) : base(location, orientation)
    {
        _solvedLocation = solvedLocation;
    }

    public LR(LR lrEdge) : base(lrEdge.GetLocation(), lrEdge.GetOrientation())
    {
        _solvedLocation = lrEdge.GetSolvedLocation();
    }

    public char GetSolvedLocation()
    {
        return _solvedLocation;
    }
}