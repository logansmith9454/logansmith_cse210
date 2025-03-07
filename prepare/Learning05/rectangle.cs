class Rectangle : Shape
{
    private double _length;
    private double _width;

    public Rectangle() : base()
    {
        _length = 1;
        _width = 1;
    }

    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    public override double GetArea()
    {
        return (_length * _width);
    }
}