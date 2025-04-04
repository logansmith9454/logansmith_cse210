class Cycle
{
    int _rotation;

    public Cycle()
    {
        _rotation = 0;
    }

    public Cycle(int rotation)
    {
        _rotation = rotation;
    }

    public int GetRotation()
    {
        return _rotation;
    }

    public virtual void Move(int rotations)
    {
        _rotation = (_rotation + rotations) % 4;
    }

}