
class Receiver {
    action() {
        console.log("Called Receiver.Action()");
    }
}

class Command {
    constructor(receiver) {
        this.receiver = receiver;
    }

    execute() {

    }
}

class ConcreteCommand extends Command {
    constructor(receiver) {
        super(receiver);
    }

    execute() {
        this.receiver.action();
    }
}

class Invoker {
    setCommand(command) {
        this.command = command;
    }

    executeCommand() {
        if (this.command) {
            this.command.execute();
        }
    }
}

const receiver = new Receiver();
const command = new ConcreteCommand(receiver);
const invoker = new Invoker();

invoker.setCommand(command);
invoker.executeCommand();