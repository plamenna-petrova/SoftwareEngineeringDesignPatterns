public final class VotingMachineV1 {
    private int totalVotes = 0;

    private static VotingMachineV1 votingMachineInstance;

    private VotingMachineV1() {

    }

    public int getTotalVotes() {
        return totalVotes;
    }

    public static VotingMachineV1 getVotingMachineInstance() {
        if (votingMachineInstance == null) {
            votingMachineInstance = new VotingMachineV1();
        }

        return votingMachineInstance;
    }

    public void registerVote() {
        totalVotes++;
        System.out.println("Registered Vote #" + totalVotes);
    }
}
