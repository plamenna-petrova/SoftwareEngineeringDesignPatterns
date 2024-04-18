using System;
using System.Collections.Generic;
using System.Text;

namespace ReportsTemplate
{
    public abstract class Report
    {
        protected readonly string filePath;

        protected Report(string filePath)
        {
            this.filePath = filePath;
        }

        public void Run()
        {
            var records = ReadRecords();
            var result = ProcessRecords(records);
            SendResult(result);
        }

        protected abstract List<string[]> ReadRecords();

        protected abstract object ProcessRecords(List<string[]> records);

        protected virtual void SendResult(object result) => Console.WriteLine(result.ToString());
    }
}
