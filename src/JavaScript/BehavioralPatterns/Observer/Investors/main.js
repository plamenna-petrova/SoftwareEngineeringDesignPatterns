
class Stock {
    constructor(symbol, price) {
        this.symbol = symbol;
        this.price = price;
        this.investors = [];
    }

    attach(investor) {
        this.investors.push(investor);
    }

    detach(investor) {
        const index = this.investors.indexOf(investor);
        if (index !== -1) {
            this.investors.splice(index, 1);
        }
    }

    notify() {
        for (const investor of this.investors) {
            investor.update(this);
        }
        console.log("");
    }

    get Symbol() {
        return this.symbol;
    }

    get Price() {
        return this.price;
    }

    set Price(value) {
        if (this.price !== value) {
            this.price = value;
            this.notify();
        }
    }
}

class IBM extends Stock {
    constructor(symbol, price) {
        super(symbol, price);
    }
}

class Investor {
    constructor(name) {
        this.name = name;
    }

    get Name() {
        return this.name;
    }

    set Name(value) {
        this.name = value;
    }

    update(stock) {
        console.log(`Notified ${this.name} of ${stock.Symbol}'s change to $${stock.Price.toFixed(2)}`);
    }
}

const ibm = new IBM("IBM", 120.00);

ibm.attach(new Investor("Sorros"));
ibm.attach(new Investor("Berkshire"));

ibm.Price = 120.10;
ibm.Price = 121.00;
ibm.Price = 120.50;
ibm.Price = 120.75;