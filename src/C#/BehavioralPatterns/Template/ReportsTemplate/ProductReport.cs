﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReportsTemplate
{
    public class Product
    {
        public string Name { get; set; }

        public int Orders { get; set; }
    }

    public class ProductReport : Report
    {
        private readonly string outputPath;

        public ProductReport(string filePath, string outputPath) : base(filePath)
        {
            this.outputPath = outputPath;
        }

        protected override List<string[]> ReadRecords()
        {
            var json = File.ReadAllText(filePath);
            var products = JsonConvert.DeserializeObject<List<Product>>(json);

            List<string[]> records = new List<string[]>();

            foreach (var product in products)
            {
                records.Add(new string[] { product.Name, product.Orders.ToString() });
            }

            return records;
        }

        protected override object ProcessRecords(List<string[]> records)
        {
            string productWithMostOrders = string.Empty;

            int maxOrders = 0;

            foreach (var record in records)
            {
                int orders = Convert.ToInt32(record[1]);

                if (maxOrders < orders)
                {
                    maxOrders = orders;
                    productWithMostOrders = record[0];
                }
            }

            return productWithMostOrders;
        }

        protected override void SendResult(object result)
        {
            File.WriteAllText(outputPath, result.ToString());
        }
    }
}
