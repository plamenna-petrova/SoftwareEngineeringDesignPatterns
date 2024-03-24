using System;

namespace Folder
{
    public class Employee
    {
        public Employee(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }

    public interface ISharedFolder
    {
        void PerformReadWriteOperations();
    }

    public class SharedFolder : ISharedFolder
    {
        public void PerformReadWriteOperations()
        {
            Console.WriteLine("Performing Read Write operation on the Shared Folder");
        }
    }

    public class SharedFolderProxy : ISharedFolder
    {
        private ISharedFolder sharedFolder;

        private readonly Employee employee;

        public SharedFolderProxy(Employee employee)
        {
            this.employee = employee;
        }

        public void PerformReadWriteOperations()
        {
            if (employee.Role.ToUpper() == "CEO" || employee.Role.ToUpper() == "MANAGER")
            {
                sharedFolder = new SharedFolder();
                Console.WriteLine("Shared Folder Proxy makes call to the RealFolder 'PerformReadWriteOperations method'");
                sharedFolder.PerformReadWriteOperations();
            }
            else
            {
                Console.WriteLine("Shared Folder proxy says 'You don't have permission to access this folder'");
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client passing employee with Role Developer to folder proxy");
            Employee firstEmployee = new Employee("john_doe123", "JohnDoe123/", "Developer");
            SharedFolderProxy firstSharedFolderProxy = new SharedFolderProxy(firstEmployee);
            firstSharedFolderProxy.PerformReadWriteOperations();

            Console.WriteLine();

            Console.WriteLine("Client passing employee with Role Manager to folder proxy");
            Employee secondEmployee = new Employee("jane_doex", "JaneDoeX/", "Manager");
            SharedFolderProxy secondSharedFolderProxy = new SharedFolderProxy(secondEmployee);
            secondSharedFolderProxy.PerformReadWriteOperations();
        }
    }
}
