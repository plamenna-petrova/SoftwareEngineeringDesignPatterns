
const Participant = require("./participant");

class FontEditor extends Participant {
    constructor(mediator) {
        super(mediator);
    }

    enable() {
        console.log("FontEditor is enabled.");
    }

    disable() {
        console.log("FontEditor is disabled.");
    }
}

module.exports = FontEditor;