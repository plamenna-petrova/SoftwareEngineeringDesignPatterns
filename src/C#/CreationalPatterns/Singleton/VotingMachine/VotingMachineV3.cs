using System;
using System.Collections.Generic;
using System.Text;

namespace VotingMachine
{
    public sealed class VotingMachineV3
    {
        private int totalVotes = 0;

        private static readonly VotingMachineV3 votingMachineInstance = new VotingMachineV3();

        private VotingMachineV3()
        {

        }

        public int TotalVotes => totalVotes;

        public static VotingMachineV3 VotingMachineInstance => votingMachineInstance;

        public void RegisterVote()
        {
            totalVotes++;
            Console.WriteLine($"Registered Vote #{totalVotes}");
        }
    }
}
