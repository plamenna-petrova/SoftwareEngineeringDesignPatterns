using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReportsGoodExample
{
    public interface IEntryManager<T>
    {
        void AddEntry(T entry);

        void RemoveEntryAt(int index);
    }

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

    public class WorkReport : IEntryManager<WorkReportEntry>
    {
        private readonly List<WorkReportEntry> _workReportEntries;

        public WorkReport()
        {
            _workReportEntries = new List<WorkReportEntry>();
        }

        public void AddEntry(WorkReportEntry workReportEntry) => _workReportEntries.Add(workReportEntry);

        public void RemoveEntryAt(int index) => _workReportEntries.RemoveAt(index);

        public override string ToString() =>
            string.Join(Environment.NewLine, _workReportEntries.Select(wre =>
                $"Project Code: {wre.ProjectCode}, Project Name: {wre.ProjectName}, Spent Hours: {wre.SpentHours}")
            );
    }

    public class TaskScheduler : IEntryManager<ScheduledTask>
    {
        private readonly List<ScheduledTask> _scheduledTasks;

        public TaskScheduler()
        {
            _scheduledTasks = new List<ScheduledTask>();
        }

        public void AddEntry(ScheduledTask scheduledTaskEntry) => _scheduledTasks.Add(scheduledTaskEntry);

        public void RemoveEntryAt(int index) => _scheduledTasks.RemoveAt(index);

        public override string ToString() =>
            string.Join(Environment.NewLine, _scheduledTasks.Select(st =>
                $"Task with ID: {st.ID} with content: {st.Content} is going to be executed on {st.ExecutedOn}")
            );
    }

    public class FileSaver
    {
        public void SaveToFile<T>(string directoryPath, string fileName, IEntryManager<T> entryManager)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(Path.Combine(directoryPath, fileName), entryManager.ToString());
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            FileSaver fileSaver = new FileSaver();

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

            workReport.AddEntry(firstWorkReportEntry);
            workReport.AddEntry(secondWorkReportEntry);

            Console.WriteLine(workReport.ToString());

            fileSaver.SaveToFile(@"Reports", "WorkReports.txt", workReport);

            var taskScheduler = new TaskScheduler();

            var firstScheduledTask = new ScheduledTask
            {
                ID = 1,
                Content = "Do something now.",
                ExecutedOn = DateTime.Now.AddDays(2)
            };

            var secondScheduledTask = new ScheduledTask
            {
                ID = 2,
                Content = "Don't forget to...",
                ExecutedOn = DateTime.Now.AddDays(5)
            };

            taskScheduler.AddEntry(firstScheduledTask);
            taskScheduler.AddEntry(secondScheduledTask);

            Console.WriteLine(taskScheduler.ToString());

            fileSaver.SaveToFile(@"ScheduledTasks", "Tasks.txt", taskScheduler);
        }
    }
}
