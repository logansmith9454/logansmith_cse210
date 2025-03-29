

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
    private readonly Dictionary<string, string> _U_DICT = new Dictionary<string, string> { { "a", "b" }, { "b", "c" }, { "c", "d" }, { "d", "a" } };
    private readonly Dictionary<string, string> _UP_DICT = new Dictionary<string, string> { { "a", "d" }, { "d", "c" }, { "c", "b" }, { "b", "a" } };
    private readonly Dictionary<string, string> _U2_DICT = new Dictionary<string, string> { { "a", "c" }, { "c", "a" }, { "b", "d" }, { "d", "b" } };

    private readonly Dictionary<string, string> _M_DICT = new Dictionary<string, string> { { "a", "c" }, { "c", "u" }, { "u", "w" }, { "w", "a" } };
    private readonly Dictionary<string, string> _MP_DICT = new Dictionary<string, string> { { "a", "w" }, { "w", "u" }, { "u", "c" }, { "c", "a" } };
    private readonly Dictionary<string, string> _M2_DICT = new Dictionary<string, string> { { "a", "u" }, { "u", "a" }, { "c", "w" }, { "w", "c" } };
    private List<Edge> _allEdges = new List<Edge>();
    private List<LR> _lrEdges = new List<LR>();
    private List<Ori> _oriEdges = new List<Ori>();




    public Cube()
    {
        _lrb = new LR("b", true, "b");
        _lrd = new LR("d", true, "d");
        _ori1 = new Ori("a", true);
        _ori2 = new Ori("c", true);
        _ori3 = new Ori("u", true);
        _ori4 = new Ori("w", true);
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

    public Cube(LR lrb, LR lrd, Ori ori1, Ori ori2, Ori ori3, Ori ori4)
    {
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

    public List<LR> GetLRList()
    {
        return _lrEdges;
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

    public void DisplayCube()
    {
        Console.WriteLine($"Corners location: {_corners.GetRotation()}");
        Console.WriteLine($"Centers oriented: {_centers.GetIsOriented()}");
        foreach (LR lrEdge in _lrEdges)
            Console.WriteLine($"LR edge: {lrEdge.GetSolvedLocation()} - Location: {lrEdge.GetLocation()} - Orientation: {lrEdge.GetOrientation()}");
        foreach (Ori oriEdge in _oriEdges)
        {
            Console.WriteLine($"Ori edge location: {oriEdge.GetLocation()} - Orientation: {oriEdge.GetOrientation()}");
        }
    }

    public void ValidateState()
    {

    }

    public (int, string, string) _cubeToTuple()
    {
        return (0, "A", "B");
    }
}