using System;

namespace OrdersApproval
{
    public class Order
    {
        public string OrderId { get; set; }

        public decimal TotalAmount { get; set; }
    }

    public interface IOrderHandler
    {
        void SetNextHandler(IOrderHandler orderHandler);

        void DistributeOrderProcessing(Order order);
    }

    public abstract class BaseOrderHandler : IOrderHandler
    {
        private IOrderHandler _nextOrderHandler;

        public void SetNextHandler(IOrderHandler nextOrderHandler)
        {
            _nextOrderHandler = nextOrderHandler;
        }

        public virtual void DistributeOrderProcessing(Order order)
        {
            if (CanProcessOrder(order))
            {
                ProcessOrder(order);
            }
            else if (_nextOrderHandler != null)
            {
                _nextOrderHandler.DistributeOrderProcessing(order);
            }
            else
            {
                Console.WriteLine("Order cannot be processed");
            }
        }

        protected abstract bool CanProcessOrder(Order order);

        protected abstract void ProcessOrder(Order order);
    }

    public class ValidationHandler : BaseOrderHandler
    {
        protected override bool CanProcessOrder(Order order)
        {
            return true;
        }

        protected override void ProcessOrder(Order order)
        {
            Console.WriteLine("Validation completed for order: " + order.OrderId);
        }
    }

    public class InventoryCheckHandler : BaseOrderHandler
    {
        protected override bool CanProcessOrder(Order order)
        {
            return true;
        }

        protected override void ProcessOrder(Order order)
        {
            Console.WriteLine("Inventory check completed for order: " + order.OrderId);
        }
    }

    public class PaymentVerificationHandler : BaseOrderHandler
    {
        protected override bool CanProcessOrder(Order order)
        {
            return true;
        }

        protected override void ProcessOrder(Order order)
        {
            Console.WriteLine("Payment verification completed for order: " + order.OrderId);
        }
    }

    public class ShippingConfirmationHandler : BaseOrderHandler
    {
        protected override bool CanProcessOrder(Order order)
        {
            return true;
        }

        protected override void ProcessOrder(Order order)
        {
            Console.WriteLine("Shipping confirmation completed for order: " + order.OrderId);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ValidationHandler validationHandler = new ValidationHandler();
            InventoryCheckHandler inventoryCheckHandler = new InventoryCheckHandler();
            PaymentVerificationHandler paymentVerificationHandler = new PaymentVerificationHandler();
            ShippingConfirmationHandler shippingConfirmationHandler = new ShippingConfirmationHandler();

            validationHandler.SetNextHandler(inventoryCheckHandler);
            inventoryCheckHandler.SetNextHandler(paymentVerificationHandler);
            paymentVerificationHandler.SetNextHandler(shippingConfirmationHandler);

            Order order = new Order { OrderId = "12345", TotalAmount = 100.0M };

            validationHandler.DistributeOrderProcessing(order);
        }
    }
}
