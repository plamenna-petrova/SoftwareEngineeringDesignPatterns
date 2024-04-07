import java.util.*;

abstract class AbstractChatroom {
    public abstract void register(Participant participant);
    public abstract void sendMessage(String from, String to, String message);
}

class Chatroom extends AbstractChatroom {
    private final Map<String, Participant> participants = new HashMap<>();

    @Override
    public void register(Participant participant) {
        if (!participants.containsValue(participant)) {
            participants.put(participant.getName(), participant);
        }
        participant.setChatroom(this);
    }

    @Override
    public void sendMessage(String from, String to, String message) {
        Participant recipient = participants.get(to);
        if (recipient != null) {
            recipient.receiveMessage(from, message);
        } else {
            System.out.printf("Participant %s is not registered in the chatroom%n", to);
        }
    }
}

class Participant {
    private final String name;
    private Chatroom chatroom;

    public Participant(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public Chatroom getChatroom() {
        return chatroom;
    }

    public void setChatroom(Chatroom chatroom) {
        this.chatroom = chatroom;
    }

    public void send(String to, String message) {
        chatroom.sendMessage(name, to, message);
    }

    public void receiveMessage(String from, String message) {
        System.out.printf("%s to %s: '%s'%n", from, getName(), message);
    }
}

class Beatle extends Participant {
    public Beatle(String name) {
        super(name);
    }

    @Override
    public void receiveMessage(String from, String message) {
        System.out.print("To a Beatle: ");
        super.receiveMessage(from, message);
    }
}

class NonBeatle extends Participant {
    public NonBeatle(String name) {
        super(name);
    }

    @Override
    public void receiveMessage(String from, String message) {
        System.out.print("To a non-Beatle: ");
        super.receiveMessage(from, message);
    }
}

public class Main {
    public static void main(String[] args) {
        Chatroom chatroom = new Chatroom();

        Participant george = new Beatle("George");
        Participant paul = new Beatle("Paul");
        Participant ringo = new Beatle("Ringo");
        Participant john = new Beatle("John");
        Participant yoko = new Beatle("Yoko");

        List<Participant> participantsToRegisterInChatroom = Arrays.asList(george, paul, ringo, john, yoko);

        for (Participant participant : participantsToRegisterInChatroom) {
            chatroom.register(participant);
        }

        yoko.send("John", "Hi, John!");
        paul.send("Ringo", "All you need is love");
        ringo.send("George", "My sweet Lord");
        paul.send("John", "Can't buy me love");
        john.send("Yoko", "My sweet love");
    }
}