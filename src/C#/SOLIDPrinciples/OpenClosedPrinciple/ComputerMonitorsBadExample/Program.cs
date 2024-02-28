using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerMonitorsBadExample
{
    public enum ComputerMonitorType
    {
        OLED,
        LCD,
        LED
    }

    public enum ScreenType
    {
        WideScreen,
        CurvedScreen
    }

    public class ComputerMonitor
    {
        public string Name { get; set; }

        public ComputerMonitorType Type { get; set; }

        public ScreenType Screen { get; set; }
    }

    public class ComputerMonitorFilter
    {
        public List<ComputerMonitor> FilterByComputerMonitorType(IEnumerable<ComputerMonitor> computerMonitors, ComputerMonitorType computerMonitorType)
            => computerMonitors.Where(cm => cm.Type == computerMonitorType).ToList();

        public List<ComputerMonitor> FilterByScreenType(IEnumerable<ComputerMonitor> computerMonitors, ScreenType screenType)
            => computerMonitors.Where(cm => cm.Screen == screenType).ToList();
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var computerMonitors = new List<ComputerMonitor>
            {
                new ComputerMonitor
                {
                    Name = "Samsung S345",
                    Screen = ScreenType.CurvedScreen,
                    Type = ComputerMonitorType.OLED
                },
                new ComputerMonitor
                {
                    Name = "Philips P532",
                    Screen = ScreenType.WideScreen,
                    Type = ComputerMonitorType.LCD
                },
                new ComputerMonitor
                {
                    Name = "LG L888",
                    Screen = ScreenType.WideScreen,
                    Type = ComputerMonitorType.LED
                },
                new ComputerMonitor
                {
                    Name = "Samsung S999",
                    Screen = ScreenType.WideScreen,
                    Type= ComputerMonitorType.OLED
                },
                new ComputerMonitor
                {
                    Name = "Dell D2J47",
                    Screen = ScreenType.CurvedScreen,
                    Type = ComputerMonitorType.LED
                }
            };

            var computerMonitorFilter = new ComputerMonitorFilter();

            var ledComputerMonitors = computerMonitorFilter.FilterByComputerMonitorType(computerMonitors, ComputerMonitorType.LED);

            Console.WriteLine($"All {ComputerMonitorType.LED} monitors");

            foreach (var ledComputerMonitor in ledComputerMonitors)
            {
                Console.WriteLine($"Name: {ledComputerMonitor.Name}, Type: {ledComputerMonitor.Type}, Screen: {ledComputerMonitor.Screen}");
            }

            Console.WriteLine(Environment.NewLine + new string('=', 60) + Environment.NewLine);

            var wideScreenComputerMonitors = computerMonitorFilter.FilterByScreenType(computerMonitors, ScreenType.WideScreen);

            Console.WriteLine($"All {ScreenType.WideScreen} monitors");

            foreach (var wideScreenComputerMonitor in wideScreenComputerMonitors)
            {
                Console.WriteLine($"Name: {wideScreenComputerMonitor.Name}, Type: {wideScreenComputerMonitor.Type}, Screen: {wideScreenComputerMonitor.Screen}");
            }
        }
    }
}
