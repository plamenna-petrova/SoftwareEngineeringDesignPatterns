
const Mediator = require("./mediator");

class GroupMediator extends Mediator {
  constructor() {
    super();
    this.groups = [];
  }

  get groups() {
    return this._groups;
  }

  set groups(value) {
    this._groups = value;
  }

  notify(sender, senderArgs) {
    const groupsOfParticipant = this.groups.filter(group => group.doesParticipantExist(sender));

    const receivers = groupsOfParticipant
      .flatMap(group => group.participants)
      .filter(participant => participant !== sender)
      .filter((value, index, self) => self.indexOf(value) === index); // Remove duplicates

    receivers.forEach(receiver => receiver.receive(sender, senderArgs));
  }
}

module.exports = GroupMediator;