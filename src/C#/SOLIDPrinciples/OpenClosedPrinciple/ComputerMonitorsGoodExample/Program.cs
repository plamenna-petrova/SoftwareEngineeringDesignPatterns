using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace ComputerMonitorsGoodExample
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

        public override string ToString() => $"Name: {Name}, Type: {Type}, Screen: {Screen}";
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T item);
    }

    public interface IFilter<T>
    {
        List<T> Filter(IEnumerable<T> computerMonitors, ISpecification<T> specification);
    }

    public class MonitorTypeSpecification : ISpecification<ComputerMonitor>
    {
        private readonly ComputerMonitorType _computerMonitorType;

        public MonitorTypeSpecification(ComputerMonitorType computerMonitorType)
        {
            _computerMonitorType = computerMonitorType;
        }

        public bool IsSatisfied(ComputerMonitor computerMonitor) => computerMonitor.Type == _computerMonitorType;
    }

    public class ScreenTypeSpecification : ISpecification<ComputerMonitor> 
    {
        private readonly ScreenType _screenType;

        public ScreenTypeSpecification(ScreenType screenType)
        {
            _screenType = screenType;
        }

        public bool IsSatisfied(ComputerMonitor computerMonitor) => computerMonitor.Screen == _screenType;
    }
    
    public class ComputerMonitorFilter : IFilter<ComputerMonitor>
    {
        public List<ComputerMonitor> Filter(IEnumerable<ComputerMonitor> computerMonitors, 
            ISpecification<ComputerMonitor> computerMonitorSpecification) => 
                computerMonitors.Where(cm => computerMonitorSpecification.IsSatisfied(cm)).ToList();
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

            var ledComputerMonitors = computerMonitorFilter.Filter(computerMonitors, new MonitorTypeSpecification(ComputerMonitorType.LED));

            Console.WriteLine($"All {ComputerMonitorType.LED} monitors: ");
            ledComputerMonitors.ForEach(lm => Console.WriteLine(lm.ToString()));
            Console.WriteLine(Environment.NewLine + new string('=', 60) + Environment.NewLine);

            var wideScreenComputerMonitors = computerMonitorFilter.Filter(computerMonitors, new ScreenTypeSpecification(ScreenType.WideScreen));

            Console.WriteLine($"All {ScreenType.WideScreen} monitors: ");
            wideScreenComputerMonitors.ForEach(wsm => Console.WriteLine(wsm.ToString()));
        }
    }
}
