import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

public class Main {
    public static void main(String[] args) {
        VotingMachineV1 firstVotingMachineV1 = VotingMachineV1.getVotingMachineInstance();
        VotingMachineV1 secondVotingMachineV1 = VotingMachineV1.getVotingMachineInstance();
        VotingMachineV1 thirdVotingMachineV1 = VotingMachineV1.getVotingMachineInstance();

        for (int i = 0; i < 3; i++) {
            firstVotingMachineV1.registerVote();
            secondVotingMachineV1.registerVote();
            thirdVotingMachineV1.registerVote();
        }

        System.out.println("Total votes: " + firstVotingMachineV1.getTotalVotes());
        System.out.println(new String(new char[50]).replace('\0', '-'));

        List<Integer> numbers = IntStream.range(0, 10).boxed().collect(Collectors.toList());

        numbers.parallelStream().forEach(i -> {
            VotingMachineV1 votingMachineV1 = VotingMachineV1.getVotingMachineInstance();
            votingMachineV1.registerVote();
        });

        System.out.println("Total votes: " + VotingMachineV1.getVotingMachineInstance().getTotalVotes());
        System.out.println(new String(new char[50]).replace('\0', '-'));

        numbers.parallelStream().forEach(i -> {
            VotingMachineV2 votingMachineV2 = VotingMachineV2.getVotingMachineInstance();
            votingMachineV2.registerVote();
        });

        System.out.println("Total votes: " + VotingMachineV2.getVotingMachineInstance().getTotalVotes());
        System.out.println(new String(new char[50]).replace('\0', '-'));

        numbers.parallelStream().forEach(i -> {
            VotingMachineV3 votingMachineV3 = VotingMachineV3.getVotingMachineInstance();
            votingMachineV3.registerVote();
        });

        System.out.println("Total votes: " + VotingMachineV3.getVotingMachineInstance().getTotalVotes());
        System.out.println(new String(new char[50]).replace('\0', '-'));

        numbers.parallelStream().forEach(i -> {
            VotingMachineV4 votingMachineV4 = VotingMachineV4.getVotingMachineInstance();
            votingMachineV4.registerVote();
        });

        System.out.println("Total votes: " + VotingMachineV4.getVotingMachineInstance().getTotalVotes());
    }
}