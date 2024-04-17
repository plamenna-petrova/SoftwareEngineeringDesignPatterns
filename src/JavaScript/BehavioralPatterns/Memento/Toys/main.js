
class ToyCarMemento {
    constructor(color) {
        this.color = color;
    }
}

class ToyCar {
    constructor() {
        this.color = '';
    }

    get Color() {
        return this.color;
    }

    set Color(value) {
        this.color = value;
        console.log(`Car color changed to ${this.color}`);
    }

    saveState() {
        return new ToyCarMemento(this.color);
    }

    restoreState(toyCarMemento) {
        this.Color = toyCarMemento.color;
    }
}

class ColorChanger {
    constructor() {
        this.toyCarMemento = null;
    }

    changeColor(toyCar, color) {
        this.toyCarMemento = toyCar.saveState();
        toyCar.Color = color;
    }

    undoColorChange(toyCar) {
        toyCar.restoreState(this.toyCarMemento);
    }
}

const toyCar = new ToyCar();
const colorChanger = new ColorChanger();

colorChanger.changeColor(toyCar, "Red");

const savedState = toyCar.saveState();
colorChanger.changeColor(toyCar, "Blue");
colorChanger.changeColor(toyCar, "Green");

colorChanger.undoColorChange(toyCar);
console.log(`Current car color: ${toyCar.Color}`);

toyCar.restoreState(savedState);
console.log(`Restored car color: ${toyCar.Color}`);