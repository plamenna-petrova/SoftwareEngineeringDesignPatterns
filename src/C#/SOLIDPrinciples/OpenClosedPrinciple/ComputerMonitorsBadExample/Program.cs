using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerMonitorsBadExample
{
    public enum MonitorType
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

        public MonitorType Type { get; set; }

        public ScreenType Screen { get; set; }
    }

    public class MonitorFilter
    {
        public List<ComputerMonitor> FilterByMonitorType(IEnumerable<ComputerMonitor> computerMonitors, MonitorType monitorType)
            => computerMonitors.Where(cm => cm.Type == monitorType).ToList();

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
                    Type = MonitorType.OLED
                },
                new ComputerMonitor
                {
                    Name = "Philips P532",
                    Screen = ScreenType.WideScreen,
                    Type = MonitorType.LCD
                },
                new ComputerMonitor
                {
                    Name = "LG L888",
                    Screen = ScreenType.WideScreen,
                    Type = MonitorType.LED
                },
                new ComputerMonitor
                {
                    Name = "Samsung S999",
                    Screen = ScreenType.WideScreen,
                    Type= MonitorType.OLED
                },
                new ComputerMonitor
                {
                    Name = "Dell D2J47",
                    Screen = ScreenType.CurvedScreen,
                    Type = MonitorType.LED
                }
            };

            var monitorFilter = new MonitorFilter();

            var ledMonitors = monitorFilter.FilterByMonitorType(computerMonitors, MonitorType.LED);

            Console.WriteLine($"All {MonitorType.LED} monitors");

            foreach (var ledMonitor in ledMonitors)
            {
                Console.WriteLine($"Name: {ledMonitor.Name}, Type: {ledMonitor.Type}, Screen: {ledMonitor.Screen}");
            }

            Console.WriteLine(Environment.NewLine + new string('=', 60) + Environment.NewLine);

            var wideScreenMonitors = monitorFilter.FilterByScreenType(computerMonitors, ScreenType.WideScreen);

            Console.WriteLine($"All {ScreenType.WideScreen} monitors");

            foreach (var wideScreenMonitor in wideScreenMonitors)
            {
                Console.WriteLine($"Name: {wideScreenMonitor.Name}, Type: {wideScreenMonitor.Type}, Screen: {wideScreenMonitor.Screen}");
            }
        }
    }
}
