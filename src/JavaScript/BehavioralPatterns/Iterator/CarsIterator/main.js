
class Iterator {
    constructor() {
        if (this.constructor === Iterator) {
            throw new Error("Abstract class cannot be instantiated directly.");
        }
    }

    moveNext() {
        throw new Error("Method 'moveNext()' must be implemented.");
    }

    get currentItem() {
        throw new Error("Property 'currentItem' must be implemented.");
    }
}

class ConcreteIteratorForItems extends Iterator {
    constructor(data) {
        super();
        this.data = data;
        this.currentPosition = -1;
    }

    get currentItem() {
        return this.data[this.currentPosition];
    }

    moveNext() {
        if (this.currentPosition < this.data.length - 1) {
            this.currentPosition++;
            return true;
        }
        return false;
    }
}

class Iterable {
    createIterator() {
        throw new Error("Method 'createIterator()' must be implemented.");
    }
}

class Collection extends Iterable {
    constructor(items) {
        super();
        this.items = items;
    }

    createIterator() {
        return new ConcreteIteratorForItems(this.items);
    }
}

class Car {
    constructor(name) {
        this.Name = name;
    }

    toString() {
        return this.Name;
    }
}

class Ferrari extends Iterable {
    constructor() {
        super();
        this.cars = [];
    }

    addCar(car) {
        this.cars.push(car);
    }

    removeCar(name) {
        const index = this.cars.findIndex(car => car.Name === name);
        if (index !== -1) {
            this.cars.splice(index, 1);
        }
    }

    *[Symbol.iterator]() {
        yield* this.cars;
    }
}

class Ford extends Iterable {
    constructor(cars) {
        super();
        this.cars = cars;
    }

    *[Symbol.iterator]() {
        yield* this.cars;
    }
}

class CarDealer {
    constructor(...carCompanies) {
        this.carCompanies = carCompanies;
    }

    printCars() {
        for (const company of this.carCompanies) {
            for (const car of company) {
                console.log(car.toString());
            }
        }
    }
}

class Node {
    constructor(value) {
        this.value = value;
        this.left = null;
        this.right = null;
    }
}

class BinaryTreeIterator {
    constructor(root) {
        if (this.constructor === BinaryTreeIterator) {
            throw new Error("Abstract class cannot be instantiated directly.");
        }
        this.queue = [];
        this.root = root;
        this.traverse(this.root);
    }

    traverse(node) {
        throw new Error("Method 'traverse()' must be implemented.");
    }

    moveNext() {
        if (this.queue.length > 0) {
            this.currentItem = this.queue.shift();
            return true;
        }
        return false;
    }
}

class PreOrderIterator extends BinaryTreeIterator {
    constructor(root) {
        super(root);
    }

    traverse(node) {
        if (!node) return;
        this.queue.push(node);
        this.traverse(node.left);
        this.traverse(node.right);
    }
}

class InOrderIterator extends BinaryTreeIterator {
    constructor(root) {
        super(root);
    }

    traverse(node) {
        if (!node) return;
        this.traverse(node.left);
        this.queue.push(node);
        this.traverse(node.right);
    }
}

class PostOrderIterator extends BinaryTreeIterator {
    constructor(root) {
        super(root);
    }

    traverse(node) {
        if (!node) return;
        this.traverse(node.left);
        this.traverse(node.right);
        this.queue.push(node);
    }
}

const collectionToIterateOver = new Collection(["Item1", "Item2", "Item3"]);

const iterator = collectionToIterateOver.createIterator();

while (iterator.moveNext()) {
    console.log(iterator.currentItem);
}

const ferrari = new Ferrari();

ferrari.addCar(new Car("Ferrari F40"));
ferrari.addCar(new Car("Ferrari F355"));
ferrari.addCar(new Car("Ferrari 250 GT0"));
ferrari.addCar(new Car("Ferrari 125 S"));
ferrari.addCar(new Car("Ferrari 488 GTB"));

const ford = new Ford([
    new Car("Ford Model T"),
    new Car("Ford GT40"),
    new Car("Ford Escort"),
    new Car("Ford Focus"),
    new Car("Ford Mustang")
]);

const carDealer = new CarDealer(ferrari, ford);
carDealer.printCars();

const root = new Node(25);
root.left = new Node(15);
root.right = new Node(50);
root.left.left = new Node(10);
root.left.right = new Node(22);
root.right.left = new Node(35);
root.right.right = new Node(70);
root.left.left.left = new Node(4);
root.left.left.right = new Node(12);
root.left.right.left = new Node(18);
root.left.right.right = new Node(24);
root.right.left.left = new Node(31);
root.right.left.right = new Node(44);
root.right.right.left = new Node(66);
root.right.right.right = new Node(90);

const preOrderIterator = new PreOrderIterator(root);
const postOrderIterator = new PostOrderIterator(root);
const inOrderIterator = new InOrderIterator(root);

iterateTree(preOrderIterator);
iterateTree(postOrderIterator);
iterateTree(inOrderIterator);

function iterateTree(binaryTreeIterator) {
    const results = [];
    while (binaryTreeIterator.moveNext()) {
        results.push(binaryTreeIterator.currentItem.value);
    }
    console.log(`${binaryTreeIterator.constructor.name} results: ${results.join(",")}`);
}