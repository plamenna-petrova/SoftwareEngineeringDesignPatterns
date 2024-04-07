using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.CQRS
{
    public class GetProductsRequestHandler : IRequestHandler<GetProductsRequest>
    {
        public object Execute(GetProductsRequest getProductsRequest)
        {
            Console.WriteLine("Returning the products");
            return new List<object> { new { Name = "product 1" }, new { Name = "product 2" } };
        }
    }
}
