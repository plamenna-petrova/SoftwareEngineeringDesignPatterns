
class Memento {
    constructor(name, phone, budget) {
        this.name = name;
        this.phone = phone;
        this.budget = budget;
    }
}

class SalesProspect {
    constructor() {
        this.name = '';
        this.phone = '';
        this.budget = 0;
    }

    get getName() {
        return this.name;
    }

    set setName(name) {
        this.name = name;
        console.log("Name: " + this.name);
    }

    get getPhone() {
        return this.phone;
    }

    set setPhone(phone) {
        this.phone = phone;
        console.log("Phone: " + this.phone);
    }

    get getBudget() {
        return this.budget;
    }

    set setBudget(budget) {
        this.budget = budget;
        console.log("Budget: " + this.budget);
    }

    saveMemento() {
        console.log("\nSaving state --\n");
        return new Memento(this.name, this.phone, this.budget);
    }

    restoreMemento(memento) {
        console.log("\nRestoring state --\n");
        this.setName = memento.name;
        this.setPhone = memento.phone;
        this.setBudget = memento.budget;
    }
}

class ProspectMemory {
    constructor() {
        this.memento = null;
    }

    get getMemento() {
        return this.memento;
    }

    set setMemento(memento) {
        this.memento = memento;
    }
}

const salesProspect = new SalesProspect();
salesProspect.setName = "Noel van Halen";
salesProspect.setPhone = "(412) 256-0990";

const prospectMemory = new ProspectMemory();
prospectMemory.setMemento = salesProspect.saveMemento();

salesProspect.setName = "Leo Welch";
salesProspect.setPhone = "(310) 209-7111";
salesProspect.setBudget = 100000.0;

salesProspect.restoreMemento(prospectMemory.getMemento);