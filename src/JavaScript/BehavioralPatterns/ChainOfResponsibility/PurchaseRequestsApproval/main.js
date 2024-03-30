
class Purchase {
    constructor(number, amount, purpose) {
        this.number = number;
        this.amount = amount;
        this.purpose = purpose;
    }
}

class Approver {
    setSuccessor(successor) {
        this.successor = successor;
    }

    processRequest(purchase) {
        throw new Error("Method 'processRequest' must be implemented");
    }
}

class Director extends Approver {
    processRequest(purchase) {
        if (purchase.amount < 10000.0) {
            console.log(`${this.constructor.name} approved request# ${purchase.number}`);
        } else {
            this.successor?.processRequest(purchase);
        }
    }
}

class VicePresident extends Approver {
    processRequest(purchase) {
        if (purchase.amount < 25000.0) {
            console.log(`${this.constructor.name} approved request# ${purchase.number}`);
        } else {
            this.successor?.processRequest(purchase);
        }
    }
}

class President extends Approver {
    processRequest(purchase) {
        if (purchase.amount < 100000.0) {
            console.log(`${this.constructor.name} approved request# ${purchase.number}`);
        } else {
            console.log(`Request# ${purchase.number} requires an executive meeting!`);
        }
    }
}

const director = new Director();
const vicePresident = new VicePresident();
const president = new President();

director.setSuccessor(vicePresident);
vicePresident.setSuccessor(president);

let purchase = new Purchase(2034, 350.00, "Supplies");
director.processRequest(purchase);

purchase = new Purchase(2035, 32590.10, "Project X");
director.processRequest(purchase);

purchase = new Purchase(2036, 122100.00, "Project Y");
director.processRequest(purchase);