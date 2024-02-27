using System;

namespace ShapesBadExample
{
    public class Rectangle
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public virtual void SetWidth(int width)
        {
            Width = width;
        }

        public virtual void SetHeight(int height)
        {
            Height = height;
        }

        public int CalculateArea() => Width * Height;
    }

    public class Square : Rectangle
    {
        public override void SetWidth(int width)
        {
            Width = width;
            Height = width;
        }

        public override void SetHeight(int height)
        {
            Width = height;
            Height = height;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Rectangle firstSquare = new Square();
            firstSquare.SetHeight(6);
            firstSquare.SetWidth(8);

            Console.WriteLine(firstSquare.CalculateArea());

            Rectangle secondSquare = new Square();
            secondSquare.SetHeight(8);
            secondSquare.SetWidth(6);

            Console.WriteLine(secondSquare.CalculateArea());
        }
    }
}
