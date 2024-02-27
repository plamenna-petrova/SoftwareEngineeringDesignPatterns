using System;

namespace ShapesGoodExample
{
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public override double CalculateArea() => Width * Height;
    }

    public class Square : Shape
    {
        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public double SideLength { get; set; }

        public override double CalculateArea() => SideLength * SideLength;
    }

    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; set; }

        public override double CalculateArea() => Math.PI * Radius * Radius;
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(8, 6);
            Console.WriteLine($"Rectangle area : {Math.Round(rectangle.CalculateArea(), 2):F2}");

            Shape square = new Square(4);
            Console.WriteLine($"Square area: {Math.Round(square.CalculateArea(), 2):F2}");

            Shape circle = new Circle(5);
            Console.WriteLine($"Circle area: {Math.Round(circle.CalculateArea(), 2):F2}");
        }
    }
}
