public final class VotingMachineV2 {
    private int totalVotes = 0;

    private static VotingMachineV2 votingMachineInstance;

    private static final Object lockObject = new Object();

    private VotingMachineV2() {

    }

    public int getTotalVotes() {
        return totalVotes;
    }

    public static VotingMachineV2 getVotingMachineInstance() {
        if (votingMachineInstance == null) {
            synchronized (lockObject) {
                if (votingMachineInstance == null) {
                    votingMachineInstance = new VotingMachineV2();
                }
            }
        }

        return votingMachineInstance;
    }

    public void registerVote() {
        totalVotes++;
        System.out.println("Registered Vote #" + totalVotes);
    }
}
