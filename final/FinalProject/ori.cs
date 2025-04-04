class Ori : Edge
{
    public Ori() : base()
    {

    }

    public Ori(char location, bool orientation) : base(location, orientation) { }

    public Ori(Ori oriEdge) : base(oriEdge.GetLocation(), oriEdge.GetOrientation()) { }


    public void SetLocation(char NewLocation, bool NewOrientation)
    {
        SetLocation(NewLocation);
        SetOrientation(NewOrientation);
    }


}