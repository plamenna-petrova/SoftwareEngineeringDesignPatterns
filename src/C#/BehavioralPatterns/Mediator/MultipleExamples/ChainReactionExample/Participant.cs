using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.ChainReactionExample
{
    public abstract class Participant
    {
        protected Participant(Mediator mediator)
        {
            Mediator = mediator;
        }

        protected Mediator Mediator { get; private set; }
    }
}
