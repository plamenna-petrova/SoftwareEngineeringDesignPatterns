using System;
using System.Collections.Generic;
using System.Linq;

namespace SalaryCalculator
{
    public enum DeveloperLevel
    {
        Junior,
        Senior
    }

    public class DeveloperReport
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DeveloperLevel DeveloperLevel { get; set; }

        public int WorkingHours { get; set; }

        public double HourlyRate { get; set; }

        public double CalculateSalary() => WorkingHours * HourlyRate;
    }

    public interface ISalaryCalculatorStrategy
    {
        double CalculateTotalSalary(IEnumerable<DeveloperReport> developerReports);
    }

    public class JuniorDeveloperSalaryCalculatorStrategy : ISalaryCalculatorStrategy
    {
        public double CalculateTotalSalary(IEnumerable<DeveloperReport> developerReports) =>
            developerReports
                .Where(dr => dr.DeveloperLevel == DeveloperLevel.Junior)
                .Select(dr => dr.CalculateSalary())
                .Sum();
    }

    public class SeniorDeveloperSalaryCalculatorStrategy : ISalaryCalculatorStrategy
    {
        public double CalculateTotalSalary(IEnumerable<DeveloperReport> developerReports) =>
            developerReports
                .Where(dr => dr.DeveloperLevel == DeveloperLevel.Senior)
                .Select(dr => dr.CalculateSalary())
                .Sum();
    }

    public class SalaryCalculatorContext
    {
        private ISalaryCalculatorStrategy salaryCalculatorStrategy;

        public SalaryCalculatorContext(ISalaryCalculatorStrategy salaryCalculatorStrategy)
        {
            this.salaryCalculatorStrategy = salaryCalculatorStrategy;
        }

        public void SetSalaryCalculatorStrategy(ISalaryCalculatorStrategy salaryCalculatorStrategy) => this.salaryCalculatorStrategy = salaryCalculatorStrategy;

        public double Calculate(IEnumerable<DeveloperReport> developerReports) => salaryCalculatorStrategy.CalculateTotalSalary(developerReports);
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var developerReports = new List<DeveloperReport>
            {
                new DeveloperReport
                {
                    Id = 1,
                    Name = "Developer 1",
                    DeveloperLevel = DeveloperLevel.Senior,
                    HourlyRate = 30.5,
                    WorkingHours = 160
                },
                new DeveloperReport
                {
                    Id = 2,
                    Name = "Developer 2",
                    DeveloperLevel = DeveloperLevel.Junior,
                    HourlyRate = 20,
                    WorkingHours = 120
                },
                new DeveloperReport
                {
                    Id = 3,
                    Name = "Developer 3",
                    DeveloperLevel = DeveloperLevel.Senior,
                    HourlyRate = 32.5,
                    WorkingHours = 130
                },
                new DeveloperReport
                {
                    Id = 4,
                    Name = "Developer 4",
                    DeveloperLevel = DeveloperLevel.Junior,
                    HourlyRate = 24.5,
                    WorkingHours = 140
                }
            };

            var salaryCalculatorContext = new SalaryCalculatorContext(new JuniorDeveloperSalaryCalculatorStrategy());
            var juniorsTotalSalary = salaryCalculatorContext.Calculate(developerReports);
            Console.WriteLine($"The total amount for the junior salaries is: {juniorsTotalSalary}");

            salaryCalculatorContext.SetSalaryCalculatorStrategy(new SeniorDeveloperSalaryCalculatorStrategy());
            var seniorsTotalSalary = salaryCalculatorContext.Calculate(developerReports);
            Console.WriteLine($"The total amount for the senior salaries is : {seniorsTotalSalary}");

            Console.WriteLine($"The total cost for all salaries is : {juniorsTotalSalary + seniorsTotalSalary}");
        }
    }
}
