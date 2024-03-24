
class Customer {
    constructor(name) {
        this.name = name;
    }
}

class Bank {
    hasSufficientSavings(customer, amount) {
        console.log(`Check bank for ${customer.name} with amount: ${amount}`);
        return true;
    }
}

class Credit {
    hasGoodCredit(customer) {
        console.log(`Check credit for ${customer.name}`);
        return true;
    }
}

class Loan {
    hasNoBadLoans(customer) {
        console.log(`Check loans for ${customer.name}`);
        return true;
    }
}

class Mortgage {
    constructor() {
        this.bank = new Bank();
        this.loan = new Loan();
        this.credit = new Credit();
    }

    isEligible(customer, amount) {
        console.log(`${customer.name} applies for $${amount} loan \n`);

        let isEligible = true;

        if (!this.bank.hasSufficientSavings(customer, amount)) {
            isEligible = false;
        } else if (!this.loan.hasNoBadLoans(customer)) {
            isEligible = false;
        } else if (!this.credit.hasGoodCredit(customer)) {
            isEligible = false;
        }

        return isEligible;
    }
}

const mortgage = new Mortgage();
const customer = new Customer("Ann McKinsey");

const isEligibleForMortgage = mortgage.isEligible(customer, 1250000);

console.log(`\nCustomer ${customer.name} has been ${isEligibleForMortgage ? "Approved" : "Rejected"}`);