
const prompt = require("prompt-sync")();

class SmartDevice {
    constructor() {
        this.Price = 0;
        this.Characteristics = [];
    }

    toString() {
        return `${this.constructor.name}'s Details:\nPrice: ${this.Price}\nCharacteristics: ${this.Characteristics.join(", ")}`;
    }
}

class SamsungGalaxyS23Ultra extends SmartDevice {
    constructor() {
        super();
        this.Price = 1970.00;
    }
}

class XiaomiRedmiNote12Pro extends SmartDevice {
    constructor() {
        super();
        this.Price = 630.00;
    }
}

class IPhone12ProMax extends SmartDevice {
    constructor() {
        super();
        this.Price = 1470.00;
    }
}

class GalaxyWatchClassic extends SmartDevice {
    constructor() {
        super();
        this.Price = 760.00;
    }
}

class XiaomiWatch2Pro extends SmartDevice {
    constructor() {
        super();
        this.Price = 620.00;
    }
}

class AppleWatchUltra2 extends SmartDevice {
    constructor() {
        super();
        this.Price = 830.00;
    }
}

class GalaxyBuds2Pro extends SmartDevice {
    constructor() {
        super();
        this.Price = 470.00;
    }
}

class RedmiAirdotsBasic2 extends SmartDevice {
    constructor() {
        super();
        this.Price = 267.00;
    }
}

class AirPods extends SmartDevice {
    constructor() {
        super();
        this.Price = 950.00;
    }
}

const SmartDeviceBrand = {
    Samsung: "Samsung",
    Xiaomi: "Xiaomi",
    Apple: "Apple",
};

class ISmartDeviceCreator {
    createSmartDevice(smartDeviceBrand) {
        return null;
    }
}

class SmartPhoneCreator extends ISmartDeviceCreator {
    createSmartDevice(smartDeviceBrand) {
        switch (smartDeviceBrand) {
            case SmartDeviceBrand.Samsung:
                return new SamsungGalaxyS23Ultra();
            case SmartDeviceBrand.Xiaomi:
                return new XiaomiRedmiNote12Pro();
            case SmartDeviceBrand.Apple:
                return new IPhone12ProMax();
            default:
                return null;
        }
    }
}

class SmartWatchCreator extends ISmartDeviceCreator {
    createSmartDevice(smartDeviceBrand) {
        switch (smartDeviceBrand) {
            case SmartDeviceBrand.Samsung:
                return new GalaxyWatchClassic();
            case SmartDeviceBrand.Xiaomi:
                return new XiaomiWatch2Pro();
            case SmartDeviceBrand.Apple:
                return new AppleWatchUltra2();
            default:
                return null;
        }
    }
}

class EarbudsCreator extends ISmartDeviceCreator {
    createSmartDevice(smartDeviceBrand) {
        switch (smartDeviceBrand) {
            case SmartDeviceBrand.Samsung:
                return new GalaxyBuds2Pro();
            case SmartDeviceBrand.Xiaomi:
                return new RedmiAirdotsBasic2();
            case SmartDeviceBrand.Apple:
                return new AirPods();
            default:
                return null;
        }
    }
}

const smartPhoneCreator = new SmartPhoneCreator();
const smartWatchCreator = new SmartWatchCreator();
const earbudsCreator = new EarbudsCreator();

const smartDeviceCreators = [smartPhoneCreator, smartWatchCreator, earbudsCreator];

let smartDeviceType = prompt("Enter Smart Device Type - Smart Phone, Smart Watch or Earbuds:");

while (smartDeviceType.toUpperCase() !== "END") {
    let smartDeviceCreator = null;

    switch (smartDeviceType.toUpperCase()) {
        case "SMART PHONE":
            smartDeviceCreator = smartPhoneCreator;
            break;
        case "SMART WATCH":
            smartDeviceCreator = smartWatchCreator;
            break;
        case "EARBUDS":
            smartDeviceCreator = earbudsCreator;
            break;
        default:
            smartDeviceType = prompt("Enter valid smart device type: Smart Phone, Smart Watch or Earbuds:");
            continue;
    }

    const smartDeviceBrandInput = prompt("Enter Smart Device Brand - Samsung, Xiaomi, or Apple:");
    let smartDeviceBrand;

    switch (smartDeviceBrandInput.toUpperCase()) {
        case "SAMSUNG":
            smartDeviceBrand = SmartDeviceBrand.Samsung;
            break;
        case "XIAOMI":
            smartDeviceBrand = SmartDeviceBrand.Xiaomi;
            break;
        case "APPLE":
            smartDeviceBrand = SmartDeviceBrand.Apple;
            break;
        default:
            prompt("Enter valid smart device brand: Samsung, Xiaomi, or Apple:");
            continue;
    }

    const smartDevice = smartDeviceCreator.createSmartDevice(smartDeviceBrand);

    const smartDeviceCharacteristics = prompt(`Enter device characteristics for ${smartDevice.constructor.name} separated by '|':`)
        .split("|")
        .map(characteristic => characteristic.trim());

    smartDevice.Characteristics = smartDeviceCharacteristics;

    console.log(smartDevice.toString());
    console.log("=".repeat(80));

    smartDeviceType = prompt("Enter Smart Device Type - Smart Phone, Smart Watch or Earbuds:");
}
