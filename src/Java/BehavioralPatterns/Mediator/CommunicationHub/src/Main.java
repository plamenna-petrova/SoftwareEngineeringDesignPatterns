import Mediators.*;
import Participants.AccelerometerSensor;
import Participants.Participant;
import Participants.Sensor;
import Participants.User;

import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        executeCommunicationHubExample();
    }

    public static void executeCommunicationHubExample() {
        User alice = new User("Alice");
        User bob = new User("Bob");
        User jim = new User("Jim");
        User tom = new User("Tom");

        Sensor temperatureSensor = new Sensor("temperature");
        Sensor windSensor = new Sensor("wind");
        Sensor humiditySensor = new Sensor("humidity");

        AccelerometerSensor accelerometerSensor = new AccelerometerSensor();
        SensorCommandMediator sensorCommandHub = new SensorCommandMediator();

        Group group = new Group();
        List<Participant> participants = new ArrayList<>();
        participants.add(accelerometerSensor);
        participants.add(humiditySensor);
        participants.add(temperatureSensor);
        participants.add(jim);
        participants.add(bob);
        participants.add(tom);
        group.setParticipants(participants);
        List<Group> groups = new ArrayList<>();
        groups.add(group);
        sensorCommandHub.setGroups(groups);

        accelerometerSensor.setMediator(sensorCommandHub);

        DirectMediator directHub = new DirectMediator();
        GroupMediator groupHub = new GroupMediator();
        BroadcastMediator broadcastHub = new BroadcastMediator();

        alice.setMediator(directHub);
        bob.setMediator(broadcastHub);
        jim.setMediator(directHub);
        tom.setMediator(directHub);

        List<Participant> broadcastParticipants = new ArrayList<>();
        broadcastParticipants.add(alice);
        broadcastParticipants.add(bob);
        broadcastParticipants.add(jim);
        broadcastHub.setParticipants(broadcastParticipants);

        Group group1 = new Group();
        List<Participant> group1Participants = new ArrayList<>();
        group1Participants.add(alice);
        group1Participants.add(bob);
        group1Participants.add(temperatureSensor);
        group1.setParticipants(group1Participants);

        Group group2 = new Group();
        List<Participant> group2Participants = new ArrayList<>();
        group2Participants.add(humiditySensor);
        group2Participants.add(jim);
        group2Participants.add(bob);
        group2.setParticipants(group2Participants);

        List<Group> groupHubGroups = new ArrayList<>();
        groupHubGroups.add(group1);
        groupHubGroups.add(group2);
        groupHub.setGroups(groupHubGroups);

        temperatureSensor.setMediator(groupHub);
        humiditySensor.setMediator(groupHub);
        windSensor.setMediator(broadcastHub);

        bob.send(alice, "a message");
        alice.send(bob, "another message");

        temperatureSensor.valueChanged(3.5);
        windSensor.valueChanged(2);
        humiditySensor.valueChanged(10);

        accelerometerSensor.valueChanged(0.5);

        bob.send(temperatureSensor, "measure");

        tom.send(humiditySensor, "measure");
        jim.send(accelerometerSensor, "measure");
    }
}