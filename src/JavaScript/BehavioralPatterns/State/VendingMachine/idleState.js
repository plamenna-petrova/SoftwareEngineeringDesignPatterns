
const State = require("./state");
const PaymentState = require("./paymentState");

class IdleState extends State {
    constructor(vendingMachine) {
        super(vendingMachine);
        console.log("IDLE - Wait for product selection");
    }

    insertMoney(amount) {
        console.log("Please select a product before inserting any money.");
    }

    selectProduct(productCode) {
        const selectedProduct = this.vendingMachine.products.find(p => p.code === productCode);

        if (!selectedProduct || selectedProduct.stock === 0) {
            console.log(`The product code: ${productCode} is out of stock`);
            return;
        }

        this.vendingMachine.selectedProductCode = productCode;
        console.log(`Product: ${productCode} with price: ${selectedProduct.price} selected.`);
        this.vendingMachine.setState(new PaymentState(this.vendingMachine));
    }

    dispenseProduct() {
        console.log("Select a product first.");
    }

    cancel() {
        console.log("There is no selected product or payment in process to cancel.");
    }

    refill(products) {
        this.vendingMachine.products = products;
        console.log(`Total amount of products: ${this.vendingMachine.products.reduce((total, p) => total + p.stock, 0)}`);
    }
}

module.exports = IdleState;