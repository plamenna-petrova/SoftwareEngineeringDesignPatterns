
class State {
    constructor(vendingMachine) {
        this.vendingMachine = vendingMachine;
    }

    insertMoney(amount) {
        throw new Error("Method 'insertMoney' must be implemented.");
    }

    selectProduct(productCode) {
        throw new Error("Method 'selectProduct' must be implemented.");
    }

    dispenseProduct() {
        throw new Error("Method 'dispenseProduct' must be implemented.");
    }

    refill(products) {
        throw new Error("Method 'refill' must be implemented.");
    }

    cancel() {
        throw new Error("Method 'cancel' must be implemented.");
    }
}

module.exports = State;