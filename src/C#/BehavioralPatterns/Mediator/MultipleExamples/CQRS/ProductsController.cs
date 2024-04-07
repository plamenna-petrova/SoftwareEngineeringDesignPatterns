using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.CQRS
{
    public class ProductsController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void CreateProduct(string productName, decimal productPrice)
        {
            _mediator.Send(new CreateProductCommand(productName, productPrice));
        }

        public object GetProducts()
        {
            return _mediator.Send(new GetProductsRequest());
        }
    }
}
