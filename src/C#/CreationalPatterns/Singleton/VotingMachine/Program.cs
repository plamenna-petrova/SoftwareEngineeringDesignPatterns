using System;
using System.Linq;
using System.Threading.Tasks;

namespace VotingMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            VotingMachineV1 firstVotingMachineV1 = VotingMachineV1.VotingMachineInstance;
            VotingMachineV1 secondVotingMachineV1 = VotingMachineV1.VotingMachineInstance;
            VotingMachineV1 thirdVotingMachineV1 = VotingMachineV1.VotingMachineInstance;

            for (int i = 0; i < 3; i++)
            {
                firstVotingMachineV1.RegisterVote();
                secondVotingMachineV1.RegisterVote();
                thirdVotingMachineV1.RegisterVote();
            }

            Console.WriteLine($"Total votes: {firstVotingMachineV1.TotalVotes}");
            Console.WriteLine(new string('-', 50));

            var numbers = Enumerable.Range(0, 10);

            Parallel.ForEach(numbers, i =>
            {
                var votingMachineV1 = VotingMachineV1.VotingMachineInstance;
                votingMachineV1.RegisterVote();
            });

            Console.WriteLine($"Total votes: {VotingMachineV1.VotingMachineInstance.TotalVotes}");
            Console.WriteLine(new string('-', 50));

            Parallel.ForEach(numbers, i =>
            {
                var votingMachineV2 = VotingMachineV2.VotingMachineInstance;
                votingMachineV2.RegisterVote();
            });

            Console.WriteLine($"Total votes: {VotingMachineV2.VotingMachineInstance.TotalVotes}");
            Console.WriteLine(new string('-', 50));

            Parallel.ForEach(numbers, i =>
            {
                var votingMachineV3 = VotingMachineV3.VotingMachineInstance;
                votingMachineV3.RegisterVote();
            });

            Console.WriteLine($"Total votes: {VotingMachineV3.VotingMachineInstance.TotalVotes}");
            Console.WriteLine(new string('-', 50));

            Parallel.ForEach(numbers, i =>
            {
                var votingMachineV4 = VotingMachineV4.VotingMachineInstance;
                votingMachineV4.RegisterVote();
            });

            Console.WriteLine($"Total votes: {VotingMachineV4.VotingMachineInstance.TotalVotes}");
        }
    }
}
