using System;

namespace CustomerPropertyInjection
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

    public class CustomerBusinessLogic
    {
        public CustomerBusinessLogic()
        {

        }

        public CustomerDataAccess CustomerDataAccess { get; set; }

        public string ProcessCustomerData(int id) => CustomerDataAccess.GetCustomerName(id);
    }

    public class CustomerService
    {
        private CustomerBusinessLogic _customerBusinessLogic;

        public CustomerService()
        {
            _customerBusinessLogic = new CustomerBusinessLogic();
            _customerBusinessLogic.CustomerDataAccess = new CustomerDataAccess();
        }

        public string GetCustomerName(int id) => _customerBusinessLogic.ProcessCustomerData(id);
    }

    public class Program
    {
        static void Main(string[] args)
        {
            CustomerService customerService = new CustomerService();
            Console.WriteLine(customerService.GetCustomerName(1));
        }
    }
}
