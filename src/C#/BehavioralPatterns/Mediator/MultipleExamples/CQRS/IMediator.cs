using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.CQRS
{
    public interface IMediator
    {
        object Send(IRequest request);
    }
}
