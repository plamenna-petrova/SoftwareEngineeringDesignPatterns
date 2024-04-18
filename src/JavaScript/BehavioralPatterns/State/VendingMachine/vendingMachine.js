
const IdleState = require("./idleState");

class VendingMachine {
    constructor(products) {
        this.products = products;
        this.currentState = new IdleState(this);
        this.selectedProductCode = null;
    }

    selectProduct(productCode) {
        this.currentState.selectProduct(productCode);
    }

    insertMoney(amount) {
        this.currentState.insertMoney(amount);
    }

    dispenseProduct() {
        this.currentState.dispenseProduct();
    }

    refill(products) {
        this.currentState.refill(products);
    }

    setState(state) {
        this.currentState = state;
    }
}

module.exports = VendingMachine;