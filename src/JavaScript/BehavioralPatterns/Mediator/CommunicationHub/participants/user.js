
const Participant = require("./participant");

class User extends Participant {
  constructor(name) {
    super();
    this.name = name;
  }

  get name() {
    return this._name;
  }

  set name(value) {
    this._name = value;
  }

  receive(sender, args) {
    if (Array.isArray(args)) {
      console.log(`User:${this}, received from: ${sender}, message: ${args[1]}`);
    } else {
      console.log(`User:${this}, received from: ${sender}, message: ${args}`);
    }
  }

  send(receiver, args) {
    this.mediator.notify(this, [receiver, args]);
  }

  toString() {
    return this.name;
  }
}

module.exports = User;