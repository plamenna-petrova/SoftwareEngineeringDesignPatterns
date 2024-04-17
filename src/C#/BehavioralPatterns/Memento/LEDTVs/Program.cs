using System;
using System.Collections.Generic;

namespace LEDTVs
{
    public class LEDTV
    {
        public LEDTV(string size, decimal price, bool hasUSBSupport)
        {
            Size = size;
            Price = price;
            HasUSBSupport = hasUSBSupport;
        }

        public string Size { get; set; }

        public decimal Price { get; set; }

        public bool HasUSBSupport { get; set; }

        public string GetDetails()
        {
            return $"LEDTV [Size = {Size}, Price = {Price}, USBSupport = {(HasUSBSupport ? "Yes" : "No")}]";
        }
    }

    public class LEDTVMemento
    {
        public LEDTVMemento(LEDTV ledTV)
        {
            LEDTV = ledTV;
        }

        public LEDTV LEDTV { get; set; }

        public string GetDetails()
        {
            return $"Memento [LedTV = {LEDTV.GetDetails()}]";
        }
    }

    public class Caretaker
    {
        private readonly List<LEDTVMemento> ledTVs = new List<LEDTVMemento>();

        public void AddMemento(LEDTVMemento ledTVMemento)
        {
            ledTVs.Add(ledTVMemento);
            Console.WriteLine("LED TV's snapshots maintained by caretaker : " + ledTVMemento.GetDetails());
        }

        public LEDTVMemento GetLEDTVMemento(int index)
        {
            return ledTVs[index];
        }
    }

    public class Originator
    {
        public LEDTV LEDTV { get; set; }

        public LEDTVMemento CreateLEDTVMemento()
        {
            return new LEDTVMemento(LEDTV);
        }

        public void SetMemento(LEDTVMemento ledTVMemento)
        {
            LEDTV = ledTVMemento.LEDTV;
        }

        public string GetDetails()
        {
            return $"Originator [LEDTV = {LEDTV.GetDetails()}]";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Originator originator = new Originator()
            {
                LEDTV = new LEDTV("42-Inch", 60000, false)
            };

            Caretaker caretaker = new Caretaker();

            LEDTVMemento ledTVMemento = originator.CreateLEDTVMemento();

            caretaker.AddMemento(ledTVMemento);

            originator.LEDTV = new LEDTV("46-Inch", 80000, true);

            ledTVMemento = originator.CreateLEDTVMemento();
            caretaker.AddMemento(ledTVMemento);

            originator.LEDTV = new LEDTV("50-Inch", 100000, true);

            Console.WriteLine($"Originator's current state : {originator.GetDetails()}");

            Console.WriteLine("\nOriginator restoring to 42-Inch LED TV");

            originator.SetMemento(caretaker.GetLEDTVMemento(0));

            Console.WriteLine($"\nOriginator current state: {originator.GetDetails()}");
        }
    }
}
