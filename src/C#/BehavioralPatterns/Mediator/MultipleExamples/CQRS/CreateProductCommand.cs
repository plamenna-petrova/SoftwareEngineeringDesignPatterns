using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.CQRS
{
    public class CreateProductCommand : IRequest
    {
        public CreateProductCommand(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
