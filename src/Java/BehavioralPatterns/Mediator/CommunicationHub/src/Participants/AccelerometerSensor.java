package Participants;

import java.util.Random;

public class AccelerometerSensor extends Sensor {
    public AccelerometerSensor() {
        super("acceleration");
    }

    @Override
    public void receive(Participant sender, Object args) {
        if (args.equals("measure")) {
            setLastValue(new Random().nextDouble());
            getMediator().notify(this, "measure");
            getMediator().notify(this, getLastValue());
        }
    }

    @Override
    public void valueChanged(Object value) {
        setLastValue(value);
        getMediator().notify(this, "measure");
        getMediator().notify(this, getLastValue());
    }
}

