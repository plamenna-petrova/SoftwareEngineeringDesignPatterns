package Participants;

import java.util.Random;

public class Sensor extends Participant {
    private final String id;
    private Object lastValue;

    public Sensor(String id) {
        this.id = id;
    }

    public String getId() {
        return id;
    }

    public Object getLastValue() {
        return lastValue;
    }

    public void setLastValue(Object lastValue) {
        this.lastValue = lastValue;
    }

    @Override
    public void receive(Participant sender, Object args) {
        if (args.equals("measure")) {
            lastValue = new Random().nextDouble();
            getMediator().notify(this, lastValue);
        }
    }

    public void valueChanged(Object value) {
        lastValue = value;
        getMediator().notify(this, lastValue);
    }

    @Override
    public String toString() {
        return "Sensor(" + id + ")";
    }
}