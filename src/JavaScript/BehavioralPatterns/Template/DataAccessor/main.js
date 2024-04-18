
class DataAccessor {
    connect() {
        throw new Error("Abstract method connect() must be implemented.");
    }

    select() {
        throw new Error("Abstract method select() must be implemented.");
    }

    process(top) {
        throw new Error("Abstract method process(top) must be implemented.");
    }

    disconnect() {
        throw new Error("Abstract method disconnect() must be implemented.");
    }

    run(top) {
        this.connect();
        this.select();
        this.process(top);
        this.disconnect();
    }
}

class Categories extends DataAccessor {
    constructor() {
        super();
        this.categories = [];
    }

    connect() {
        this.categories = [];
    }

    select() {
        this.categories.push("Red", "Green", "Blue", "Orange", "Purple", "White", "Black");
    }

    process(top) {
        console.log("Categories ---- ");

        for (let i = 0; i < Math.min(top, this.categories.length); i++) {
            console.log(this.categories[i]);
        }
        
        console.log();
    }

    disconnect() {
        this.categories = [];
    }
}

class Products extends DataAccessor {
    constructor() {
        super();
        this.products = [];
    }

    connect() {
        this.products = [];
    }

    select() {
        this.products.push("Car", "Bike", "Boat", "Truck", "Moped", "Rollerskate", "Stroller");
    }

    process(top) {
        console.log("Products ---- ");

        for (let i = 0; i < Math.min(top, this.products.length); i++) {
            console.log(this.products[i]);
        }

        console.log();
    }

    disconnect() {
        this.products = [];
    }
}

let categories = new Categories();
categories.run(5);

let products = new Products();
products.run(3);