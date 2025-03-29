class Ori : Edge
{
    public Ori() : base()
    {

    }

    public Ori(string location, bool orientation) : base(location, orientation)
    {

    }

    public void SetLocation(string NewLocation, bool NewOrientation)
    {
        SetLocation(NewLocation);
        SetOrientation(NewOrientation);
    }
}