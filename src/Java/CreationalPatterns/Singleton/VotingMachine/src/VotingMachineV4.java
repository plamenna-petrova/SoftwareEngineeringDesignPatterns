import java.util.concurrent.atomic.AtomicInteger;

public final class VotingMachineV4 {
    private final AtomicInteger totalVotes = new AtomicInteger(0);

    private static final VotingMachineV4 votingMachineInstance = new VotingMachineV4();

    private VotingMachineV4() {

    }

    public int getTotalVotes() {
        return totalVotes.get();
    }

    public static VotingMachineV4 getVotingMachineInstance() {
        return votingMachineInstance;
    }

    public void registerVote() {
        int currentVotes = totalVotes.incrementAndGet();
        System.out.println("Registered Vote #" + currentVotes);
    }
}
