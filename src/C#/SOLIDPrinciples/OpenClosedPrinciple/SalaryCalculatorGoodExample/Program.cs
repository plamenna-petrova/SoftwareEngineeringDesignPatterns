using System;
using System.Collections.Generic;
using System.Linq;

namespace SalaryCalculatorGoodExample
{
    public class DeveloperReport
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Level { get; set; }

        public int WorkingHours { get; set; }

        public double HourlyRate { get; set; }
    }

    public abstract class BaseSalaryCalculator
    {
        public BaseSalaryCalculator(DeveloperReport developerReport)
        {
            DeveloperReport = developerReport;
        }

        protected DeveloperReport DeveloperReport { get; private set; }

        public abstract double CalculateSalary();
    }

    public class SeniorDeveloperSalaryCalculator : BaseSalaryCalculator
    {
        public SeniorDeveloperSalaryCalculator(DeveloperReport developerReport)
            : base(developerReport)
        {

        }

        public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours * 1.2;
    }

    public class JuniorDeveloperSalaryCalculator : BaseSalaryCalculator
    {
        public JuniorDeveloperSalaryCalculator(DeveloperReport developerReport)
            : base(developerReport)
        {

        }

        public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours;
    }

    public class TotalSalariesCalculator
    {
        private readonly IEnumerable<BaseSalaryCalculator> _salaryCalculators;

        public TotalSalariesCalculator(IEnumerable<BaseSalaryCalculator> salaryCalculators)
        {
            _salaryCalculators = salaryCalculators;
        }

        public double CalculateTotalSalaries()
        {
            return _salaryCalculators.Sum(sc => sc.CalculateSalary());
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var firstDeveloperReport = new DeveloperReport
            {
                ID = 1,
                Name = "Developer 1",
                Level = "Senior Developer",
                HourlyRate = 30.5,
                WorkingHours = 160
            };

            var secondDeveloperReport = new DeveloperReport
            {
                ID = 2,
                Name = "Developer 2",
                Level = "Junior Developer",
                HourlyRate = 20,
                WorkingHours = 150
            };

            var thirdDeveloperReport = new DeveloperReport
            {
                ID = 3,
                Name = "Developer 3",
                Level = "Senior Developer",
                HourlyRate = 30.5,
                WorkingHours = 180
            };

            var developersSalaryCalculators = new List<BaseSalaryCalculator>
            {
                new SeniorDeveloperSalaryCalculator(firstDeveloperReport),
                new JuniorDeveloperSalaryCalculator(secondDeveloperReport),
                new SeniorDeveloperSalaryCalculator(thirdDeveloperReport)
            };

            var totalSalariesCalculator = new TotalSalariesCalculator(developersSalaryCalculators);
            Console.WriteLine($"The sum of all developer salaries is: {totalSalariesCalculator.CalculateTotalSalaries()}");
        }
    }
}
