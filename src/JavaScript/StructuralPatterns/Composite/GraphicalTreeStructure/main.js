
class DrawingElement {
    constructor(name) {
        this.name = name;
    }

    add(drawingElement) {
        throw new Error("Cannot add to abstract DrawingElement");
    }

    remove(drawingElement) {
        throw new Error("Cannot remove from abstract DrawingElement");
    }

    display(indent) {
        throw new Error("Cannot display abstract DrawingElement");
    }
}

class CompositeElement extends DrawingElement {
    constructor(name) {
        super(name);
        this.drawingElements = [];
    }

    add(drawingElement) {
        this.drawingElements.push(drawingElement);
    }

    remove(drawingElement) {
        const drawingElementRemovalIndex = this.drawingElements.indexOf(drawingElement);

        if (drawingElementRemovalIndex !== -1) {
            this.drawingElements.splice(index, 1);
        }
    }

    display(indent) {
        console.log(`${"-".repeat(indent)}+ ${this.name}`);

        for (const drawingElement of this.drawingElements) {
            drawingElement.display(indent + 2);
        }
    }
}

class PrimitiveElement extends DrawingElement {
    constructor(name) {
        super(name);
    }

    add(drawingElement) {
        console.log("Cannot add to a primitive element");
    }

    remove(drawingElement) {
        console.log("Cannot remove from a primitive element");
    }

    display(indent) {
        console.log(`${"-".repeat(indent)} ${this.name}`);
    }
}

const canvas = new CompositeElement("Canvas");
canvas.add(new PrimitiveElement("Red Line"));
canvas.add(new PrimitiveElement("Blue Circle"));
canvas.add(new PrimitiveElement("Green Box"));

const twoCircles = new CompositeElement("Two Circles");
twoCircles.add(new PrimitiveElement("Black Circle"));
twoCircles.add(new PrimitiveElement("White Circle"));
canvas.add(twoCircles);

const orangeLine = new PrimitiveElement("Orange Line");
canvas.add(orangeLine);
canvas.remove(orangeLine);

canvas.display(1);