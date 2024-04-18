
class InvoiceState {
    pay(invoice) {
        throw new Error("Method 'pay' must be implemented.");
    }

    cancel(invoice) {
        throw new Error("Method 'cancel' must be implemented.");
    }

    refund(invoice) {
        throw new Error("Method 'refund' must be implemented.");
    }
}

class Invoice {
    constructor(number, amount, description) {
        this.number = number;
        this.amount = amount;
        this.description = description;
        this.state = new UnpaidState();
    }

    pay() {
        this.state.pay(this);
        this.state = new PaidState();
    }

    cancel() {
        this.state.cancel(this);
        this.state = new CanceledState();
    }

    refund() {
        this.state.refund(this);
        this.state = new RefundedState();
    }
}

class UnpaidState extends InvoiceState {
    pay(invoice) {
        console.log(`Paying invoice ${invoice.number}...`);
    }

    cancel(invoice) {
        console.log(`Cancelling invoice ${invoice.number}...`);
    }

    refund(invoice) {
        console.log(`Invoice ${invoice.number} is unpaid and cannot be refunded.`);
    }
}

class PaidState extends InvoiceState {
    pay(invoice) {
        console.log(`Invoice ${invoice.number} has already been paid.`);
    }

    cancel(invoice) {
        console.log(`Invoice ${invoice.number} cannot be cancelled.`);
    }

    refund(invoice) {
        console.log(`Invoice ${invoice.number} has been refunded.`);
    }
}

class CanceledState extends InvoiceState {
    pay(invoice) {
        console.log(`Invoice ${invoice.number} has been cancelled and cannot be paid.`);
    }

    cancel(invoice) {
        console.log(`Invoice ${invoice.number} has been cancelled and cannot be cancelled again.`);
    }

    refund(invoice) {
        console.log(`Invoice ${invoice.number} has been cancelled and cannot be refunded.`);
    }
}

class RefundedState extends InvoiceState {
    pay(invoice) {
        console.log(`Invoice ${invoice.number} was refunded and cannot be paid.`);
    }

    cancel(invoice) {
        console.log(`Invoice ${invoice.number} was refunded and cannot be cancelled.`);
    }

    refund(invoice) {
        console.log(`Invoice ${invoice.number} was refunded and cannot be refunded again.`);
    }
}

const invoice = new Invoice(123, 1000, "Software Devs Services");

invoice.pay();
invoice.refund();