
const IdleState = require("./idleState");
const State = require("./state");
const SoldOutState = require("./soldOutState");

class DispenseProductState extends State {
    constructor(vendingMachine) {
        super(vendingMachine);
        console.log("DISPENSING");
    }

    insertMoney(amount) {
        console.log("Cannot insert money during the dispensing of the product");
    }

    selectProduct(productCode) {
        console.log("The product is already selected.");
    }

    dispenseProduct() {
        if (!this.vendingMachine.selectedProductCode) {
            console.log("There is no selected product for dispensing");
            this.vendingMachine.setState(new IdleState(this.vendingMachine));
            return;
        }

        console.log("Dispensing product.");
        setTimeout(() => {
            const productIndex = this.vendingMachine.products.findIndex(p => p.code === this.vendingMachine.selectedProductCode);
            if (productIndex !== -1) {
                this.vendingMachine.products[productIndex].stock--;
                console.log("The product is dispensed.");
                if (this.vendingMachine.products.every(p => p.stock === 0)) {
                    this.vendingMachine.setState(new SoldOutState(this.vendingMachine));
                } else {
                    this.vendingMachine.setState(new IdleState(this.vendingMachine));
                }
            }
        }, 2000);
    }

    cancel() {
        console.log("Cannot cancel the dispensing operation");
    }

    refill(products) {
        console.log("Cannot refill during the dispensing of the product");
    }
}

module.exports = DispenseProductState;