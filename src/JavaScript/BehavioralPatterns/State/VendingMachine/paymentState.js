
const State = require("./state");
const DispenseProductState = require("./dispenseProductState");
const IdleState = require("./idleState");

class PaymentState extends State {
    constructor(vendingMachine) {
        super(vendingMachine);
        this.funds = 0;
        console.log("PAYMENT - You can insert coins.");
    }

    insertMoney(amount) {
        this.funds += amount;

        const selectedProduct = this.vendingMachine.products.find(p => p.code === this.vendingMachine.selectedProductCode);

        if (!selectedProduct) {
            console.log("No product selected.");
            return;
        }

        if (this.funds < selectedProduct.price) {
            console.log(`Remaining: ${selectedProduct.price - this.funds}`);
        } else {
            console.log("Proper amount received");

            const change = this.funds - selectedProduct.price;

            if (change > 0) {
                console.log(`Dispensing ${change} amount`);
            }

            this.vendingMachine.setState(new DispenseProductState(this.vendingMachine));
            this.vendingMachine.dispenseProduct();
        }
    }

    selectProduct(productCode) {
        console.log("The product is already selected. Please complete or cancel the current payment.");
    }

    dispenseProduct() {
        console.log("Cannot dispense product yet. Insufficient funds.");
    }

    cancel() {
        console.log("Cancelling order.");

        if (this.funds > 0) {
            console.log(`Returning the amount of ${this.funds}`);
        }

        this.vendingMachine.selectedProductCode = null;
        this.vendingMachine.setState(new IdleState(this.vendingMachine));
    }

    refill(products) {
        console.log("Cannot refill during payment operation. Please cancel or complete the payment before refill.");
    }
}

module.exports = PaymentState;