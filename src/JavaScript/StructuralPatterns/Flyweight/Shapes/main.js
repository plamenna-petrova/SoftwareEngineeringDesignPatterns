
class Shape {
    draw() { }
}

class Circle extends Shape {
    constructor() {
        super();
        this.xCoordinate = 10;
        this.yCoordinate = 20;
        this.radius = 30;
    }

    setColor(color) {
        this.color = color;
    }

    draw() {
        console.log(` Circle: Draw() [Color: ${this.color}, X Coordinate: ${this.xCoordinate}, Y Coordinate: ${this.yCoordinate}, Radius: ${this.radius}]`);
    }
}

class ShapeFactory {
    static shapes = new Map();

    static getShape(shapeType) {
        let shape = null;

        if (shapeType.toLowerCase() === "circle") {
            if (!ShapeFactory.shapes.has("circle")) {
                shape = new Circle();
                ShapeFactory.shapes.set("circle", shape);
                console.log(" Creating circle object without any color in shape factory \n");
            } else {
                shape = ShapeFactory.shapes.get("circle");
            }
        }

        return shape;
    }
}

console.log("\n Red color Circles ");

for (let i = 0; i < 3; i++) {
    const circle = ShapeFactory.getShape("circle");
    circle.setColor("Red");
    circle.draw();
}

console.log("\n Green color Circles ");

for (let i = 0; i < 3; i++) {
    const circle = ShapeFactory.getShape("circle");
    circle.setColor("Green");
    circle.draw();
}

console.log("\n Blue color Circles");

for (let i = 0; i < 3; ++i) {
    const circle = ShapeFactory.getShape("circle");
    circle.setColor("Green");
    circle.draw();
}

console.log("\n Orange color Circles");

for (let i = 0; i < 3; ++i) {
    const circle = ShapeFactory.getShape("circle");
    circle.setColor("Orange");
    circle.draw();
}

console.log("\n Black color Circles");

for (let i = 0; i < 3; ++i) {
    const circle = ShapeFactory.getShape("circle");
    circle.setColor("Black");
    circle.draw();
}