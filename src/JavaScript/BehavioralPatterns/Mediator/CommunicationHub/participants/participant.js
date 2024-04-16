
class Participant {
  constructor() {
    this.mediator = null;
  }

  get mediator() {
    return this._mediator;
  }

  set mediator(value) {
    this._mediator = value;
  }

  receive(sender, args) {
    throw new Error("Method 'receive' must be implemented.");
  }
}

module.exports = Participant;
