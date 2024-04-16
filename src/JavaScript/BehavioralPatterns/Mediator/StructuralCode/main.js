
class Mediator {
    send(message, colleague) {
        throw new Error("Method 'send' must be implemented.");
    }
}

class ConcreteMediator extends Mediator {
    constructor() {
        super();
        this.firstConcreteColleague = null;
        this.secondConcreteColleague = null;
    }

    setFirstConcreteColleague(colleague) {
        this.firstConcreteColleague = colleague;
    }

    setSecondConcreteColleague(colleague) {
        this.secondConcreteColleague = colleague;
    }

    send(message, colleague) {
        if (colleague === this.firstConcreteColleague) {
            this.secondConcreteColleague.getNotification(message);
        } else {
            this.firstConcreteColleague.getNotification(message);
        }
    }
}

class Colleague {
    constructor(mediator) {
        this.mediator = mediator;
    }
}

class FirstConcreteColleague extends Colleague {
    constructor(mediator) {
        super(mediator);
    }

    send(message) {
        this.mediator.send(message, this);
    }

    getNotification(message) {
        console.log("Colleague #1 gets message: " + message);
    }
}

class SecondConcreteColleague extends Colleague {
    constructor(mediator) {
        super(mediator);
    }

    send(message) {
        this.mediator.send(message, this);
    }

    getNotification(message) {
        console.log("Colleague #2 gets message: " + message);
    }
}

const concreteMediator = new ConcreteMediator();

const firstConcreteColleague = new FirstConcreteColleague(concreteMediator);
const secondConcreteColleague = new SecondConcreteColleague(concreteMediator);

concreteMediator.setFirstConcreteColleague(firstConcreteColleague);
concreteMediator.setSecondConcreteColleague(secondConcreteColleague);

firstConcreteColleague.send("How are you?");
secondConcreteColleague.send("Fine, thanks");
