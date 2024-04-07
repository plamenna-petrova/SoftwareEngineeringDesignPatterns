using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleExamples.ChainReactionExample
{
    public class FontEditor : Participant
    {
        public FontEditor(Mediator mediator) : base(mediator)
        {

        }

        public void Enable() => Console.WriteLine("FontEditor is enabled.");

        public void Disable() => Console.WriteLine("FontEditor is disable.");
    }
}
