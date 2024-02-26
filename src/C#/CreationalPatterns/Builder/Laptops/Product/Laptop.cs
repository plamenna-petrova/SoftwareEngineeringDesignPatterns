using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laptops.Product
{
    public class Laptop
    {
        public string Model { get; set; }

        public string CPUSeries { get; set; }

        public string GPUModel { get; set; }

        public string RAMType { get; set; }

        public int RAMSize { get; set; }

        public string DisplayType { get; set; }

        public string SSDType { get; set; }

        public int SSDCapacity { get; set; }

        public List<string> Extras { get; set; } = new List<string>();

        public void ShowDetails()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(new string('-', 40));
            stringBuilder.AppendLine($"Model: {Model}");
            stringBuilder.AppendLine($"CPU Model: {CPUSeries}");
            stringBuilder.AppendLine($"GPU Model: {GPUModel}");
            stringBuilder.AppendLine($"RAM Type: {RAMType}");
            stringBuilder.AppendLine($"RAM Size: {RAMSize} GB");
            stringBuilder.AppendLine($"Display Type: {DisplayType}");
            stringBuilder.AppendLine($"SSD Type: {SSDType}");
            stringBuilder.AppendLine($"SSD Capacity: {SSDCapacity} GB");
            stringBuilder.AppendLine($"Extras: ");
            stringBuilder.AppendLine(string.Join('\n', Extras.Select((e, i) => $"Extra #{i + 1}: {e}")));
            stringBuilder.AppendLine(new string('-', 40));
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
