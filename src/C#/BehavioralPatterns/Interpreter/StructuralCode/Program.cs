using System;
using System.Collections.Generic;

namespace StructuralCode
{
    public class Context
    {

    }

    public abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    public class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called Terminal.Interpret()");
        }
    }

    public class NonterminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called Nonterminal.Interpret()");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            List<AbstractExpression> listOfExpressions = new List<AbstractExpression>
            {
                new TerminalExpression(),
                new NonterminalExpression(),
                new TerminalExpression(),
                new TerminalExpression()
            };

            foreach (AbstractExpression expression in listOfExpressions)
            {
                expression.Interpret(context);
            }
        }
    }
}
