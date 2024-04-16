
const Participant = require("./participant");

class Button extends Participant {
    constructor(mediator) {
        super(mediator);
    }

    enable() {
        console.log("Button is enabled.");
    }

    disable() {
        console.log("Button is disabled.");
    }
}

module.exports = Button;