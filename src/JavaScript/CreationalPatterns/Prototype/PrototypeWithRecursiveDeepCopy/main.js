class ReferenceTypeClass {
    constructor(id) {
        this.ID = id;
    }
}

class Prototype {
    clone() {
        const cloned = this._deepCopy(this, new Map());
        return cloned;
    }

    deepCopy() {
        const cloned = this._deepCopy(this, new Map());
        return cloned;
    }

    _deepCopy(object, cache) {
        if (object === null || typeof object !== 'object' || object instanceof Function) {
            return object;
        }

        if (cache.has(object)) {
            return cache.get(object);
        }

        const copy = Array.isArray(object) ? [] : {};

        cache.set(object, copy);

        for (const key in object) {
            if (object.hasOwnProperty(key)) {
                copy[key] = this._deepCopy(object[key], cache);
            }
        }

        return copy;
    }
}

class ConcretePrototype extends Prototype {
    constructor() {
        super();
        this.valueType = '';
        this.dummyReference = new ReferenceTypeClass();
    }

    toString() {
        return `Value type: ${this.valueType}, Dummy Reference ID: ${this.dummyReference.ID}`;
    }
}

let firstConcretePrototype = new ConcretePrototype();
firstConcretePrototype.valueType = '1';
firstConcretePrototype.dummyReference.ID = '1';

let secondConcretePrototype = firstConcretePrototype.clone();
let thirdConcretePrototype = firstConcretePrototype.deepCopy();

secondConcretePrototype.valueType = '2';
secondConcretePrototype.dummyReference.ID = '2';

console.log(JSON.stringify(firstConcretePrototype, null, "\t"));
console.log(JSON.stringify(secondConcretePrototype, null, "\t"));
console.log(JSON.stringify(thirdConcretePrototype, null, "\t"));