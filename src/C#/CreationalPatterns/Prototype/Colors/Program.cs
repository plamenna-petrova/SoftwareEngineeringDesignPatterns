using System;
using System.Collections.Generic;

namespace Colors
{
    public abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    public class ColorConcretePrototype : ColorPrototype
    {
        public ColorConcretePrototype(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public int Red { get; set; }

        public int Green { get; set; }

        public int Blue { get; set; }

        public override ColorPrototype Clone() => MemberwiseClone() as ColorPrototype;

        public override string ToString() => string.Format("Cloned color RGB: {0,3},{1,3},{2,3}", Red, Green, Blue);
    }

    public class ColorManager
    {
        private Dictionary<string, ColorPrototype> colors = new Dictionary<string, ColorPrototype>();

        public ColorPrototype this[string key]
        {
            get => colors[key];
            set => colors.Add(key, value);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ColorManager colorManager = new ColorManager();

            colorManager["red"] = new ColorConcretePrototype(255, 0, 0);
            colorManager["green"] = new ColorConcretePrototype(0, 255, 0);
            colorManager["blue"] = new ColorConcretePrototype(0, 0, 255);

            colorManager["angry"] = new ColorConcretePrototype(255, 54, 0);
            colorManager["peace"] = new ColorConcretePrototype(128, 211, 128);
            colorManager["flame"] = new ColorConcretePrototype(211, 34, 20);

            ColorConcretePrototype redColor = colorManager["red"].Clone() as ColorConcretePrototype;
            ColorConcretePrototype peaceColor = colorManager["peace"].Clone() as ColorConcretePrototype;
            ColorConcretePrototype flameColor = colorManager["flame"].Clone() as ColorConcretePrototype;

            Console.WriteLine(redColor.ToString());
            Console.WriteLine(peaceColor.ToString());
            Console.WriteLine(flameColor.ToString());
        }
    }
}
