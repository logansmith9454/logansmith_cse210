class Centers : Cycle
{
    bool _isOriented;
    public Centers() : base()
    {
        _isOriented = true;
    }

    public Centers(int rotation) : base(rotation)
    {
        if (rotation == 0 | rotation == 2)
        {
            _isOriented = true;
        }
        else
        {
            _isOriented = false;
        }
    }

    public Centers(bool isOriented) : base()
    {
        if (!isOriented)
        {
            Move(1);
        }
        _isOriented = isOriented;
    }

    public Centers(Centers centers) : base(centers.GetRotation())
    {
        _isOriented = centers.GetIsOriented();
    }

    public bool GetIsOriented()
    {
        return _isOriented;

    }


    public override void Move(int rotations)
    {
        base.Move(rotations);
        if (GetRotation() == 1 || GetRotation() == 3)
        {
            _isOriented = false;
        }
        else
        {
            _isOriented = true;
        }
    }
}