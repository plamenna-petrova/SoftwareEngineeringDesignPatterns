
class ILEDTV {
    switchOn() {
        console.log(`Turning ON: ${this.constructor.name}`);
    }

    switchOff() {
        console.log(`Turning OFF: ${this.constructor.name}`);
    }

    setChannel(channelNumber) {
        console.log(`Setting channel number ${channelNumber} on ${this.constructor.name}`);
    }
}

class SamsungLEDTV extends ILEDTV { }

class SonyLEDTV extends ILEDTV { }

class AbstractRemoteControl {
    constructor(ledTV) {
        this.ledTV = ledTV;
    }

    switchOn() {
        this.ledTV.switchOn();
    }

    switchOff() {
        this.ledTV.switchOff();
    }

    setChannel(channelNumber) {
        this.ledTV.setChannel(channelNumber);
    }
}

class SamsungRemoteControl extends AbstractRemoteControl {
    constructor(ledTV) {
        super(ledTV);
    }
}

class SonyRemoteControl extends AbstractRemoteControl {
    constructor(ledTV) {
        super(ledTV);
    }
}

const samsungLEDTV = new SamsungLEDTV();
const samsungRemoteControl = new SamsungRemoteControl(samsungLEDTV);
samsungRemoteControl.switchOn();
samsungRemoteControl.setChannel(9);
samsungRemoteControl.switchOff();

console.log();

const sonyLEDTV = new SonyLEDTV();
const sonyRemoteControl = new SonyRemoteControl(sonyLEDTV);
sonyRemoteControl.switchOn();
sonyRemoteControl.setChannel(21);
sonyRemoteControl.switchOff();