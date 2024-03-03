using System;

namespace CustomerBadExample
{
    public interface ICustomerDataAccess
    {
        string GetCustomerName(int id);
    }

    public class CustomerDataAccess : ICustomerDataAccess
    {
        public CustomerDataAccess()
        {

        }

        public string GetCustomerName(int id) => $"Dummy Customer #{id} Name";
    }

    public class DataAccessFactory
    {
        public static ICustomerDataAccess GetCustomerDataAccess() => new CustomerDataAccess();
    }

    public class CustomerBusinessLogic
    {
        private ICustomerDataAccess _customerDataAccess;

        public CustomerBusinessLogic()
        {
            _customerDataAccess = DataAccessFactory.GetCustomerDataAccess();
        }

        public string GetCustomerName(int id) => _customerDataAccess.GetCustomerName(id);
    }

    public class Program
    {
        static void Main(string[] args)
        {
            CustomerBusinessLogic customerBusinessLogic = new CustomerBusinessLogic();
            Console.WriteLine(customerBusinessLogic.GetCustomerName(1));
        }
    }
}
