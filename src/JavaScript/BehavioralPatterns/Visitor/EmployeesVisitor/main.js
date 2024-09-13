
class IVisitor {
    visit(element) {
        throw new Error('This method must be overridden.');
    }
}

class IncomeVisitor extends IVisitor {
    visit(element) {
        let employee = element instanceof Employee ? element : null;

        if (employee) {
            employee.income *= 1.10;
            console.log(`${employee.constructor.name} ${employee.name}'s new income: ${employee.income.toFixed(2)}`);
        }
    }
}

class VacationVisitor extends IVisitor {
    visit(element) {
        let employee = element instanceof Employee ? element : null;

        if (employee) {
            employee.vacationDays += 3;
            console.log(`${employee.constructor.name} ${employee.name}'s new vacation days: ${employee.vacationDays}`);
        }
    }
}

class Element {
    accept(visitor) {
        throw new Error('This method must be overridden.');
    }
}

class Employee extends Element {
    constructor(name, income, vacationDays) {
        super();
        this.name = name;
        this.income = income;
        this.vacationDays = vacationDays;
    }

    accept(visitor) {
        visitor.visit(this);
    }
}

class Clerk extends Employee {
    constructor() {
        super('Kevin', 25000.0, 14);
    }
}

class Director extends Employee {
    constructor() {
        super('Elly', 35000.0, 16);
    }
}

class President extends Employee {
    constructor() {
        super('Eric', 45000.0, 21);
    }
}

class Employees {
    constructor() {
        this.employees = [];
    }

    attach(employee) {
        this.employees.push(employee);
    }

    detach(employee) {
        this.employees = this.employees.filter(e => e !== employee);
    }

    accept(visitor) {
        this.employees.forEach(employee => employee.accept(visitor));
        console.log();
    }
}

const employees = new Employees();

employees.attach(new Clerk());
employees.attach(new Director());
employees.attach(new President());

const incomeVisitor = new IncomeVisitor();
const vacationVisitor = new VacationVisitor();

employees.accept(incomeVisitor);
employees.accept(vacationVisitor);