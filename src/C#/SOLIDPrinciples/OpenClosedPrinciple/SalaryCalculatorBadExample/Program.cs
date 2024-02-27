using System;
using System.Collections.Generic;
using System.Linq;

namespace SalaryCalculatorBadExample
{
    public class DeveloperReport
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Level { get; set; }

        public int WorkingHours { get; set; }

        public double HourlyRate { get; set; }
    }

    public class TotalSalariesCalculator
    {
        private readonly IEnumerable<DeveloperReport> _developerReports;

        public TotalSalariesCalculator(List<DeveloperReport> developerReports)
        {
            _developerReports = developerReports;
        }

        public double CalculateTotalSalaries()
        {
            return _developerReports.Sum(dr => dr.HourlyRate * dr.WorkingHours);
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

            var developerReports = new List<DeveloperReport>
            {
                firstDeveloperReport,
                secondDeveloperReport,
                thirdDeveloperReport
            };

            var totalSalariesCalculator = new TotalSalariesCalculator(developerReports);
            Console.WriteLine($"The sum of all developer salaries is: {totalSalariesCalculator.CalculateTotalSalaries()} dollars");
        }
    }
}
