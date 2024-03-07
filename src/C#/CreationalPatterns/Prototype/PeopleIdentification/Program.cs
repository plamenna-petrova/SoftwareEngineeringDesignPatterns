using System;

namespace PeopleIdentification
{
    public class IDInfo
    {
        public IDInfo(int idNumber)
        {
            IDNumber = idNumber;
        }

        public int IDNumber { get; set; }
    }

    public abstract class Person
    {
        public Person(int age, DateTime birthDate, string name, IDInfo idInfo)
        {
            Age = age;
            BirthDate = birthDate;
            Name = name;
            IDInfo = idInfo;
        }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public string Name { get; set; }

        public IDInfo IDInfo { get; set; }

        public abstract Person ShallowCopy();

        public abstract Person DeepCopy();
    }

    public class Traveler : Person
    {
        public Traveler(int age, DateTime birthDate, string name, IDInfo idInfo)
            : base(age, birthDate, name, idInfo)
        {

        }

        public override Person ShallowCopy() => (Person) MemberwiseClone();

        public override Person DeepCopy()
        {
            Person clonedPerson = ShallowCopy();
            clonedPerson.IDInfo = new IDInfo(IDInfo.IDNumber);
            return clonedPerson;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Traveler firstTraveler = new Traveler(42, Convert.ToDateTime("1977-01-01"), "Jack Daniels", new IDInfo(666));

            Traveler secondTraveler = firstTraveler.ShallowCopy() as Traveler;

            Traveler thirdTraveler = firstTraveler.DeepCopy() as Traveler;

            Console.WriteLine("Original values of the first, second and third travelers: ");
            Console.WriteLine("Traveler #1 instance values: ");
            DisplayValues(firstTraveler);
            Console.WriteLine("Traveler #2 instance values: ");
            DisplayValues(secondTraveler);
            Console.WriteLine("Traveler #3 instance values: ");
            DisplayValues(thirdTraveler);

            firstTraveler.Age = 32;
            firstTraveler.BirthDate = Convert.ToDateTime("1990-05-06");
            firstTraveler.Name = "Frank";
            firstTraveler.IDInfo.IDNumber = 7879;

            Console.WriteLine("Values of the first, second and third travelers after applying changes to the first one: ");
            Console.WriteLine("Traveler #1 instance values: ");
            DisplayValues(firstTraveler);
            Console.WriteLine("Traveler #2 instance values (reference values have changed - shallow copy) :");
            DisplayValues(secondTraveler);
            Console.WriteLine("Traveler #3 instance values (everything was kept the same - deep copy) : ");
            DisplayValues(thirdTraveler);
        }

        private static void DisplayValues(Person person)
        {
            Console.WriteLine(new string(' ', 10) + "Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
                person.Name, person.Age, person.BirthDate);
            Console.WriteLine(new string(' ', 10) + "ID#: {0:d}", person.IDInfo.IDNumber);
        }
    }
}
