import java.util.SortedMap;
import java.util.TreeMap;

abstract class Academy {
    protected IJournal journal;

    protected Academy(IJournal journal) {
        this.journal = journal;
    }

    public abstract void addMessage(String message);

    public abstract void describeEvent(String friend, String message);

    public abstract void poke(String targetPerson);
}

class JediAcademy extends Academy {
    public JediAcademy(IJournal journal) {
        super(journal);
    }

    @Override
    public void addMessage(String message) {
        journal.addMessage(message);
    }

    @Override
    public void describeEvent(String friend, String message) {
        journal.describeEvent(friend, message);
    }

    @Override
    public void poke(String targetPerson) {
        journal.poke(targetPerson);
    }
}

interface IJournal {
    void addMessage(String message);

    void describeEvent(String friend, String message);

    void poke(String targetPerson);
}

class DailyJournal implements IJournal {
    private static final String GAP = "\n\t\t";

    private String pages = "";

    private final String name;

    private static final SortedMap<String, DailyJournal> community = new TreeMap<>();

    public DailyJournal(String name) {
        this.name = name;
        community.put(name, this);
    }

    @Override
    public void addMessage(String message) {
        pages += GAP + " " + message;
        System.out.print(GAP + " " + "======= " + name + "'s Spacebook =======");
        System.out.print(pages);
        System.out.println(GAP + " " + "===================================================");
    }

    @Override
    public void describeEvent(String friend, String message) {
        community.get(friend).addMessage(message);
    }

    @Override
    public void poke(String targetPerson) {
        community.get(targetPerson).pages += GAP + " You have been poked";
    }
}

class SharedJournal implements IJournal {
    private final DailyJournal dailyJournal;

    private final String name;

    public SharedJournal(String name) {
        this.name = name;
        dailyJournal = new DailyJournal(name + "'s daily journal");
    }

    @Override
    public void addMessage(String message) {
        dailyJournal.addMessage(message);
    }

    @Override
    public void describeEvent(String friend, String message) {
        dailyJournal.addMessage(friend + ", " + name + " said: " + message);
    }

    @Override
    public void poke(String targetPerson) {
        dailyJournal.poke(targetPerson);
    }
}

public class Main {
    public static void main(String[] args) {
        DailyJournal skywalkerDailyJournal = new DailyJournal("Luke");
        skywalkerDailyJournal.addMessage("Hello, Jedi World ");
        skywalkerDailyJournal.addMessage("Busy day at training with the green saber today :( ");

        IJournal jedisSharedJournal = new SharedJournal("Jedis");
        Academy academy = new JediAcademy(jedisSharedJournal);
        academy.poke("Luke");
        academy.describeEvent("Luke", "How is everything going?");
        academy.addMessage("Hello there I have started writing on the share journal");
    }
}