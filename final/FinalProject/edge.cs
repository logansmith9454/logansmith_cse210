class Edge
{
    private string _location;
    private bool _orientation;
    public Edge()
    {
        _location = "";
        _orientation = true;
    }

    public Edge(string location, bool orientation)
    {
        _location = location;
        _orientation = orientation;
    }

    public string GetLocation()
    {
        return _location;
    }

    public void SetLocation(string location)
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

    public void Move(string location, bool keepOrientation)
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