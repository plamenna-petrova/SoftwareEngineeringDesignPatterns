using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Customers
{
    public class CustomersBase
    {
        public DataObject DataObject { get; set; }

        public virtual void Next() => DataObject.GetNextRecord();

        public virtual void Previous() => DataObject.GetPreviousRecord();

        public virtual void Add(string record) => DataObject.AddRecord(record);

        public virtual void Remove(string record) => DataObject.RemoveRecord(record);

        public virtual void Show() => DataObject.ShowRecord();

        public virtual void ShowAll() => DataObject.ShowAllRecords();
    }

    public class RefinedCustomers : CustomersBase
    {
        public override void ShowAll()
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 40));
            base.ShowAll();
            Console.WriteLine(new string('-', 40));
        }
    }

    public abstract class DataObject
    {
        public abstract void GetNextRecord();

        public abstract void GetPreviousRecord();

        public abstract void AddRecord(string record);

        public abstract void RemoveRecord(string record);

        public abstract string GetCurrentRecord();

        public abstract void ShowRecord();

        public abstract void ShowAllRecords();
    }

    public class CustomersData : DataObject
    {
        private readonly List<string> customers = new List<string>();

        private int currentCustomerIndex = 0;

        public CustomersData(string city)
        {
            City = city;

            customers.Add("Jim Jones");
            customers.Add("Samuel Jackson");
            customers.Add("Allen Good");
            customers.Add("Ann Stills");
            customers.Add("Lisa Giolani");
        }

        public string City { get; private set; }

        public override void GetNextRecord()
        {
            if (currentCustomerIndex <= customers.Count - 1) 
            {
                currentCustomerIndex++;
            }   
        }

        public override void GetPreviousRecord()
        {
            if (currentCustomerIndex > 0)
            {
                currentCustomerIndex--;
            }
        }

        public override void AddRecord(string record) => customers.Add(record);

        public override void RemoveRecord(string record) => customers.Remove(record);

        public override string GetCurrentRecord() => customers[currentCustomerIndex];

        public override void ShowRecord() => Console.WriteLine(customers[currentCustomerIndex]);

        public override void ShowAllRecords() =>
            Console.WriteLine(new StringBuilder().AppendLine($"Customers City: {City}")
               .AppendJoin(Environment.NewLine, customers.Select(c => $" {c}"))
               .ToString());
    }

    public class Program
    {
        static void Main(string[] args)
        {
            CustomersBase customers = new RefinedCustomers
            {
                DataObject = new CustomersData("Chicago")
            };

            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Previous();
            customers.Show();
            customers.Add("Henry Velasquez");
            customers.ShowAll();
            customers.Remove("Allen Good");
            customers.ShowAll();
        }
    }
}
