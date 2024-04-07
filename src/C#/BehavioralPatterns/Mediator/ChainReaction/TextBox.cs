using System;
using System.Collections.Generic;
using System.Text;

namespace ChainReaction
{
    public class TextBox : Participant
    {
        public TextBox(Mediator mediator) : base(mediator)
        {

        }

        public bool IsEnabled { get; set; } = false;

        public void Enable()
        {
            IsEnabled = true;
            Console.WriteLine("TextBox is enabled.");
            Mediator.OnStateChanged(this);
        }

        public void Disable()
        {
            IsEnabled = false;
            Console.WriteLine("TextBox is disabled.");
            Mediator.OnStateChanged(this);
        }
    }
}
