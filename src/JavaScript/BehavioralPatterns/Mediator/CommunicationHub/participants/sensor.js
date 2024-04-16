
const Participant = require("./participant");

class Sensor extends Participant {
  constructor(id) {
    super();
    this.id = id;
    this.lastValue = null;
  }

  get id() {
    return this._id;
  }

  set id(value) {
    this._id = value;
  }

  get lastValue() {
    return this._lastValue;
  }

  set lastValue(value) {
    this._lastValue = value;
  }

  receive(sender, args) {
    if (args === "measure") {
      this.lastValue = Math.random();
      this.mediator.notify(this, this.lastValue);
    }
  }

  valueChanged(value) {
    this.lastValue = value;
    this.mediator.notify(this, this.lastValue);
  }

  toString() {
    return `Sensor(${this.id})`;
  }
}

module.exports = Sensor;