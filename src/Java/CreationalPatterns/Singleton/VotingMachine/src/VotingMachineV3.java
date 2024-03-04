public final class VotingMachineV3 {
    private int totalVotes = 0;

    private static final VotingMachineV3 votingMachineInstance = new VotingMachineV3();

    private VotingMachineV3() {

    }

    public int getTotalVotes() {
        return totalVotes;
    }

    public static VotingMachineV3 getVotingMachineInstance() {
        return votingMachineInstance;
    }

    public void registerVote() {
        totalVotes++;
        System.out.println("Registered Vote #" + totalVotes);
    }
}
