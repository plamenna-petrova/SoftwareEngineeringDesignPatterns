using System;

namespace ComputerSystem
{
    public class CPU
    {
        public string Freeze()
        {
            return "CPU is freezing";
        }

        public string Jump(string address)
        {
            return $"CPU is jumping to {address}";
        }

        public string Execute()
        {
            return "CPU is executing commands";
        }
    }

    public class Memory
    {
        public string Load(string address, string data)
        {
            return $"Memory is loading data at {address} with data {data}";
        }
    }

    public class HardDrive
    {
        public string Read(string lba, string size)
        {
            return $"HardDrive is reading data at LBA {lba} with size {size}";
        }
    }

    public class GPU
    {
        public string Render(string graphics)
        {
            return $"GPU is rendering graphics: {graphics}";
        }
    }

    public interface IComputerFacade
    {
        void Start();
    }

    public class ComputerFacade : IComputerFacade
    {
        private readonly CPU cpu;

        private readonly Memory memory;

        private readonly HardDrive hardDrive;

        private readonly GPU gpu;

        public ComputerFacade()
        {
            cpu = new CPU();
            memory = new Memory();
            hardDrive = new HardDrive();
            gpu = new GPU();
        }

        public void Start()
        {
            Console.WriteLine(cpu.Freeze());
            Console.WriteLine(memory.Load("0x0", "BOOT SECTOR"));
            Console.WriteLine(cpu.Jump("0x0"));
            Console.WriteLine(cpu.Execute());
            Console.WriteLine(hardDrive.Read("BOOT_SECTOR", "BOOT_SECTOR_SIZE"));
            Console.WriteLine(gpu.Render("BOOT_SCREEN"));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            IComputerFacade computerFacade = new ComputerFacade();
            computerFacade.Start();
        }
    }
}
