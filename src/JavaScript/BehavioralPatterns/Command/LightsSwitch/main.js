
const prompt = require('prompt-sync')();

class Light {
    turnOn() {
        console.log("The light is on");
    }

    turnOff() {
        console.log("The light is off");
    }
}

class ICommand {
    execute() {}
}

class FlipUpCommand extends ICommand {
    constructor(light) {
        super();
        this.light = light;
    }

    execute() {
        this.light.turnOn();
    }
}

class FlipDownCommand extends ICommand {
    constructor(light) {
        super();
        this.light = light;
    }

    execute() {
        this.light.turnOff();
    }
}

class Switch {
    constructor() {
        this.commands = [];
    }

    storeAndExecute(command) {
        this.commands.push(command);
        command.execute();
    }
}

console.log("Enter commands (ON/OFF) : ");
const input = prompt();

const lamp = new Light();
const switchUp = new FlipUpCommand(lamp);
const switchDown = new FlipDownCommand(lamp);
const switchObject = new Switch();

if (input === "ON") {
    switchObject.storeAndExecute(switchUp);
} else if (input === "OFF") {
    switchObject.storeAndExecute(switchDown);
} else {
    console.log("Command \"ON\" or \"OFF\" is required.");
}