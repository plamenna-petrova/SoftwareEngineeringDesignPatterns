
class Product {
    constructor(name, price) {
        this.name = name;
        this.price = price;
    }

    increasePrice(amount) {
        this.price += amount;
        console.log(`The price for the ${this.name} has been increased by ${amount}$.`);
    }

    decreasePrice(amount) {
        if (amount < this.price) {
            this.price -= amount;
            console.log(`The price for the ${this.name} has been decreased by ${amount}$.`);
            return true;
        }
        return false;
    }

    toString() {
        return `The current price for the ${this.name} product is ${this.price}$.`;
    }
}

class ProductCommand {
    constructor(product, priceAction, amount) {
        this.product = product;
        this.priceAction = priceAction;
        this.amount = amount;
        this.isCommandExecuted = false;
    }

    executeAction() {
        if (this.priceAction === 'Increase') {
            this.product.increasePrice(this.amount);
            this.isCommandExecuted = true;
        } else {
            this.isCommandExecuted = this.product.decreasePrice(this.amount);
        }
    }

    undoAction() {
        if (!this.isCommandExecuted) return;

        if (this.priceAction === 'Increase') {
            this.product.decreasePrice(this.amount);
        } else {
            this.product.increasePrice(this.amount);
        }
    }
}

class PriceModifier {
    constructor() {
        this.commands = [];
        this.command = null;
    }

    setCommand(command) {
        this.command = command;
    }

    invoke() {
        this.commands.push(this.command);
        this.command.executeAction();
    }

    undoActions() {
        for (let i = this.commands.length - 1; i >= 0; i--) {
            this.commands[i].undoAction();
        }
    }
}

const priceModifier = new PriceModifier();
const product = new Product("Phone", 500);

function execute(priceModifier, productCommand) {
    priceModifier.setCommand(productCommand);
    priceModifier.invoke();
}

execute(priceModifier, new ProductCommand(product, 'Increase', 100));
execute(priceModifier, new ProductCommand(product, 'Increase', 50));
execute(priceModifier, new ProductCommand(product, 'Decrease', 25));

console.log(product.toString());
console.log();

priceModifier.undoActions();

console.log(product.toString());