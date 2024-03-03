using System;
using System.Collections.Generic;
using System.Text;

namespace VotingMachine
{
    public sealed class VotingMachineV1
    {
        private int totalVotes = 0;

        private static VotingMachineV1 votingMachineInstance;

        private VotingMachineV1()
        {

        }
        public int TotalVotes => totalVotes;

        public static VotingMachineV1 VotingMachineInstance
        {
            get
            {
                votingMachineInstance ??= new VotingMachineV1();

                return votingMachineInstance;
            }
        }

        public void RegisterVote()
        {
            totalVotes++;
            Console.WriteLine($"Registered Vote #{totalVotes}");
        }
    }
}
