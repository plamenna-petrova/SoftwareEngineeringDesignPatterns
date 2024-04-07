using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS
{
    public interface IMediator
    {
        object Send(IRequest request);
    }
}
