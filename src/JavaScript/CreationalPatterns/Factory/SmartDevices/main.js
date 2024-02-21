
const prompt = require("prompt-sync")();

class SmartDevice {
    constructor() {
        this.price = 0;
        this.characteristics = [];
    }

    toString() {
        return `${this.constructor.name}'s Details:\nPrice: ${this.price}\nCharacteristics: ${this.characteristics.join(", ")}`;
    }
}

class SamsungGalaxyS23Ultra extends SmartDevice {
    constructor() {
        super();
        this.price = 1970.00;
    }
}

class XiaomiRedmiNote12Pro extends SmartDevice {
    constructor() {
        super();
        this.price = 630.00;
    }
}

class IPhone12ProMax extends SmartDevice {
    constructor() {
        super();
        this.price = 1470.00;
    }
}

class GalaxyWatchClassic extends SmartDevice {
    constructor() {
        super();
        this.price = 760.00;
    }
}

class XiaomiWatch2Pro extends SmartDevice {
    constructor() {
        super();
        this.price = 620.00;
    }
}

class AppleWatchUltra2 extends SmartDevice {
    constructor() {
        super();
        this.price = 830.00;
    }
}

class GalaxyBuds2Pro extends SmartDevice {
    constructor() {
        super();
        this.price = 470.00;
    }
}

class RedmiAirdotsBasic2 extends SmartDevice {
    constructor() {
        super();
        this.price = 267.00;
    }
}

class AirPods extends SmartDevice {
    constructor() {
        super();
        this.price = 950.00;
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

let smartDeviceType = prompt("Enter Smart Device Type - Smart Phone, Smart Watch or Earbuds:");

while (smartDeviceType.toUpperCase() !== "END") {
    let targetSmartDeviceCreator = null;

    switch (smartDeviceType) {
        case "Smart Phone":
            targetSmartDeviceCreator = smartPhoneCreator;
            break;
        case "Smart Watch":
            targetSmartDeviceCreator = smartWatchCreator;
            break;
        case "Earbuds":
            targetSmartDeviceCreator = earbudsCreator;
            break;
        default:
            smartDeviceType = prompt("Enter valid smart device type: Smart Phone, Smart Watch or Earbuds:");
            continue;
    }

    const smartDeviceBrandInput = prompt("Enter Smart Device Brand - Samsung, Xiaomi, or Apple:");
    let targetSmartDeviceBrand;

    switch (smartDeviceBrandInput) {
        case "Samsung":
            targetSmartDeviceBrand = SmartDeviceBrand.Samsung;
            break;
        case "Xiaomi":
            targetSmartDeviceBrand = SmartDeviceBrand.Xiaomi;
            break;
        case "Apple":
            targetSmartDeviceBrand = SmartDeviceBrand.Apple;
            break;
        default:
            prompt("Enter valid smart device brand: Samsung, Xiaomi, or Apple:");
            continue;
    }

    const smartDevice = targetSmartDeviceCreator.createSmartDevice(targetSmartDeviceBrand);

    const smartDeviceCharacteristics = prompt(`Enter device characteristics for ${smartDevice.constructor.name} separated by '|':`)
        .split("|")
        .map(characteristic => characteristic.trim());

    smartDevice.Characteristics = smartDeviceCharacteristics;

    console.log(smartDevice.toString());
    console.log("=".repeat(80));

    smartDeviceType = prompt("Enter Smart Device Type - Smart Phone, Smart Watch or Earbuds:");
}
