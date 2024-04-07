using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.CQRS
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        public object Execute(CreateProductCommand createProductCommand)
        {
            Console.WriteLine("Creating the product: " + createProductCommand.Name);
            return true;
        }
    }
}
