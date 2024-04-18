using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportsTemplate
{
    public class Program
    {
        static void Main(string[] args)
        {
            var customerReport = new CustomerReport("../../../customers.csv");
            var productReport = new ProductReport("../../../products.json", "../../../product_report.txt");

            var reportProcessor = new ReportProcessor(customerReport, productReport);
            reportProcessor.ProcessReports();
        }

        public class ReportProcessor
        {
            private readonly List<Report> reports;

            public ReportProcessor(params Report[] reports)
            {
                this.reports = reports.ToList();
            }

            public void ProcessReports()
            {
                reports.ForEach(r => r.Run());
            }
        }
    }
}
