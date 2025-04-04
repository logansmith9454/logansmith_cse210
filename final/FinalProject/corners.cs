class Corners : Cycle
{
    public Corners() : base() { }

    public Corners(int rotation) : base(rotation) { }

    public Corners(Corners corners) : base(corners.GetRotation()) { }

}