
class AbstractChatroom {
    register(participant) {
        throw new Error("Method 'register' must be implemented.");
    }

    sendMessage(from, to, message) {
        throw new Error("Method 'sendMessage' must be implemented.");
    }
}

class Chatroom extends AbstractChatroom {
    constructor() {
        super();
        this.participants = new Map();
    }

    register(participant) {
        if (!this.participants.has(participant.name)) {
            this.participants.set(participant.name, participant);
        }

        participant.chatroom = this;
    }

    sendMessage(from, to, message) {
        const receiver = this.participants.get(to);
        if (receiver) {
            receiver.receiveMessage(from, message);
        }
    }
}

class Participant {
    constructor(name) {
        this.name = name;
        this.chatroom = null;
    }

    send(to, message) {
        this.chatroom.sendMessage(this.name, to, message);
    }

    receiveMessage(from, message) {
        console.log(`${from} to ${this.name}: '${message}'`);
    }
}

class Beatle extends Participant {
    constructor(name) {
        super(name);
    }

    receiveMessage(from, message) {
        console.log("To a Beatle: ");
        super.receiveMessage(from, message);
    }
}

class NonBeatle extends Participant {
    constructor(name) {
        super(name);
    }

    receiveMessage(from, message) {
        console.log("To a non-Beatle: ");
        super.receiveMessage(from, message);
    }
}

const chatroom = new Chatroom();

const George = new Beatle("George");
const Paul = new Beatle("Paul");
const Ringo = new Beatle("Ringo");
const John = new Beatle("John");
const Yoko = new Beatle("Yoko");

const participantsToRegisterInChatroom = [George, Paul, Ringo, John, Yoko];

participantsToRegisterInChatroom.forEach((participant) => {
    chatroom.register(participant);
});

Yoko.send("John", "Hi, John!");
Paul.send("Ringo", "All you need is love");
Ringo.send("George", "My sweet Lord");
Paul.send("John", "Can't buy me love");
John.send("Yoko", "My sweet love");