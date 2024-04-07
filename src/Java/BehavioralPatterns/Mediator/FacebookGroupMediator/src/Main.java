import java.util.ArrayList;
import java.util.List;

interface IFacebookGroupMediator {
    void sendMessage(String message, User user);
    void registerUser(User user);
}

class ConcreteFacebookGroupMediator implements IFacebookGroupMediator {
    private final List<User> usersInFacebookGroup = new ArrayList<>();

    @Override
    public void registerUser(User user) {
        usersInFacebookGroup.add(user);
        user.setFacebookGroupMediator(this);
    }

    @Override
    public void sendMessage(String message, User user) {
        for (User userInFacebookGroup : usersInFacebookGroup) {
            if (userInFacebookGroup != user) {
                userInFacebookGroup.receiveMessage(message);
            }
        }
    }
}

abstract class User {
    protected String name;
    private IFacebookGroupMediator facebookGroupMediator;

    public User(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public IFacebookGroupMediator getFacebookGroupMediator() {
        return facebookGroupMediator;
    }

    public void setFacebookGroupMediator(IFacebookGroupMediator facebookGroupMediator) {
        this.facebookGroupMediator = facebookGroupMediator;
    }

    public abstract void sendMessage(String message);
    public abstract void receiveMessage(String message);
}

class ConcreteUser extends User {
    public ConcreteUser(String name) {
        super(name);
    }

    @Override
    public void sendMessage(String message) {
        System.out.printf("%s sending message %s%n%n", getName(), message);
        getFacebookGroupMediator().sendMessage(message, this);
    }

    @Override
    public void receiveMessage(String message) {
        System.out.printf("%s received message: %s%n", getName(), message);
    }
}

public class Main {
    public static void main(String[] args) {
        IFacebookGroupMediator facebookGroupMediator = new ConcreteFacebookGroupMediator();

        User john = new ConcreteUser("John");
        User david = new ConcreteUser("David");
        User sam = new ConcreteUser("Sam");
        User richard = new ConcreteUser("Richard");
        User lisa = new ConcreteUser("Lisa");
        User jodie = new ConcreteUser("Jodie");
        User william = new ConcreteUser("William");
        User harry = new ConcreteUser("Harry");

        List<User> usersToRegisterInFacebookGroup = List.of(john, david, sam, richard, lisa, jodie, william, harry);

        for (User userToRegisterInFacebookGroup : usersToRegisterInFacebookGroup) {
            facebookGroupMediator.registerUser(userToRegisterInFacebookGroup);
        }

        david.sendMessage("Good place to learn Design Patterns");
        System.out.println();
        william.sendMessage("Dofactory");
    }
}