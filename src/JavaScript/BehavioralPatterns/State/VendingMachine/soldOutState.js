
const State = require("./state");
const IdleState = require("./idleState");

class SoldOutState extends State {
    constructor(vendingMachine) {
        super(vendingMachine);
        console.log("SOLDOUT");
    }

    insertMoney(amount) {
        console.log("There are no products in the vending machine.");
    }

    selectProduct(productCode) {
        console.log("There are no products in the vending machine.");
    }

    dispenseProduct() {
        console.log("There is no selected product for dispensing");
    }

    cancel() {
        console.log("There is no operation to be cancelled");
    }

    refill(products) {
        this.vendingMachine.products = products;
        console.log(`Total amount of products: ${this.vendingMachine.products.reduce((acc, curr) => acc + curr.stock, 0)}`);
        this.vendingMachine.setState(new IdleState(this.vendingMachine));
    }
}

module.exports = SoldOutState;