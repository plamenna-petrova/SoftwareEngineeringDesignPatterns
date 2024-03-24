using System;

namespace MathProxy
{
    public interface IMath
    {
        double Add(double x, double y);

        double Sub(double x, double y);

        double Mul(double x, double y);

        double Div(double x, double y);
    }

    public class Math : IMath
    {
        public double Add(double x, double y) => x + y;

        public double Sub(double x, double y) => x - y;

        public double Mul(double x, double y) => x * y;

        public double Div(double x, double y) => x / y;
    }

    public class MathProxy : IMath
    {
        private readonly Math math = new Math();

        public double Add(double x, double y) => math.Add(x, y);

        public double Sub(double x, double y) => math.Sub(x, y);

        public double Mul(double x, double y) => math.Mul(x, y);

        public double Div(double x, double y) => math.Div(x, y);
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            MathProxy mathProxy = new MathProxy();

            Console.WriteLine("4 + 2 = " + mathProxy.Add(4, 2));
            Console.WriteLine("4 - 2 = " + mathProxy.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + mathProxy.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + mathProxy.Div(4, 2));
        }
    }
}
