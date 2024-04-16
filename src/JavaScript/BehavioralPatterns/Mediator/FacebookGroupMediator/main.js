
class IFacebookGroupMediator {
    registerUser(user) {
        throw new Error("Method 'registerUser' must be implemented.");
    }

    sendMessage(message, user) {
        throw new Error("Method 'sendMessage' must be implemented.");
    }
}

class ConcreteFacebookGroupMediator extends IFacebookGroupMediator {
    constructor() {
        super();
        this.usersInFacebookGroup = [];
    }

    registerUser(user) {
        this.usersInFacebookGroup.push(user);
        user.facebookGroupMediator = this;
    }

    sendMessage(message, user) {
        for (let userInFacebookGroup of this.usersInFacebookGroup) {
            if (userInFacebookGroup !== user) {
                userInFacebookGroup.receiveMessage(message);
            }
        }
    }
}

class User {
    constructor(name) {
        this.name = name;
    }

    sendMessage(message) {
        console.log(`${this.name} sending message ${message}\n`);
        this.facebookGroupMediator.sendMessage(message, this);
    }

    receiveMessage(message) {
        console.log(`${this.name} received message: ${message}`);
    }
}

class ConcreteUser extends User {
    constructor(name) {
        super(name);
    }
}

const facebookGroupMediator = new ConcreteFacebookGroupMediator();

const John = new ConcreteUser("John");
const David = new ConcreteUser("David");
const Sam = new ConcreteUser("Sam");
const Richard = new ConcreteUser("Richard");
const Lisa = new ConcreteUser("Lisa");
const Jodie = new ConcreteUser("Jodie");
const William = new ConcreteUser("William");
const Harry = new ConcreteUser("Harry");

const usersToRegisterInFacebookGroup = [John, David, Sam, Richard, Lisa, Jodie, William, Harry];

usersToRegisterInFacebookGroup.forEach((userToRegisterInFacebookGroup) => {
    facebookGroupMediator.registerUser(userToRegisterInFacebookGroup);
});

David.sendMessage("Good place to learn Design Patterns");
console.log();
William.sendMessage("Dofactory");