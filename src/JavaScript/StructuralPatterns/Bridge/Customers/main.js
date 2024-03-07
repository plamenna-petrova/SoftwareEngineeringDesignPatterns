
class CustomersBase {
    constructor() {
        this._dataObject = null;
    }

    set dataObject(value) {
        this._dataObject = value;
    }

    next() {
        this._dataObject.getNextRecord();
    }

    previous() {
        this._dataObject.getPreviousRecord();
    }

    add(record) {
        this._dataObject.addRecord(record);
    }

    remove(record) {
        this._dataObject.removeRecord(record);
    }

    show() {
        this._dataObject.showRecord();
    }

    showAll() {
        this._dataObject.showAllRecords();
    }
}

class RefinedCustomers extends CustomersBase {
    showAll() {
        console.log();
        console.log('-'.repeat(40));
        super.showAll();
        console.log('-'.repeat(40));
    }
}

class DataObject {
    getNextRecord() {
        // To be implemented by concrete implementations
    }

    getPreviousRecord() {
        // To be implemented by concrete implementations
    }

    addRecord(record) {
        // To be implemented by concrete implementations
    }

    removeRecord(record) {
        // To be implemented by concrete implementations
    }

    getCurrentRecord() {
        // To be implemented by concrete implementations
    }

    showRecord() {
        // To be implemented by concrete implementations
    }

    showAllRecords() {
        // To be implemented by concrete implementations
    }
}

class CustomersData extends DataObject {
    constructor(city) {
        super();
        this.city = city;
        this.customers = [
            'Jim Jones',
            'Samuel Jackson',
            'Allen Good',
            'Ann Stills',
            'Lisa Giolani'
        ];
        this.currentCustomerIndex = 0;
    }

    getNextRecord() {
        if (this.currentCustomerIndex <= this.customers.length - 1) {
            this.currentCustomerIndex++;
        }
    }

    getPreviousRecord() {
        if (this.currentCustomerIndex > 0) {
            this.currentCustomerIndex--;
        }
    }

    addRecord(record) {
        this.customers.push(record);
    }

    removeRecord(record) {
        const index = this.customers.indexOf(record);
        if (index !== -1) {
            this.customers.splice(index, 1);
        }
    }

    getCurrentRecord() {
        return this.customers[this.currentCustomerIndex];
    }

    showRecord() {
        console.log(this.customers[this.currentCustomerIndex]);
    }

    showAllRecords() {
        console.log(`Customers City: ${this.city}`);
        console.log(this.customers.map(c => ` ${c}`).join('\n'));
    }
}

const customers = new RefinedCustomers();
customers.dataObject = new CustomersData('Chicago');

customers.show();
customers.next();
customers.show();
customers.next();
customers.show();
customers.previous();
customers.show();
customers.add('Henry Velasquez');
customers.showAll();
customers.remove('Allen Good');
customers.showAll();