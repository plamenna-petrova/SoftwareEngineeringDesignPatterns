
const User = require("./participants/user");
const Sensor = require("./participants/sensor");
const AccelerometerSensor = require("./participants/accelerometerSensor");
const SensorCommandMediator = require("./mediators/sensorCommandMediator");
const Group = require("./mediators/group");
const GroupMediator = require("./mediators/groupMediator");
const DirectMediator = require("./mediators/directMediator");
const BroadcastMediator = require("./mediators/broadcastMediator");

function executeCommunicationHubExample() {
  const Alice = new User("Alice");
  const Bob = new User("Bob");
  const Jim = new User("Jim");
  const Tom = new User("Tom");

  const temperatureSensor = new Sensor("temperature");
  const windSensor = new Sensor("wind");
  const humiditySensor = new Sensor("humidity");

  const accelerometerSensor = new AccelerometerSensor();
  const sensorCommandHub = new SensorCommandMediator();

  const groupHub = new GroupMediator();
  const broadcastHub = new BroadcastMediator();

  Alice.mediator = new DirectMediator();
  Bob.mediator = broadcastHub;
  Jim.mediator = new DirectMediator();
  Tom.mediator = new DirectMediator();

  broadcastHub.participants.push(Alice, Bob, Jim);

  groupHub.groups.push(new Group({ participants: [Alice, Bob, temperatureSensor] }));
  groupHub.groups.push(new Group({ participants: [humiditySensor, Jim, Bob] }));

  temperatureSensor.mediator = groupHub;
  humiditySensor.mediator = groupHub;
  windSensor.mediator = broadcastHub;
  accelerometerSensor.mediator = sensorCommandHub;

  sensorCommandHub.groups.push(new Group({
    participants: [accelerometerSensor, humiditySensor, temperatureSensor, Jim, Bob, Tom]
  }));

  Bob.send(Alice, "a message");
  Alice.send(Bob, "another message");

  temperatureSensor.valueChanged(3.5);
  windSensor.valueChanged(2);
  humiditySensor.valueChanged(10);

  accelerometerSensor.valueChanged(0.5);

  Bob.send(temperatureSensor, "measure");

  Tom.send(humiditySensor, "measure");
  Jim.send(accelerometerSensor, "measure");
}

executeCommunicationHubExample();