using System;

namespace SalesProspect
{
    public class Memento
    {
        private string name;

        private string phone;

        private double budget;

        public Memento(string name, string phone, double budget)
        {
            Name = name;
            Phone = phone;
            Budget = budget;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public double Budget
        {
            get { return budget; }
            set { budget = value; }
        }
    }

    public class SalesProspect
    {
        private string name;

        private string phone;

        private double budget;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                Console.WriteLine("Name:  " + name);
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                Console.WriteLine("Phone:  " + phone);
            }
        }

        public double Budget
        {
            get
            {
                return budget;
            }
            set
            {
                budget = value;
                Console.WriteLine("Budget: " + budget);
            }
        }

        public Memento SaveMemento()
        {
            Console.WriteLine("\nSaving state --\n");
            return new Memento(name, phone, budget);
        }

        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("\nRestoring state --\n");
            Name = memento.Name;
            Phone = memento.Phone;
            Budget = memento.Budget;
        }
    }

    public class ProspectMemory
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
            SalesProspect salesProspect = new SalesProspect();
            salesProspect.Name = "Noel van Halen";
            salesProspect.Phone = "(412) 256-0990";

            ProspectMemory prospectMemory = new ProspectMemory();
            prospectMemory.Memento = salesProspect.SaveMemento();

            salesProspect.Name = "Leo Welch";
            salesProspect.Phone = "(310) 209-7111";
            salesProspect.Budget = 100000.0;

            salesProspect.RestoreMemento(prospectMemory.Memento);
        }
    }
}
