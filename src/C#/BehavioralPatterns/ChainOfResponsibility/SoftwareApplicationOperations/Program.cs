using System;

namespace SoftwareApplicationOperations
{
    public class Request
    {
        public string Content { get; set; }
    }

    public interface IRequestHandler
    {
        void SetNextHandler(IRequestHandler requestHandler);

        void HandleRequest(Request request);
    }

    public abstract class BaseRequestHandler : IRequestHandler
    {
        private IRequestHandler _nextRequestHandler;

        public void SetNextHandler(IRequestHandler nextRequestHandler)
        {
            _nextRequestHandler = nextRequestHandler;
        }

        public void HandleRequest(Request request)
        {
            ProcessRequest(request);

            _nextRequestHandler?.HandleRequest(request);
        }

        protected abstract void ProcessRequest(Request request);
    }

    public class AuthenticationHandler : BaseRequestHandler
    {
        protected override void ProcessRequest(Request request)
        {
            Console.WriteLine("Authentication handler processing request");
        }
    }

    public class AuthorizationHandler : BaseRequestHandler
    {
        protected override void ProcessRequest(Request request)
        {
            Console.WriteLine("Authorization handler processing request");
        }
    }

    public class ValidationHandler : BaseRequestHandler
    {
        protected override void ProcessRequest(Request request)
        {
            Console.WriteLine("Validation handler processing request");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            AuthenticationHandler authenticationHandler = new AuthenticationHandler();
            AuthorizationHandler authorizationHandler = new AuthorizationHandler();
            ValidationHandler validationHandler = new ValidationHandler();

            authenticationHandler.SetNextHandler(authorizationHandler);
            authorizationHandler.SetNextHandler(validationHandler);

            var request = new Request { Content = "Simple Request" };

            authenticationHandler.HandleRequest(request);
        }
    }
}
