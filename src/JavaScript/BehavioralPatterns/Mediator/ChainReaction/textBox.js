
const Participant = require("./participant");

class TextBox extends Participant {
    constructor(mediator) {
        super(mediator);
        this.isEnabled = false;
    }

    get isEnabled() {
        return this._isEnabled;
    }

    set isEnabled(value) {
        this._isEnabled = value;
    }

    enable() {
        this.isEnabled = true;
        console.log("TextBox is enabled.");
        this.mediator.onStateChanged(this);
    }

    disable() {
        this.isEnabled = false;
        console.log("TextBox is disabled.");
        this.mediator.onStateChanged(this);
    }
}

module.exports = TextBox;