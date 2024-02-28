using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesBadExample
{
    public enum Gender
    {
        Mal,
        Female
    }

    public enum Position
    {
        Administrator,
        Manager,
        Executive
    }

    public class Employee
    {
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public Position Position { get; set; }
    }

    public class EmployeesManager
    {
        private readonly List<Employee> _employees;

        public EmployeesManager()
        {
            _employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee) => _employees.Add(employee);

        public List<Employee> Employees => _employees;
    }

    public class EmployeesStatistics
    {
        private readonly EmployeesManager _employeesManager;

        public EmployeesStatistics(EmployeesManager employeesManager)
        {
            _employeesManager = employeesManager;
        }

        public int GetFemaleManagersCount() =>
            _employeesManager.Employees.Count(e => e.Gender == Gender.Female && e.Position == Position.Manager);
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var firstEmployee = new Employee
            {
                Name = "Sarah",
                Gender = Gender.Female,
                Position = Position.Manager
            };

            var secondEmployee = new Employee
            {
                Name = "Jodie",
                Gender = Gender.Female,
                Position = Position.Manager
            };

            var employeesManager = new EmployeesManager();
            employeesManager.AddEmployee(firstEmployee);
            employeesManager.AddEmployee(secondEmployee);

            var employeesStatistics = new EmployeesStatistics(employeesManager);
            Console.WriteLine($"The count of female managers in the company is: {employeesStatistics.GetFemaleManagersCount()}");
        }
    }
}
