
class MenuItem {
    constructor(name, amount, price) {
        this.name = name;
        this.amount = amount;
        this.price = price;
    }

    display() {
        console.log(`\nName: ${this.name}`);
        console.log(`Amount: ${this.amount}`);
        console.log(`Price: $${this.price}`);
    }
}

module.exports = MenuItem;