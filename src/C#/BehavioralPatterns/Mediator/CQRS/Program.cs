using System;
using System.Collections.Generic;

namespace CQRS
{
    public class Program
    {
        static void Main(string[] args)
        {
            ExecuteCQRSExample();
        }

        private static void ExecuteCQRSExample()
        {
            ProductsController productsController = new ProductsController(new Mediator(new Dictionary<Type, Type>()
            {
                { typeof(CreateProductCommand), typeof(CreateProductCommandHandler) },
                { typeof(GetProductsRequest), typeof(GetProductsRequestHandler) }
            }));

            productsController.CreateProduct("Product 1", 100);

            var products = productsController.GetProducts();
        }
    }
}
