<?php

use BehavioralPatterns\Mediator\CommunicationHub\Mediators\BroadcastMediator;
use BehavioralPatterns\Mediator\CommunicationHub\Mediators\DirectMediator;
use BehavioralPatterns\Mediator\CommunicationHub\Mediators\Group;
use BehavioralPatterns\Mediator\CommunicationHub\Mediators\GroupMediator;
use BehavioralPatterns\Mediator\CommunicationHub\Mediators\SensorCommandMediator;
use BehavioralPatterns\Mediator\CommunicationHub\Participants\AccelerometerSensor;
use BehavioralPatterns\Mediator\CommunicationHub\Participants\Sensor;
use BehavioralPatterns\Mediator\CommunicationHub\Participants\User;

require_once 'vendor/autoload.php';

executeCommunicationHubExample();

function executeCommunicationHubExample(): void
{
    $alice = new User("Alice");
    $bob = new User("Bob");
    $jim = new User("Jim");
    $tom = new User("Tom");

    $temperatureSensor = new Sensor("temperature");
    $windSensor = new Sensor("wind");
    $humiditySensor = new Sensor("humidity");

    $accelerometerSensor = new AccelerometerSensor();
    $sensorCommandHub = new SensorCommandMediator();

    $group1 = new Group();
    $group1->participants = [
        $accelerometerSensor,
        $humiditySensor,
        $temperatureSensor,
        $jim,
        $bob,
        $tom
    ];

    $sensorCommandHub->groups[] = $group1;

    $accelerometerSensor->mediator = $sensorCommandHub;

    $directHub = new DirectMediator();
    $groupHub = new GroupMediator();
    $broadcastHub = new BroadcastMediator();

    $alice->mediator = $directHub;
    $bob->mediator = $broadcastHub;
    $jim->mediator = $directHub;
    $tom->mediator = $directHub;

    $broadcastHub->participants = [$alice, $bob, $jim];

    $group2 = new Group();
    $group2->participants = [$alice, $bob, $temperatureSensor];
    $group3 = new Group();
    $group3->participants = [$humiditySensor, $jim, $bob];

    $groupHub->groups = [$group2, $group3];

    $temperatureSensor->mediator = $groupHub;
    $humiditySensor->mediator = $groupHub;
    $windSensor->mediator = $broadcastHub;

    $bob->send($alice, "a message");
    $alice->send($bob, "another message");

    $temperatureSensor->valueChanged(3.5);
    $windSensor->valueChanged(2);
    $humiditySensor->valueChanged(10);

    $accelerometerSensor->valueChanged(0.5);

    $bob->send($temperatureSensor, "measure");

    $tom->send($humiditySensor, "measure");
    $jim->send($accelerometerSensor, "measure");
}