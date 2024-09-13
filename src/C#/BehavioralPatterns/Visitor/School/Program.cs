using System;
using System.Collections.Generic;

namespace School
{
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    public class Kid : IElement
    {
        public Kid(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public interface IVisitor
    {
        void Visit(IElement element);
    }

    public class Doctor : IVisitor
    {
        public Doctor(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void Visit(IElement element)
        {
            Kid kid = (Kid)element;
            Console.WriteLine($"Doctor: {Name} did the health checkup of the child: {kid.Name}");
        }
    }

    public class Teacher : IVisitor
    {
        public Teacher(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void Visit(IElement element)
        {
            Kid kid = (Kid)element;
            Console.WriteLine($"Teacher: {Name} assessed the daily work of the child: {kid.Name}");
        }
    }

    public class School
    {
        private static readonly List<IElement> elements = new List<IElement>();

        static School()
        {
            elements = new List<IElement>
            {
                new Kid("John"),
                new Kid("Sarah"),
                new Kid("Kim")
            };
        }

        public void PerformOperation(IVisitor visitor)
        {
            foreach (var kid in elements)
            {
                kid.Accept(visitor); 
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            School school = new School();

            var doctor = new Doctor("James");
            school.PerformOperation(doctor);
            Console.WriteLine();

            var teacher = new Teacher("Mr. Smith");
            school.PerformOperation(teacher);
        }
    }
}
