using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SmartDevices
{
    public abstract class SmartDevice
    {
        public abstract decimal Price { get; set; }

        public List<string> Characteristics { get; set; }

        public override string ToString()
        {
            return $"{GetType().Name}'s Details:\nPrice: {Price}\nCharacteristics: {string.Join(", ", Characteristics)}";
        }
    }

    public class SamsungGalaxyS23Ultra : SmartDevice
    {
        public override decimal Price { get; set; } = 1970.00m;
    }

    public class XiaomiRedmiNote12Pro : SmartDevice
    {
        public override decimal Price { get; set; } = 630.00m;
    }

    public class IPhone12ProMax : SmartDevice
    {
        public override decimal Price { get; set; } = 1470.00m;
    }

    public class GalaxyWatchClassic : SmartDevice
    {
        public override decimal Price { get; set; } = 760.00m;
    }

    public class XiaomiWatch2Pro : SmartDevice
    {
        public override decimal Price { get; set; } = 620.00m;
    }

    public class AppleWatchUltra2 : SmartDevice
    {
        public override decimal Price { get; set; } = 830.00m;
    }

    public class GalaxyBuds2Pro : SmartDevice
    {
        public override decimal Price { get; set; } = 470.00m;
    }

    public class RedmiAirdotsBasic2 : SmartDevice
    {
        public override decimal Price { get; set; } = 267.00m;
    }

    public class AirPods : SmartDevice
    {
        public override decimal Price { get; set; } = 950.00m;
    }

    public enum SmartDeviceBrand
    {
        Samsung,
        Xiaomi,
        Apple,
    }

    public interface ISmartDeviceCreator
    {
        SmartDevice CreateSmartDevice(SmartDeviceBrand smartDeviceBrand);
    }

    public class SmartPhoneCreator : ISmartDeviceCreator
    {
        public SmartDevice CreateSmartDevice(SmartDeviceBrand smartDeviceBrand)
        {
            return smartDeviceBrand switch
            {
                SmartDeviceBrand.Samsung => new SamsungGalaxyS23Ultra(),
                SmartDeviceBrand.Xiaomi => new XiaomiRedmiNote12Pro(),
                SmartDeviceBrand.Apple => new IPhone12ProMax(),
                _ => null,
            };
        }
    }

    public class SmartWatchCreator : ISmartDeviceCreator
    {
        public SmartDevice CreateSmartDevice(SmartDeviceBrand smartDeviceBrand)
        {
            return smartDeviceBrand switch
            {
                SmartDeviceBrand.Samsung => new GalaxyWatchClassic(),
                SmartDeviceBrand.Xiaomi => new XiaomiWatch2Pro(),
                SmartDeviceBrand.Apple => new AppleWatchUltra2(),
                _ => null,
            };
        }
    }

    public class EarbudsCreator : ISmartDeviceCreator
    {
        public SmartDevice CreateSmartDevice(SmartDeviceBrand smartDeviceBrand)
        {
            return smartDeviceBrand switch
            {
                SmartDeviceBrand.Samsung => new GalaxyBuds2Pro(),
                SmartDeviceBrand.Xiaomi => new RedmiAirdotsBasic2(),
                SmartDeviceBrand.Apple => new AirPods(),
                _ => null
            };
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Type[] executingAssemblyTypes = executingAssembly.GetTypes();

            var smartDeviceCreators = executingAssemblyTypes
                .Where(t => typeof(ISmartDeviceCreator).IsAssignableFrom(t) && !t.IsInterface)
                .Select(t => (ISmartDeviceCreator)Activator.CreateInstance(t))
                .ToList();

            Console.Write("Enter Smart Device Type - Smart Phone, Smart Watch or Earbuds: ");
            string smartDeviceType = Console.ReadLine();

            while (smartDeviceType != "END")
            {
                ISmartDeviceCreator smartDeviceCreator = smartDeviceCreators
                    .FirstOrDefault(sdc => sdc.GetType().Name.StartsWith(string.Join(string.Empty, smartDeviceType.Split())));

                while (smartDeviceCreator == null)
                {
                    Console.Write("Enter valid smart device type: ");
                    smartDeviceType = Console.ReadLine();
                    smartDeviceCreator = smartDeviceCreators
                        .FirstOrDefault(sdc => sdc.GetType().Name.StartsWith(string.Join(string.Empty, smartDeviceType.Split())));
                }

                Console.Write("Enter Smart Device Brand - Samsung, Xiaomi, or Apple: ");
                string smartDeviceBrandInput = Console.ReadLine();

                SmartDeviceBrand smartDeviceBrand;

                while (!Enum.TryParse(smartDeviceBrandInput, out smartDeviceBrand))
                {
                    Console.Write("Enter valid smart device brand: ");
                    smartDeviceBrandInput = Console.ReadLine();
                }

                SmartDevice smartDevice = smartDeviceCreator.CreateSmartDevice(smartDeviceBrand);

                Console.WriteLine($"Enter device characteristics for {smartDevice.GetType().Name} separated by '|' :");

                var smartDeviceCharacteristics = Console.ReadLine()
                    .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => c.Trim())
                    .ToList();

                smartDevice.Characteristics = smartDeviceCharacteristics;

                Console.WriteLine(smartDevice.ToString());
                Console.WriteLine(new string('=', 80));

                Console.Write("Enter Smart Device Type - Smart Phone, Smart Watch or Earbuds : ");
                smartDeviceType = Console.ReadLine();
            }
        }
    }
}
