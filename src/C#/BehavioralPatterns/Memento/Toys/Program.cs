using System;

namespace Toys
{
    public class ToyCarMemento
    {
        public string Color { get; }

        public ToyCarMemento(string color)
        {
            Color = color;
        }
    }

    public class ToyCar
    {
        private string color;

        public string Color
        {
            get => color;
            set
            {
                color = value;
                Console.WriteLine($"Car color changed to {color}");
            }
        }

        public ToyCarMemento SaveState()
        {
            return new ToyCarMemento(Color);
        }

        public void RestoreState(ToyCarMemento toyCarMemento)
        {
            Color = toyCarMemento.Color;
        }
    }

    public class ColorChanger
    {
        private ToyCarMemento toyCarMemento;

        public void ChangeColor(ToyCar toyCar, string color)
        {
            toyCarMemento = toyCar.SaveState();
            toyCar.Color = color;
        }

        public void UndoColorChange(ToyCar toyCar)
        {
            toyCar.RestoreState(toyCarMemento);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var toyCar = new ToyCar();
            var colorChanger = new ColorChanger();

            colorChanger.ChangeColor(toyCar, "Red");

            var savedState = toyCar.SaveState();
            colorChanger.ChangeColor(toyCar, "Blue");
            colorChanger.ChangeColor(toyCar, "Green");

            colorChanger.UndoColorChange(toyCar);
            Console.WriteLine($"Current car color: {toyCar.Color}");

            toyCar.RestoreState(savedState);
            Console.WriteLine($"Restored car color: {toyCar.Color}");
        }
    }
}
