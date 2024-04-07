using System;

namespace ChainReaction
{
    public class Program
    {
        static void Main(string[] args)
        {
            ExecuteChainReactionExample();
        }

        private static void ExecuteChainReactionExample()
        {
            var mediator = new Mediator();
            var dropdown = mediator.Dropdown;

            dropdown.SelectValue("Manual");
            dropdown.SelectValue("Auto");
        }
    }
}
