using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesGoodExample
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

    public interface IEmployeesManager
    {
        void AddEmployee(Employee employee);

        IEnumerable<Employee> FilterEmployeesByGenderAndPosition(Gender gender, Position position);
    }

    public class EmployeesManager : IEmployeesManager
    {
        private readonly List<Employee> _employees;

        public EmployeesManager()
        {
            _employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee) => _employees.Add(employee);

        public IEnumerable<Employee> FilterEmployeesByGenderAndPosition(Gender gender, Position position) =>
            _employees.Where(e => e.Gender == gender && e.Position == position);
    }

    public class EmployeesStatistics
    {
        private readonly IEmployeesManager _employeesManager;

        public EmployeesStatistics(IEmployeesManager employeesManager)
        {
            _employeesManager = employeesManager;
        }

        public int GetFemaleManagersCount() =>
            _employeesManager.FilterEmployeesByGenderAndPosition(Gender.Female, Position.Manager).Count();
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

            IEmployeesManager employeesManager = new EmployeesManager();
            employeesManager.AddEmployee(firstEmployee);
            employeesManager.AddEmployee(secondEmployee);

            var employeesStatistics = new EmployeesStatistics(employeesManager);
            Console.WriteLine($"The count of female managers in the company is: {employeesStatistics.GetFemaleManagersCount()}");
        }
    }
}
