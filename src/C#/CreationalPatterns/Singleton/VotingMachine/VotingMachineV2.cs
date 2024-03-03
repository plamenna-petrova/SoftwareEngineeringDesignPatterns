using System;
using System.Collections.Generic;
using System.Text;

namespace VotingMachine
{
    public sealed class VotingMachineV2
    {
        private int totalVotes = 0;

        private static VotingMachineV2 votingMachineInstance;

        private static readonly object lockObject = new object();

        private VotingMachineV2()
        {

        }

        public int TotalVotes => totalVotes;

        public static VotingMachineV2 VotingMachineInstance
        {
            get
            {
                if (votingMachineInstance == null)
                {
                    lock (lockObject)
                    {
                        votingMachineInstance ??= new VotingMachineV2();
                    }
                }

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
