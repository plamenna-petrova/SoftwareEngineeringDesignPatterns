using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirdPartyBillingSystemV2
{
    public class Employee
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        public decimal Salary { get; set; }
    }

    public interface IEmployeesTarget
    {
        void ProcessCompanySalary(List<Employee> employees);
    }

    public class EmployeesAdapter : IEmployeesTarget
    {
        private ThirdPartyBillingSystem thirdPartyBillingSystem = new ThirdPartyBillingSystem();

        public void ProcessCompanySalary(List<Employee> employees)
        {
            string[][] adaptedEmployeesJaggedArray = employees
                .Select(e => new string[] { e.ID.ToString(), e.Name, e.Designation, e.Salary.ToString() })
                .ToArray();

            Console.WriteLine("Adapter converted array of employees to a list of employees");
            Console.WriteLine("Then delegate to the ThirdPartyBillingSystem for processing the employees salary\n");

            thirdPartyBillingSystem.ProcessSalary(adaptedEmployeesJaggedArray);
        }
    }

    public class ThirdPartyBillingSystem
    {
        public void ProcessSalary(string[][] employeesJaggedArray)
        {
            foreach (var employeeArray in employeesJaggedArray)
            {
                Console.WriteLine($"Salary: {employeeArray[3]}, " +
                    $"Credited to: {employeeArray[1]} with designation: {employeeArray[2]}");
            }
        }
    }

    public class Engine
    {
        // Enter data from EmployeesV2.txt

        public static void Run()
        {
            List<Employee> employeesToProcessCompanySalary = new List<Employee>();

            string employeeCommand = Console.ReadLine();

            while (employeeCommand != "END")
            {
                string[] employeeCommands = employeeCommand.Split().ToArray();

                var employeeToProcessCompanySalary = new Employee
                {
                    ID = int.Parse(employeeCommands[0]),
                    Name = employeeCommands[1],
                    Designation = employeeCommands[2],
                    Salary = decimal.Parse(employeeCommands[3])
                };

                employeesToProcessCompanySalary.Add(employeeToProcessCompanySalary);

                employeeCommand = Console.ReadLine();
            }

            IEmployeesTarget employeesTarget = new EmployeesAdapter();
            employeesTarget.ProcessCompanySalary(employeesToProcessCompanySalary);
        }
    }
}
