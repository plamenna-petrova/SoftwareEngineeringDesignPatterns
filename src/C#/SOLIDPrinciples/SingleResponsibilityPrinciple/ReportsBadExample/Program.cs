using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReportsBadExample
{
    public class WorkReportEntry
    {
        public string ProjectCode { get; set; }

        public string ProjectName { get; set; }

        public int SpentHours { get; set; }
    }

    public class ScheduledTask
    {
        public int ID { get; set; }

        public string Content { get; set; }

        public DateTime ExecutedOn { get; set; }
    }

    public class WorkReport
    {
        private readonly List<WorkReportEntry> _workReportEntries;

        public WorkReport()
        {
            _workReportEntries = new List<WorkReportEntry>();
        }

        public void AddWorkReportEntry(WorkReportEntry workReportEntry) => _workReportEntries.Add(workReportEntry);

        public void RemoveWorkReportEntryAt(int index) => _workReportEntries.RemoveAt(index);

        public void SaveToFile(string directoryPath, string fileName)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(Path.Combine(directoryPath, fileName), ToString());
        }

        public override string ToString() =>
            string.Join(Environment.NewLine, _workReportEntries.Select(wre =>
                $"Project Code: {wre.ProjectCode}, Project Name: {wre.ProjectName}, Spent Hours: {wre.SpentHours}")
            );
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var workReport = new WorkReport();

            var firstWorkReportEntry = new WorkReportEntry
            {
                ProjectCode = "123Ds",
                ProjectName = "Project1",
                SpentHours = 5
            };

            var secondWorkReportEntry = new WorkReportEntry
            {
                ProjectCode = "987Fc",
                ProjectName = "Project2",
                SpentHours = 3
            };

            workReport.AddWorkReportEntry(firstWorkReportEntry);
            workReport.AddWorkReportEntry(secondWorkReportEntry);

            Console.WriteLine(workReport.ToString());

            workReport.SaveToFile(@"Reports", "WorkReports.txt");
        }
    }
}
