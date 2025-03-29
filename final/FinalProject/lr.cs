class LR : Edge
{
    private string _solvedLocation;

    public LR() : base()
    {
        _solvedLocation = "";
    }

    public LR(string location, bool orientation, string solvedLocation) : base(location, orientation)
    {
        _solvedLocation = solvedLocation;
    }

    public string GetSolvedLocation()
    {
        return _solvedLocation;
    }
}