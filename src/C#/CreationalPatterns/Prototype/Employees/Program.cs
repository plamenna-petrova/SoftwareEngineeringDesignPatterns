using System;

namespace Employees
{
    public abstract class Employee
    {
        public string Name { get; set; }

        public string Department { get; set; }

        public Address Address { get; set; }

        public abstract Employee GetShallowCopy();

        public abstract Employee GetDeepCopy();

        public void GetDetails() => Console.WriteLine($"Employee Details: Name - {Name}, Department - {Department}, " +
            $"Address - {Address.Name}");
    }

    public class SoftwareDeveloper : Employee
    {
        public override Employee GetShallowCopy() => (Employee) MemberwiseClone();

        public override Employee GetDeepCopy()
        {
            Employee clonedEmployee = GetShallowCopy();
            clonedEmployee.Address = Address.GetClone();
            return clonedEmployee;
        }
    }

    public class Address
    {
        public string Name { get; set; }

        public Address GetClone() => (Address) MemberwiseClone();
    }

    public class Program
    {
        static void Main(string[] args)
        {
            SoftwareDeveloper firstSoftwareDeveloper = new SoftwareDeveloper
            {
                Name = "John",
                Department = "IT",
                Address = new Address { Name = "London, UK" }
            };

            SoftwareDeveloper secondSoftwareDeveloper = (SoftwareDeveloper) firstSoftwareDeveloper.GetShallowCopy();

            SoftwareDeveloper thirdSoftwareDeveloper = (SoftwareDeveloper) firstSoftwareDeveloper.GetDeepCopy();

            Console.WriteLine("Original values: \r\n");

            firstSoftwareDeveloper.GetDetails();
            secondSoftwareDeveloper.GetDetails();
            thirdSoftwareDeveloper.GetDetails();

            Console.WriteLine();

            secondSoftwareDeveloper.Name = "James";
            secondSoftwareDeveloper.Address.Name = "New York, USA";

            Console.WriteLine("After applying changes: \r\n");

            firstSoftwareDeveloper.GetDetails();
            secondSoftwareDeveloper.GetDetails();
            thirdSoftwareDeveloper.GetDetails();
        }
    }
}
