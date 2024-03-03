using System;
using System.Collections.Generic;
using System.Text;

namespace VotingMachine
{
    public sealed class VotingMachineV4
    {
        private int totalVotes = 0;

        private static readonly Lazy<VotingMachineV4> votingMachineInstance = new Lazy<VotingMachineV4>(() => new VotingMachineV4());

        private VotingMachineV4()
        {

        }

        public int TotalVotes => totalVotes;

        public static VotingMachineV4 VotingMachineInstance => votingMachineInstance.Value;

        public void RegisterVote()
        {
            totalVotes++;
            Console.WriteLine($"Registered Vote #{totalVotes}");
        }
    }
}
