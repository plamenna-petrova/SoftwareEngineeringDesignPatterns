using System;

namespace PrintersGoodExample
{
    public interface IPrinter
    {
        void Print(string content);

        void PrintDuplex(string content);
    }

    public interface IScanner
    {
        void Scan(string content);
    }

    public interface IFax
    {
        void Fax(string content);
    }

    public interface IMultiTaskPrinter : IPrinter, IScanner, IFax
    {

    }

    public class LiquidInkjetPrinter : IPrinter
    {
        public void Print(string content)
        {
            Console.WriteLine($"{GetType().Name} printed {content}");
        }

        public void PrintDuplex(string content)
        {
            Console.WriteLine($"{GetType().Name} printed with duplex {content}");
        }
    }

    public class Scanner : IScanner
    {
        public void Scan(string content)
        {
            Console.WriteLine($"{GetType().Name} scanned {content}");
        }
    }

    public class FaxMachine : IFax
    {
        public void Fax(string content)
        {
            Console.WriteLine($"{GetType().Name} faxed {content}");
        }
    }

    public class LaserJetPrinter : IMultiTaskPrinter
    {
        public void Print(string content)
        {
            Console.WriteLine($"{GetType().Name} printed {content}");
        }

        public void Scan(string content)
        {
            Console.WriteLine($"{GetType().Name} scanned {content}");
        }

        public void Fax(string content)
        {
            Console.WriteLine($"{GetType().Name} faxed {content}");
        }

        public void PrintDuplex(string content)
        {
            Console.WriteLine($"{GetType().Name} printed with duplex {content}");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            const string ContentToProcess = "Creativity takes courage";

            IPrinter liquidInkjetPrinter = new LiquidInkjetPrinter();
            liquidInkjetPrinter.Print(ContentToProcess);
            liquidInkjetPrinter.PrintDuplex(ContentToProcess);

            IScanner scanner = new Scanner();
            scanner.Scan(ContentToProcess);

            IFax faxMachine = new FaxMachine();
            faxMachine.Fax(ContentToProcess);

            IMultiTaskPrinter laserJetPrinter = new LaserJetPrinter();
            laserJetPrinter.Print(ContentToProcess);
            laserJetPrinter.Scan(ContentToProcess);
            laserJetPrinter.Fax(ContentToProcess);
            laserJetPrinter.PrintDuplex(ContentToProcess);
        }
    }
}
