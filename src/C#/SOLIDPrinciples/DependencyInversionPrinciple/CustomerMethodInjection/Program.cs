using System;

namespace CustomerMethodInjection
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

    public interface IDataAccessDependency
    {
        void SetDependency(ICustomerDataAccess customerDataAccess);
    }

    public class CustomerBusinessLogic : IDataAccessDependency
    {
        private ICustomerDataAccess _customerDataAccess;

        public CustomerBusinessLogic()
        {

        }

        public void SetDependency(ICustomerDataAccess customerDataAccess)
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
            _customerBusinessLogic = new CustomerBusinessLogic();
            ((IDataAccessDependency)_customerBusinessLogic).SetDependency(new CustomerDataAccess());
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
