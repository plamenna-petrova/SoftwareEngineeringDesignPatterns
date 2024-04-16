
const Mediator = require("./mediator");

class BroadcastMediator extends Mediator {
  constructor() {
    super();
    this.participants = [];
  }

  get participants() {
    return this._participants;
  }

  set participants(value) {
    this._participants = value;
  }

  notify(sender, senderArgs) {
    this.participants.forEach(p => p.receive(sender, senderArgs));
  }
}

module.exports = BroadcastMediator;