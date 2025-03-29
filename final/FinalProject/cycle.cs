class Cycle
{
    int _rotation;
    bool _isSolved;

    public Cycle()
    {
        _rotation = 0;
        _isSolved = true;
    }

    public Cycle(int rotation)
    {
        _rotation = rotation;
        if (_rotation == 0)
        {
            _isSolved = true;
        }
        else
        {
            _isSolved = false;
        }
    }

    public int GetRotation()
    {
        return _rotation;
    }

    public virtual void Move(int rotations)
    {
        _rotation = (_rotation + rotations) % 4;
        if (_rotation == 0)
        {
            _isSolved = true;
        }
        else
        {
            _isSolved = false;
        }
    }

}