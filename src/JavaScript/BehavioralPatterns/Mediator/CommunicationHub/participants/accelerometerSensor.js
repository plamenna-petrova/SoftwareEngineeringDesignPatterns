
const Sensor = require("./sensor");

class AccelerometerSensor extends Sensor {
  constructor() {
    super("acceleration");
  }

  receive(sender, args) {
    if (args === "measure") {
      this.lastValue = Math.random();
      this.mediator.notify(this, "measure");
      this.mediator.notify(this, this.lastValue);
    }
  }

  valueChanged(value) {
    this.lastValue = value;
    this.mediator.notify(this, "measure");
    this.mediator.notify(this, this.lastValue);
  }
}

module.exports = AccelerometerSensor;
