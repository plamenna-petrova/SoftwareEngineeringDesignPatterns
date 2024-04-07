package Participants;

import java.util.List;

public class User extends Participant {
    private final String name;

    public User(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    @Override
    public void receive(Participant sender, Object args) {
        if (args instanceof List<?>) {
            List<?> listOfObjectsArgs = (List<?>) args;
            if (listOfObjectsArgs.size() >= 2) {
                System.out.printf("User: %s, received from: %s, message: %s%n", this, sender, listOfObjectsArgs.get(1));
            }
        } else {
            System.out.printf("User: %s, received from: %s, message: %s%n", this, sender, args);
        }
    }

    public void send(Participant receiver, Object args) {
        getMediator().notify(this, List.of(receiver, args));
    }

    @Override
    public String toString() {
        return name;
    }
}