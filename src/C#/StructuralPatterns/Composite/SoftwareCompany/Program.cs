using System;
using System.Collections.Generic;

namespace SoftwareCompany
{
    public abstract class Employee
    {
        public Employee(string name, double salary, string designation)
        {
            Name = name;
            Salary = salary;
            Designation = designation;
        }

        protected string Name { get; set; }

        protected double Salary { get; set; }

        protected string Designation { get; set; }

        public abstract void Add(Employee employee);

        public abstract void Remove(Employee employee);

        public abstract void GetHierarchicalLevel(int level);
    }

    public class TeamLead : Employee
    {
        private List<Employee> employees = new List<Employee>();

        public TeamLead(string name, double salary, string designation)
            : base(name, salary, designation)
        {

        }

        public override void Add(Employee employee)
        {
            employees.Add(employee);
        }

        public override void Remove(Employee employee)
        {
            employees.Remove(employee);
        }

        public override void GetHierarchicalLevel(int level)
        {
            Console.WriteLine($"{new string('-', level)}+ {Name} [{Designation}] [${Salary}]");

            foreach (Employee employee in employees)
            {
                employee.GetHierarchicalLevel(level + 2);
            }
        }
    }

    public class Developer : Employee
    {
        public Developer(string name, double salary, string designation)
            : base(name, salary, designation)
        {

        }

        public override void Add(Employee employee)
        {
            Console.WriteLine("Cannot add to a developer");
        }

        public override void Remove(Employee employee)
        {
            Console.WriteLine("Cannot remove from a developer");
        }

        public override void GetHierarchicalLevel(int level)
        {
            Console.WriteLine($"{new string('-', level)} {Name} [{Designation}] [${Salary}]");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TeamLead companyManager = new TeamLead("John", 100000, "Manager");
            companyManager.Add(new Developer("Jack", 20000, "Senior .NET Backend Developer"));
            companyManager.Add(new Developer("Jim", 25000, "Senior Python Developer"));
            companyManager.Add(new Developer("Jacob", 27000, "Senior Frontend Developer"));

            TeamLead groupArchitect = new TeamLead("Joe", 50000, "Group Architect");
            groupArchitect.Add(new Developer("James", 15000, "Junior .NET Developer"));
            groupArchitect.Add(new Developer("Jason", 12000, "Angular Developer"));
            companyManager.Add(groupArchitect);

            Developer developer = new Developer("Jerry", 18000, "Junior Frontend Developer");
            companyManager.Add(developer);
            companyManager.Remove(developer);

            companyManager.GetHierarchicalLevel(1);
        }
    }
}
