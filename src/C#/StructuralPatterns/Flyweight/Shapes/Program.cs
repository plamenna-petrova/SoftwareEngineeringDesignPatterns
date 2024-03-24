using System;
using System.Collections.Generic;

namespace Shapes
{
    public interface Shape
    {
        void Draw();
    }

    public class Circle : Shape
    {
        private int xCoordinate = 10;

        private int yCoordinate = 20;

        private int Radius = 30;

        public void SetColor(string color)
        {
            Color = color;
        }

        public string Color { get; set; }

        public void Draw()
        {
            Console.WriteLine($" Circle: Draw() [Color : {Color}, X Coordinate : {xCoordinate} Y Coordinate : {yCoordinate}, Radius : {Radius} ]");
        }
    }

    public class ShapeFactory
    {
        private static readonly Dictionary<string, Shape> shapes = new Dictionary<string, Shape>();

        public static Shape GetShape(string shapeType)
        {
            Shape shape = null;

            if (shapeType.Equals("circle", StringComparison.InvariantCultureIgnoreCase))
            {
                if (!shapes.TryGetValue("circle", out shape))
                {
                    shape = new Circle();
                    shapes.Add("circle", shape);
                    Console.WriteLine(" Creating circle object with out any color in shape factory \n");
                }
            }
            return shape;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("\n Red color Circles ");

            for (int i = 0; i < 3; i++)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Red");
                circle.Draw();
            }

            Console.WriteLine("\n Green color Circles ");

            for (int i = 0; i < 3; i++)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Green");
                circle.Draw();
            }

            Console.WriteLine("\n Blue color Circles");

            for (int i = 0; i < 3; ++i)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Green");
                circle.Draw();
            }

            Console.WriteLine("\n Orange color Circles");

            for (int i = 0; i < 3; ++i)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Orange");
                circle.Draw();
            }

            Console.WriteLine("\n Black color Circles");

            for (int i = 0; i < 3; ++i)
            {
                Circle circle = (Circle)ShapeFactory.GetShape("circle");
                circle.SetColor("Black");
                circle.Draw();
            }
        }
    }
}
