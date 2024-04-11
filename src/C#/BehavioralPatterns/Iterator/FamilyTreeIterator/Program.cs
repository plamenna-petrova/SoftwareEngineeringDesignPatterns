using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTreeIterator
{
    public class Person
    {
        public Person()
        {

        }

        public Person(string name, int birthYear)
        {
            Name = name;
            BirthYear = birthYear;
        }

        public string Name { get; set; }

        public int BirthYear { get; set; }

        public override string ToString() => $"[{Name}, {BirthYear}]";
    }

    public class Node<T>
    {
        public Node()
        {

        }

        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public T Data { get; set; }
    }

    public class Tree<T>
    {
        private Node<T> root;

        public Tree()
        {

        }

        public Tree(Node<T> head)
        {
            root = head;
        }

        public IEnumerable<T> Preorder => ScanPreorder(root);

        public IEnumerable<T> Where(Func<T, bool> filter)
        {
            foreach (T node in ScanPreorder(root))
            {
                if (filter(node))
                {
                    yield return node;
                }
            }
        }

        private IEnumerable<T> ScanPreorder(Node<T> root)
        {
            yield return root.Data;

            if (root.Left != null)
            {
                foreach (T node in ScanPreorder(root.Left))
                {
                    yield return node;
                }
            }

            if (root.Right != null)
            {
                foreach (T node in ScanPreorder(root.Right))
                {
                    yield return node;
                }
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var family = new Tree<Person>(
                new Node<Person>(
                    new Person("Tom", 1950),
                        new Node<Person>(
                            new Person("Peter", 1976),
                            new Node<Person>(new Person("Sarah", 2000), null,
                                new Node<Person>(new Person("James", 2000), null, null
                            )
                        ),
                        new Node<Person>(new Person("Robert", 1978), null,
                        new Node<Person>(new Person("Mark", 1982),
                            new Node<Person>(new Person("Carrie", 2005), null, null),
                             null)
                        )
                    ),
                    null
                )
            );

            Console.WriteLine("Full family");

            foreach (Person person in family.Preorder)
            {
                Console.Write(person + " ");
            }

            Console.WriteLine("\n");

            var selection = family.Where(p => p.BirthYear > 1980);

            selection = from p in family
                        where p.BirthYear > 1980
                        orderby p.Name
                        select p;

            Console.WriteLine("Born after 1980 1980 in alphabetical order");

            foreach (Person person in selection)
            {
                Console.Write(person + " ");
            }

            Console.WriteLine("\n");
        }
    }
}
