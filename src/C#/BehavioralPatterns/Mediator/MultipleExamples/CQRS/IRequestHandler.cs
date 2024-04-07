using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.CQRS
{
    public interface IRequestHandler<T> where T : IRequest
    {
        object Execute(T request);
    }
}
