abstract class Mediator {
    public abstract void send(String message, Colleague colleague);
}

class ConcreteMediator extends Mediator {
    private FirstConcreteColleague firstConcreteColleague;
    private SecondConcreteColleague secondConcreteColleague;

    public void setFirstConcreteColleague(FirstConcreteColleague firstConcreteColleague) {
        this.firstConcreteColleague = firstConcreteColleague;
    }

    public void setSecondConcreteColleague(SecondConcreteColleague secondConcreteColleague) {
        this.secondConcreteColleague = secondConcreteColleague;
    }

    @Override
    public void send(String message, Colleague colleague) {
        if (colleague == firstConcreteColleague) {
            secondConcreteColleague.getNotification(message);
        } else {
            firstConcreteColleague.getNotification(message);
        }
    }
}

abstract class Colleague {
    protected Mediator mediator;

    protected Colleague(Mediator mediator) {
        this.mediator = mediator;
    }
}

class FirstConcreteColleague extends Colleague {
    public FirstConcreteColleague(Mediator mediator) {
        super(mediator);
    }

    public void send(String message) {
        mediator.send(message, this);
    }

    public void getNotification(String message) {
        System.out.println("Colleague #1 gets message: " + message);
    }
}

class SecondConcreteColleague extends Colleague {
    public SecondConcreteColleague(Mediator mediator) {
        super(mediator);
    }

    public void send(String message) {
        mediator.send(message, this);
    }

    public void getNotification(String message) {
        System.out.println("Colleague #2 gets message: " + message);
    }
}

class Program {
    public static void main(String[] args) {
        ConcreteMediator concreteMediator = new ConcreteMediator();

        FirstConcreteColleague firstConcreteColleague = new FirstConcreteColleague(concreteMediator);
        SecondConcreteColleague secondConcreteColleague = new SecondConcreteColleague(concreteMediator);

        concreteMediator.setFirstConcreteColleague(firstConcreteColleague);
        concreteMediator.setSecondConcreteColleague(secondConcreteColleague);

        firstConcreteColleague.send("How are you?");
        secondConcreteColleague.send("Fine, thanks");
    }
}