
class Part {
    constructor(name, price) {
        this.name = name;
        this.price = price;
    }

    displayPrice() {
        console.log(`${this.name} : ${this.price}`);
    }
}

class Composite {
    constructor(name) {
        this.name = name;
        this.components = [];
    }

    addComponent(component) {
        this.components.push(component);
    }

    displayPrice() {
        console.log(this.name);

        for (const component of this.components) {
            component.displayPrice();
        }
    }
}

const hardDisk = new Part("Hard Disk", 2000);
const ram = new Part("RAM", 3000);
const cpu = new Part("CPU", 2000);
const mouse = new Part("Mouse", 2000);
const keyboard = new Part("Keyboard", 2000);

const motherBoard = new Composite("Mother Board");
const cabinet = new Composite("Cabinet");
const peripherals = new Composite("Peripherals");
const computer = new Composite("Computer");

motherBoard.addComponent(cpu);
motherBoard.addComponent(ram);

cabinet.addComponent(motherBoard);
cabinet.addComponent(hardDisk);

peripherals.addComponent(mouse);
peripherals.addComponent(keyboard);

computer.addComponent(cabinet);
computer.addComponent(peripherals);

computer.displayPrice();
console.log();

keyboard.displayPrice();
console.log();

cabinet.displayPrice();