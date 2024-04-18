using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ReportsTemplate
{
    public class CustomerReport : Report
    {
        public CustomerReport(string filePath) : base(filePath)
        {

        }

        protected override List<string[]> ReadRecords()
        {
            List<string[]> records = new List<string[]>();

            var lines = File.ReadAllLines(filePath).Skip(1);

            foreach (var line in lines)
            {
                string[] values = line.Split(',');
                records.Add(values);
            }

            return records;
        }

        protected override object ProcessRecords(List<string[]> records)
        {
            decimal sum = 0m;

            foreach (var record in records)
            {
                sum += Convert.ToDecimal(record[1]);
            }

            return sum / records.Count;
        }
    }
}
