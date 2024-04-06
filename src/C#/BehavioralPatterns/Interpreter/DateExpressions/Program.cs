using System;
using System.Collections.Generic;

namespace DateExpressions
{
    public class Context
    {
        public Context(DateTime date)
        {
            Date = date;
        }

        public string Expression { get; set; }

        public DateTime Date { get; set; }
    }

    public interface IExpression
    {
        void Evaluate(Context context);
    }

    public class DayExpression : IExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.Expression;
            context.Expression = expression.Replace("DD", context.Date.Day.ToString());
        }
    }

    public class MonthExpression : IExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.Expression;
            context.Expression = expression.Replace("MM", context.Date.Month.ToString());
        }
    }

    public class YearExpression : IExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.Expression;
            context.Expression = expression.Replace("YYYY", context.Date.Year.ToString());
        }
    }

    public class SeparatorExpression : IExpression
    {
        public void Evaluate(Context context)
        {
            string expression = context.Expression;
            context.Expression = expression.Replace(" ", "-");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            List<IExpression> dateExpressions = new List<IExpression>();

            Context context = new Context(DateTime.Now);

            Console.WriteLine("Please select the Expression: MM DD YYYY or YYYY MM DD or DD MM YYYY ");

            context.Expression = Console.ReadLine();

            string[] dateExpressionSplittedArray = context.Expression.Split(new char[] { ' ' });

            foreach (var expressionComponent in dateExpressionSplittedArray)
            {
                if (expressionComponent == "DD")
                {
                    dateExpressions.Add(new DayExpression());
                }
                else if (expressionComponent == "MM")
                {
                    dateExpressions.Add(new MonthExpression());
                }
                else if (expressionComponent == "YYYY")
                {
                    dateExpressions.Add(new YearExpression());
                }
            }

            dateExpressions.Add(new SeparatorExpression());

            foreach (var dateExpression in dateExpressions)
            {
                dateExpression.Evaluate(context);
            }

            Console.WriteLine(context.Expression);
        }
    }
}
