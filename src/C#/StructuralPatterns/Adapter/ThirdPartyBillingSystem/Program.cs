using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirdPartyBillingSystem
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
        void ProcessCompanySalary(string[,] employeesArray);
    }

    public class EmployeesAdapter : IEmployeesTarget
    {
        private ThirdPartyBillingSystem thirdPartyBillingSystem = new ThirdPartyBillingSystem();

        public void ProcessCompanySalary(string[,] employeesArray)
        {
            List<Employee> adaptedEmployees = new List<Employee>();

            for (int i = 0; i < employeesArray.GetLength(0); i++)
            {
                Employee employee = new Employee();

                for (int j = 0; j < employeesArray.GetLength(1); j++)
                {
                    string employeeDatum = employeesArray[i, j];

                    switch (j)
                    {
                        case 0:
                            employee.ID = int.Parse(employeeDatum);
                            break;
                        case 1:
                            employee.Name = employeeDatum;
                            break;
                        case 2:
                            employee.Designation = employeeDatum;
                            break;
                        case 3:
                            employee.Salary = decimal.Parse(employeeDatum);
                            break;
                    }
                }

                adaptedEmployees.Add(employee);
            }

            Console.WriteLine("Adapter converted array of employees to a list of employees");
            Console.WriteLine("Then delegate to the ThirdPartyBillingSystem for processing the employees salary\n");

            thirdPartyBillingSystem.ProcessSalary(adaptedEmployees);
        }
    }

    public class ThirdPartyBillingSystem
    {
        public void ProcessSalary(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"Salary: {employee.Salary}, " +
                    $"Credited to: {employee.Name} with designation: {employee.Designation}");
            }
        }
    }

    public class Program
    {
        // Enter data from employees.txt

        static void Main(string[] args)
        {
            string[,] employees2DDataArray = Fill2DArrayElementsWithRowsAndCols(5, 4);
            Console.WriteLine();

            IEmployeesTarget employeesTarget = new EmployeesAdapter();
            Console.WriteLine("HR system passes employee string array to Adapter");
            employeesTarget.ProcessCompanySalary(employees2DDataArray);
        }

        private static string[,] Fill2DArrayElementsWithRowsAndCols(int rows, int cols)
        {
            string[,] twoDimensionalArray = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowArray = Console.ReadLine().Split().ToArray();

                for (int col = 0; col < cols; col++)
                {
                    twoDimensionalArray[row, col] = rowArray[col];
                }
            }

            return twoDimensionalArray;
        }
    }
}
