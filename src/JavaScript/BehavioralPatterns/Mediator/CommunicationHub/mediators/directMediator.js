
const Mediator = require("./mediator");
const Participant = require("../participants/participant");

class DirectMediator extends Mediator {
  notify(sender, senderArgs) {
    if (!Array.isArray(senderArgs)) {
      return;
    }

    const [receiver, args] = senderArgs;

    if (!(receiver instanceof Participant)) {
      return;
    }

    receiver.receive(sender, args);
  }
}

module.exports = DirectMediator;