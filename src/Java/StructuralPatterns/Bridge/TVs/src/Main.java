interface ILEDTV {
    void switchOn();

    void switchOff();

    void setChannel(int channelNumber);
}

class SamsungLEDTV implements ILEDTV {
    @Override
    public void switchOn() {
        System.out.println("Turning ON : " + getClass().getSimpleName());
    }

    @Override
    public void switchOff() {
        System.out.println("Turning OFF : " + getClass().getSimpleName());
    }

    @Override
    public void setChannel(int channelNumber) {
        System.out.println("Setting channel number " + channelNumber + " on " + getClass().getSimpleName());
    }
}

class SonyLEDTV implements ILEDTV {
    @Override
    public void switchOn() {
        System.out.println("Turning ON : " + getClass().getSimpleName());
    }

    @Override
    public void switchOff() {
        System.out.println("Turning OFF : " + getClass().getSimpleName());
    }

    @Override
    public void setChannel(int channelNumber) {
        System.out.println("Setting channel number " + channelNumber + " on " + getClass().getSimpleName());
    }
}

abstract class AbstractRemoteControl {
    protected ILEDTV ledTV;

    protected AbstractRemoteControl(ILEDTV ledTV) {
        this.ledTV = ledTV;
    }

    public abstract void switchOn();

    public abstract void switchOff();

    public abstract void setChannel(int channelNumber);
}

class SamsungRemoteControl extends AbstractRemoteControl {
    public SamsungRemoteControl(ILEDTV ledTV) {
        super(ledTV);
    }

    @Override
    public void switchOn() {
        ledTV.switchOn();
    }

    @Override
    public void switchOff() {
        ledTV.switchOff();
    }

    @Override
    public void setChannel(int channelNumber) {
        ledTV.setChannel(channelNumber);
    }
}

class SonyRemoteControl extends AbstractRemoteControl {
    public SonyRemoteControl(ILEDTV ledTV) {
        super(ledTV);
    }

    @Override
    public void switchOn() {
        ledTV.switchOn();
    }

    @Override
    public void switchOff() {
        ledTV.switchOff();
    }

    @Override
    public void setChannel(int channelNumber) {
        ledTV.setChannel(channelNumber);
    }
}

public class Main {
    public static void main(String[] args) {
        ILEDTV samsungLEDTV = new SamsungLEDTV();
        AbstractRemoteControl samsungRemoteControl = new SamsungRemoteControl(samsungLEDTV);
        samsungRemoteControl.switchOn();
        samsungRemoteControl.setChannel(9);
        samsungRemoteControl.switchOff();

        System.out.println();

        ILEDTV sonyLEDTV = new SonyLEDTV();
        AbstractRemoteControl sonyRemoteControl = new SonyRemoteControl(sonyLEDTV);
        sonyRemoteControl.switchOn();
        sonyRemoteControl.setChannel(21);
        sonyRemoteControl.switchOff();
    }
}