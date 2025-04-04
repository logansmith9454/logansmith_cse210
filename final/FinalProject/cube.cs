class Cube
{

    private LR _lrb;
    private LR _lrd;
    private Ori _ori1;
    private Ori _ori2;
    private Ori _ori3;
    private Ori _ori4;
    private Corners _corners;
    private Centers _centers;
    private readonly Dictionary<char, char> _U_DICT = new Dictionary<char, char> { { 'a', 'b' }, { 'b', 'c' }, { 'c', 'd' }, { 'd', 'a' } };
    private readonly Dictionary<char, char> _UP_DICT = new Dictionary<char, char> { { 'a', 'd' }, { 'd', 'c' }, { 'c', 'b' }, { 'b', 'a' } };
    private readonly Dictionary<char, char> _U2_DICT = new Dictionary<char, char> { { 'a', 'c' }, { 'c', 'a' }, { 'b', 'd' }, { 'd', 'b' } };

    private readonly Dictionary<char, char> _M_DICT = new Dictionary<char, char> { { 'a', 'c' }, { 'c', 'u' }, { 'u', 'w' }, { 'w', 'a' } };
    private readonly Dictionary<char, char> _MP_DICT = new Dictionary<char, char> { { 'a', 'w' }, { 'w', 'u' }, { 'u', 'c' }, { 'c', 'a' } };
    private readonly Dictionary<char, char> _M2_DICT = new Dictionary<char, char> { { 'a', 'u' }, { 'u', 'a' }, { 'c', 'w' }, { 'w', 'c' } };
    private List<Edge> _allEdges = new List<Edge>();
    private List<LR> _lrEdges = new List<LR>();
    private List<Ori> _oriEdges = new List<Ori>();




    public Cube()
    {
        _lrb = new LR('b', true, 'b');
        _lrd = new LR('d', true, 'd');
        _ori1 = new Ori('a', true);
        _ori2 = new Ori('c', true);
        _ori3 = new Ori('u', true);
        _ori4 = new Ori('w', true);
        _corners = new Corners();
        _centers = new Centers();
        _allEdges.Add(_lrb);
        _allEdges.Add(_lrd);
        _allEdges.Add(_ori1);
        _allEdges.Add(_ori2);
        _allEdges.Add(_ori3);
        _allEdges.Add(_ori4);
        _lrEdges.Add(_lrb);
        _lrEdges.Add(_lrd);
        _oriEdges.Add(_ori1);
        _oriEdges.Add(_ori2);
        _oriEdges.Add(_ori3);
        _oriEdges.Add(_ori4);


    }

    public Cube(Corners corners, Centers centers, LR lrb, LR lrd, Ori ori1, Ori ori2, Ori ori3, Ori ori4)
    {
        _corners = corners;
        _centers = centers;
        _lrb = lrb;
        _lrd = lrd;
        _ori1 = ori1;
        _ori2 = ori2;
        _ori3 = ori3;
        _ori4 = ori4;
        _allEdges.Add(_lrb);
        _allEdges.Add(_lrd);
        _allEdges.Add(_ori1);
        _allEdges.Add(_ori2);
        _allEdges.Add(_ori3);
        _allEdges.Add(_ori4);
        _lrEdges.Add(_lrb);
        _lrEdges.Add(_lrd);
        _oriEdges.Add(_ori1);
        _oriEdges.Add(_ori2);
        _oriEdges.Add(_ori3);
        _oriEdges.Add(_ori4);
    }

    public Cube(Cube cube)
    {
        _corners = new Corners(cube._corners);
        _centers = new Centers(cube._centers);
        _lrb = new LR(cube._lrb);
        _lrd = new LR(cube._lrd);
        _ori1 = new Ori(cube._ori1);
        _ori2 = new Ori(cube._ori2);
        _ori3 = new Ori(cube._ori3);
        _ori4 = new Ori(cube._ori4);
        _allEdges.Add(_lrb);
        _allEdges.Add(_lrd);
        _allEdges.Add(_ori1);
        _allEdges.Add(_ori2);
        _allEdges.Add(_ori3);
        _allEdges.Add(_ori4);
        _lrEdges.Add(_lrb);
        _lrEdges.Add(_lrd);
        _oriEdges.Add(_ori1);
        _oriEdges.Add(_ori2);
        _oriEdges.Add(_ori3);
        _oriEdges.Add(_ori4);
    }

    public List<LR> GetLRList()
    {
        return _lrEdges;
    }

    public List<Ori> GetOriList()
    {
        return _oriEdges;
    }

    public int GetCentersRotation()
    {
        return _centers.GetRotation();
    }

    public void MoveCorners(int rotation)
    {
        _corners.Move(rotation);
    }

    public void MoveCenters(int rotation)
    {
        _centers.Move(rotation);
    }

    public void U()
    {
        foreach (Edge edge in _allEdges)
        {
            if ("abcd".Contains(edge.GetLocation()))
            {
                edge.Move(_U_DICT[edge.GetLocation()], true);
            }
        }
        _corners.Move(1);

    }

    public void Up()
    {
        foreach (Edge edge in _allEdges)
        {
            if ("abcd".Contains(edge.GetLocation()))
            {
                edge.Move(_UP_DICT[edge.GetLocation()], true);
            }
        }
        _corners.Move(3);
    }

    public void U2()
    {
        foreach (Edge edge in _allEdges)
        {
            if ("abcd".Contains(edge.GetLocation()))
            {
                edge.Move(_U2_DICT[edge.GetLocation()], true);
            }
        }
        _corners.Move(2);
    }

    public void M()
    {
        foreach (Edge edge in _allEdges)
        {
            if ("acuw".Contains(edge.GetLocation()))
            {
                edge.Move(_M_DICT[edge.GetLocation()], false);
            }
        }
        _centers.Move(1);
    }

    public void Mp()
    {
        foreach (Edge edge in _allEdges)
        {
            if ("acuw".Contains(edge.GetLocation()))
            {
                edge.Move(_MP_DICT[edge.GetLocation()], false);
            }
        }
        _centers.Move(3);
    }

    public void M2()
    {
        foreach (Edge edge in _allEdges)
        {
            if ("acuw".Contains(edge.GetLocation()))
            {
                edge.Move(_M2_DICT[edge.GetLocation()], true);
            }
        }
        _centers.Move(2);
    }

    public void UMoves(string moves, Dictionary<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string> location)
    {
        Cube uCube = new Cube(this);
        uCube.U();
        location[uCube.CubeToTuple()] = moves + " U";

        Cube upCube = new Cube(this);
        upCube.Up();
        location[upCube.CubeToTuple()] = moves + " U'";

        Cube u2Cube = new Cube(this);
        u2Cube.U2();
        location[u2Cube.CubeToTuple()] = moves + " U2";
    }

    public void MMoves(string moves, Dictionary<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string> location)
    {
        Cube mCube = new Cube(this);
        mCube.M();
        location[mCube.CubeToTuple()] = moves + " M";

        Cube mpCube = new Cube(this);
        mpCube.Mp();
        location[mpCube.CubeToTuple()] = moves + " M'";

        Cube m2Cube = new Cube(this);
        m2Cube.M2();
        location[m2Cube.CubeToTuple()] = moves + " M2";
    }
    public void AllMoves(string moves, Dictionary<(int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)), string> location)
    {
        Cube uCube = new Cube(this);
        uCube.U();
        location[uCube.CubeToTuple()] = moves + " U";

        Cube upCube = new Cube(this);
        upCube.Up();
        location[upCube.CubeToTuple()] = moves + " U'";

        Cube u2Cube = new Cube(this);
        u2Cube.U2();
        location[u2Cube.CubeToTuple()] = moves + " U2";

        Cube mCube = new Cube(this);
        mCube.M();
        location[mCube.CubeToTuple()] = moves + " M";

        Cube mpCube = new Cube(this);
        mpCube.Mp();
        location[mpCube.CubeToTuple()] = moves + " M'";

        Cube m2Cube = new Cube(this);
        m2Cube.M2();
        location[m2Cube.CubeToTuple()] = moves + " M2";
    }

    public void DisplayCube()
    {
        Console.WriteLine($"Corners location: {_corners.GetRotation()}");
        Console.WriteLine($"Centers oriented: {_centers.GetIsOriented()}");
        foreach (LR lrEdge in _lrEdges)
            Console.WriteLine($"LR edge: {lrEdge.GetSolvedLocation()} - Location: {lrEdge.GetLocation()} - Orientation: {lrEdge.GetOrientation()}");
        _oriEdges.Sort((x, y) => x.GetLocation().CompareTo(y.GetLocation()));

        foreach (Ori oriEdge in _oriEdges)
        {
            Console.WriteLine($"Ori edge location: {oriEdge.GetLocation()} - Orientation: {oriEdge.GetOrientation()}");
        }
    }

    public void ValidateState()
    {
        bool flipParity = false;
        foreach (Edge edge in _allEdges)
        {
            if (edge.GetOrientation() == false)
            {
                flipParity = !flipParity;
            }
        }
        if (flipParity)
        {
            throw new ArgumentException("Invalid cube state (edge parity). Please restart the program and enter valid inputs.");
        }
    }

    public (int, bool, ((char, bool), (char, bool)), (bool, bool, bool, bool)) CubeToTuple()
    {
        int cornerInt = _corners.GetRotation();
        bool centerBool = _centers.GetIsOriented();
        ((char, bool), (char, bool)) lrTuple;
        lrTuple = ((_lrb.GetLocation(), _lrb.GetOrientation()), ((_lrd.GetLocation(), _lrd.GetOrientation())));
        List<(char loc, bool ori)> oriList = new List<(char, bool)>();
        foreach (Ori oriEdge in _oriEdges)
        {
            oriList.Add((oriEdge.GetLocation(), oriEdge.GetOrientation()));
        }
        oriList.Sort((x, y) => x.loc.CompareTo(y.loc));
        (bool, bool, bool, bool) oriTuple;
        oriTuple = (oriList[0].ori, oriList[1].ori, oriList[2].ori, oriList[3].ori);
        return (cornerInt, centerBool, lrTuple, oriTuple);
    }
}