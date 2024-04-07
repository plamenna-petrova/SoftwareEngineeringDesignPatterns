using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS
{
    public interface IRequestHandler<T> where T : IRequest
    {
        object Execute(T request);
    }
}
