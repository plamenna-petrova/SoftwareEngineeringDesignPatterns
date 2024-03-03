using System;

namespace PrintersBadExample
{
    public interface IMultiTaskPrinter
    {
        void Print(string content);

        void Scan(string content);

        void Fax(string content);

        void PrintDuplex(string content);
    }

    public class LiquidInkjetPrinter : IMultiTaskPrinter
    {
        public void Print(string content)
        {
            Console.WriteLine($"{GetType().Name} printed {content}");
        }

        public void Scan(string content)
        {
            throw new NotImplementedException();
        }

        public void Fax(string content)
        {
            throw new NotImplementedException();
        }

        public void PrintDuplex(string content)
        {
            Console.WriteLine($"{GetType().Name} printed with duplex {content}");
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
            try
            {
                const string ContentToProcess = "Creativity takes courage";

                IMultiTaskPrinter liquidInkjetPrinter = new LiquidInkjetPrinter();
                liquidInkjetPrinter.Print(ContentToProcess);
                liquidInkjetPrinter.Scan(ContentToProcess);
                //liquidInkjetPrinter.Fax(ContentToProcess);
                liquidInkjetPrinter.PrintDuplex(ContentToProcess);

                IMultiTaskPrinter laserJetPrinter = new LaserJetPrinter();
                laserJetPrinter.Print(ContentToProcess);
                laserJetPrinter.Scan(ContentToProcess);
                laserJetPrinter.Fax(ContentToProcess);
                laserJetPrinter.PrintDuplex(ContentToProcess);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
