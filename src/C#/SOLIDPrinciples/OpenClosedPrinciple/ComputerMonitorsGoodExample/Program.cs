using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace ComputerMonitorsGoodExample
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

        public override string ToString() => $"Name: {Name}, Type: {Type}, Screen: {Screen}";
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T item);
    }

    public interface IFilter<T>
    {
        List<T> Filter(IEnumerable<T> monitors, ISpecification<T> specification);
    }

    public class MonitorTypeSpecification : ISpecification<ComputerMonitor>
    {
        private readonly MonitorType _monitorType;

        public MonitorTypeSpecification(MonitorType monitorType)
        {
            _monitorType = monitorType;
        }

        public bool IsSatisfied(ComputerMonitor computerMonitor) => computerMonitor.Type == _monitorType;
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
    
    public class MonitorFilter : IFilter<ComputerMonitor>
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

            var ledMonitors = monitorFilter.Filter(computerMonitors, new MonitorTypeSpecification(MonitorType.LED));

            Console.WriteLine($"All {MonitorType.LED} monitors: ");
            ledMonitors.ForEach(lm => Console.WriteLine(lm.ToString()));
            Console.WriteLine(Environment.NewLine + new string('=', 60) + Environment.NewLine);

            var wideScreenMonitors = monitorFilter.Filter(computerMonitors, new ScreenTypeSpecification(ScreenType.WideScreen));

            Console.WriteLine($"All {ScreenType.WideScreen} monitors: ");
            wideScreenMonitors.ForEach(wsm => Console.WriteLine(wsm.ToString()));
        }
    }
}
