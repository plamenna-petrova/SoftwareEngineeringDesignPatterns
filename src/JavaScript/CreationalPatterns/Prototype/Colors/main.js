
class ColorPrototype {
    clone() {
        throw new Error("Method 'clone' must be implemented by subclasses");
    }
}

class ColorConcretePrototype extends ColorPrototype {
    constructor(red, green, blue) {
        super();
        this.Red = red;
        this.Green = green;
        this.Blue = blue;
    }

    clone() {
        return Object.assign(Object.create(Object.getPrototypeOf(this)), this);
    }

    toString() {
        return `Cloned color RGB: ${this.Red},${this.Green},${this.Blue}`;
    }
}

class ColorManager {
    constructor() {
        this.colors = {};
    }

    get(key) {
        return this.colors[key];
    }

    set(key, value) {
        this.colors[key] = value;
    }
}

let colorManager = new ColorManager();

colorManager.set("red", new ColorConcretePrototype(255, 0, 0));
colorManager.set("green", new ColorConcretePrototype(0, 255, 0));
colorManager.set("blue", new ColorConcretePrototype(0, 0, 255));

colorManager.set("angry", new ColorConcretePrototype(255, 54, 0));
colorManager.set("peace", new ColorConcretePrototype(128, 211, 128));
colorManager.set("flame", new ColorConcretePrototype(211, 34, 20));

let redColor = colorManager.get("red").clone();
let peaceColor = colorManager.get("peace").clone();
let flameColor = colorManager.get("flame").clone();

console.log(redColor.toString());
console.log(peaceColor.toString());
console.log(flameColor.toString());