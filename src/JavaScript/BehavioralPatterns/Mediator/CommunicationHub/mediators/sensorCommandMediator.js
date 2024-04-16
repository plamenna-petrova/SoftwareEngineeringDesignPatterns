
const GroupMediator = require("./groupMediator");

class SensorCommandMediator extends GroupMediator {
  notify(sender, senderArgs) {
    const groupsOfParticipant = this.groups.filter(group => group.doesParticipantExist(sender));

    let receivers = groupsOfParticipant
      .flatMap(group => group.participants)
      .filter(participant => participant !== sender)
      .filter((value, index, self) => self.indexOf(value) === index); // Remove duplicates

    if (senderArgs === "measure") {
      receivers = receivers.filter(receiver => !(receiver instanceof User));
    } else {
      receivers = receivers.filter(receiver => !(receiver instanceof Sensor));
    }

    receivers.forEach(receiver => receiver.receive(sender, senderArgs));
  }
}

module.exports = SensorCommandMediator;