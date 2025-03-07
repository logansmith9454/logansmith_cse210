using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapeList = new List<Shape>();
        shapeList.Add(new Square("Purple", 4));
        shapeList.Add(new Rectangle("Red", 7, 3));
        shapeList.Add(new Circle("Blue", 5));

        foreach (Shape shape in shapeList)
        {
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.GetArea()}.");
        }

    }
}