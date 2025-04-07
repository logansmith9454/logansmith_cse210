class Edge
{
    private char _location;
    private bool _orientation;

    public Edge()
    {
        _location = 'a';
        _orientation = true;
    }

    public Edge(char location, bool orientation)
    {
        _location = location;
        _orientation = orientation;
    }

    public char GetLocation()
    {
        return _location;
    }

    public void SetLocation(char location)
    {
        _location = location;
    }

    public bool GetOrientation()
    {
        return _orientation;
    }

    public void SetOrientation(bool orientation)
    {
        _orientation = orientation;
    }

    public void Move(char location, bool keepOrientation)
    {
        _location = location;
        if (!keepOrientation)
        {
            _orientation = !_orientation;
        }
    }

    public void Flip()
    {
        _orientation = !_orientation;
    }
}