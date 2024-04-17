using System;
using System.Collections.Generic;

namespace StructuralCode
{
    public abstract class Observer
    {
        public abstract void Update();
    }

    public class ConcreteObserver : Observer
    {
        private readonly string name;

        private string observerState;

        private ConcreteSubject concreteSubject;

        public ConcreteObserver(ConcreteSubject concreteSubject, string name)
        {
            this.concreteSubject = concreteSubject;
            this.name = name;
        }

        public ConcreteSubject ConcreteSubject
        {
            get { return concreteSubject; }
            set { concreteSubject = value; }
        }

        public override void Update()
        {
            observerState = ConcreteSubject.SubjectState;
            Console.WriteLine("Observer {0}'s new state is {1}", name, observerState);
        }
    }

    public abstract class Subject
    {
        private readonly List<Observer> observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer observer in observers)
            {
                observer.Update();
            }
        }
    }

    public class ConcreteSubject : Subject
    {
        private string subjectState;

        public string SubjectState
        {
            get { return subjectState; }
            set { subjectState = value; }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ConcreteSubject concreteSubject = new ConcreteSubject();

            concreteSubject.Attach(new ConcreteObserver(concreteSubject, "X"));
            concreteSubject.Attach(new ConcreteObserver(concreteSubject, "Y"));
            concreteSubject.Attach(new ConcreteObserver(concreteSubject, "Z"));

            concreteSubject.SubjectState = "ABC";
            concreteSubject.Notify();

            Console.ReadKey();
        }
    }
}
