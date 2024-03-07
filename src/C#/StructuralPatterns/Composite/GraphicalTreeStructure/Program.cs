using System;
using System.Collections.Generic;

namespace GraphicalTreeStructure
{
    public abstract class DrawingElement
    {
        protected string name;

        public DrawingElement(string name)
        {
            this.name = name;
        }

        public abstract void Add(DrawingElement drawingElement);

        public abstract void Remove(DrawingElement drawingElement);

        public abstract void Display(int indent);
    }

    public class CompositeElement : DrawingElement
    {
        private List<DrawingElement> drawingElements = new List<DrawingElement>();

        public CompositeElement(string name)
            : base(name)
        {

        }

        public override void Add(DrawingElement drawingElement)
        {
            drawingElements.Add(drawingElement);
        }

        public override void Remove(DrawingElement drawingElement)
        {
            drawingElements.Remove(drawingElement);
        }

        public override void Display(int indent)
        {
            Console.WriteLine($"{new string('-', indent)}+ {name}");

            foreach (DrawingElement drawingElement in drawingElements)
            {
                drawingElement.Display(indent + 2);
            }
        }
    }

    public class PrimitiveElement : DrawingElement
    {
        public PrimitiveElement(string name)
            : base(name)
        {

        }

        public override void Add(DrawingElement drawingElement)
        {
            Console.WriteLine("Cannot add to a primitive element");
        }

        public override void Remove(DrawingElement drawingElement)
        {
            Console.WriteLine("Cannot remove from a primitive element");
        }

        public override void Display(int indent)
        {
            Console.WriteLine($"{new string('-', indent)} {name}");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            CompositeElement canvas = new CompositeElement("Canvas");
            canvas.Add(new PrimitiveElement("Red Line"));
            canvas.Add(new PrimitiveElement("Blue Circle"));
            canvas.Add(new PrimitiveElement("Green Box"));

            CompositeElement compositeElement = new CompositeElement("Two Circles");
            compositeElement.Add(new PrimitiveElement("Black Circle"));
            compositeElement.Add(new PrimitiveElement("White Circle"));
            canvas.Add(compositeElement);

            PrimitiveElement primitiveElement = new PrimitiveElement("Orange Line");
            canvas.Add(primitiveElement);
            canvas.Remove(primitiveElement);

            canvas.Display(1);

            Console.ReadKey();
        }
    }
}
