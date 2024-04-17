using System;

namespace StructuralCode
{
    public abstract class State
    {
        public abstract void Handle(Context context);
    }

    public class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }

    public class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateA();
        }
    }

    public class Context
    {
        private State state;

        public Context(State state)
        {
            State = state;
        }

        public State State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                Console.WriteLine($"State: {state.GetType().Name}");
            }
        }

        public void Request()
        {
            state.Handle(this);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var context = new Context(new ConcreteStateA());

            for (int i = 0; i < 4; i++)
            {
                context.Request();
            }
        }
    }
}
