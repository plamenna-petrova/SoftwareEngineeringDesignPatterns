using System;

namespace CustomerConstructorInjection
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
        private ICustomerDataAccess _customerDataAccess;

        public CustomerBusinessLogic(ICustomerDataAccess customerDataAccess)
        {
            _customerDataAccess = customerDataAccess;
        }

        public string ProcessCustomerData(int id) => _customerDataAccess.GetCustomerName(id);
    }

    public class CustomerService
    {
        private CustomerBusinessLogic _customerBusinessLogic;

        public CustomerService()
        {
            _customerBusinessLogic = new CustomerBusinessLogic(new CustomerDataAccess());
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
