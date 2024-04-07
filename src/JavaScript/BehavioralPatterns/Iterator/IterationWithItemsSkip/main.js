
class Item {
    constructor(name) {
        this.name = name;
    }

    get Name() {
        return this.name;
    }
}

class Iterator {
    constructor(collection) {
        this.collection = collection;
        this.currentItemIndex = 0;
        this.stepsToSkip = 1;
    }

    get IsIterationDone() {
        return this.currentItemIndex >= this.collection.Count;
    }

    get GetCurrentItem() {
        return this.collection.getItem(this.currentItemIndex);
    }

    get StepToSkip() {
        return this.stepsToSkip;
    }

    set StepToSkip(value) {
        this.stepsToSkip = value;
    }

    getFirstItem() {
        this.currentItemIndex = 0;
        return this.collection.getItem(this.currentItemIndex);
    }

    getNextItem() {
        this.currentItemIndex += this.stepsToSkip;
        if (this.IsIterationDone) {
            return null;
        } else {
            return this.collection.getItem(this.currentItemIndex);
        }
    }
}

class Collection {
    constructor() {
        this.items = [];
    }

    createIterator() {
        return new Iterator(this);
    }

    get Count() {
        return this.items.length;
    }

    setItem(index, value) {
        this.items[index] = value;
    }

    getItem(index) {
        return this.items[index];
    }
}

const collectionToIterateOver = new Collection();

for (let i = 0; i < 8; i++) {
    collectionToIterateOver.setItem(i, new Item(`Item ${i + 1}`));
}

const iterator = collectionToIterateOver.createIterator();

iterator.StepToSkip = 2;

console.log("Iterating over a collection: ");

for (let currentItem = iterator.getFirstItem(); !iterator.IsIterationDone; currentItem = iterator.getNextItem()) {
    console.log(currentItem.Name);
}