
const Dropdown = require("./dropdown");
const Button = require("./button");
const TextBox = require("./textBox");
const FontEditor = require("./fontEditor");

class Mediator {
    constructor() {
        this.dropdown = new Dropdown(this);
        this.button = new Button(this);
        this.textBox = new TextBox(this);
        this.fontEditor = new FontEditor(this);
    }

    onStateChanged(participant) {
        if (participant === this.textBox && this.textBox.isEnabled) {
            this.fontEditor.enable();
            return;
        }

        if (participant === this.textBox && !this.textBox.isEnabled) {
            this.fontEditor.disable();
            return;
        }

        if (participant === this.dropdown && this.dropdown.selectedItem === "Manual") {
            this.button.enable();
            this.textBox.enable();
            return;
        }

        if (participant === this.dropdown && this.dropdown.selectedItem === "Auto") {
            this.button.disable();
            this.textBox.disable();
            return;
        }
    }
}

module.exports = Mediator;