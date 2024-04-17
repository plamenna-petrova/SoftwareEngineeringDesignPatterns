using System;

namespace StructuralCode
{
    public class Memento
    {
        private string state;

        public Memento(string state)
        {
            this.state = state;
        }

        public string State => state;
    }

    public class Originator
    {
        private string state;

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                Console.WriteLine("State = " + state);
            }
        }

        public Memento CreateMemento() => new Memento(state);

        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");
            State = memento.State;
        }
    }

    public class Caretaker
    {
        private Memento memento;

        public Memento Memento
        {
            get { return memento; }
            set { memento = value; }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Originator originator = new Originator();
            originator.State = "On";

            Caretaker caretaker = new Caretaker();
            caretaker.Memento = originator.CreateMemento();

            originator.State = "Off";

            originator.SetMemento(caretaker.Memento);
        }
    }
}
