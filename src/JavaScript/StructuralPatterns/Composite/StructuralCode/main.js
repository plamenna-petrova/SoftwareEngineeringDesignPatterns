
class Component {
    constructor(name) {
        this.name = name;
    }

    add(component) {
        throw new Error("Cannot add to abstract Component");
    }

    remove(component) {
        throw new Error("Cannot remove from abstract Component");
    }

    display(depth) {
        throw new Error("Cannot display abstract Component");
    }
}

class Composite extends Component {
    constructor(name) {
        super(name);
        this.childComponents = [];
    }

    add(component) {
        this.childComponents.push(component);
    }

    remove(component) {
        const componentRemovalIndex = this.childComponents.indexOf(component);

        if (componentRemovalIndex !== -1) {
            this.childComponents.splice(index, 1);
        }
    }

    display(depth) {
        console.log(`${"-".repeat(depth)}${this.name}`);

        for (const childComponent of this.childComponents) {
            childComponent.display(depth + 2);
        }
    }
}

class Leaf extends Component {
    constructor(name) {
        super(name);
    }

    add(component) {
        console.log("Cannot add to a leaf");
    }

    remove(component) {
        console.log("Cannot remove from a leaf");
    }

    display(depth) {
        console.log(`${"-".repeat(depth)}${this.name}`);
    }
}

const root = new Composite("root");
root.add(new Leaf("Leaf A"));
root.add(new Leaf("Leaf B"));

const compositeX = new Composite("Composite X");
compositeX.add(new Leaf("Leaf XA"));
compositeX.add(new Leaf("Leaf XB"));

root.add(compositeX);
root.add(new Leaf("Leaf C"));

const leafD = new Leaf("Leaf D");
root.add(leafD);
root.remove(leafD);

root.display(1);