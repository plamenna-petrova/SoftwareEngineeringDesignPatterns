
class Employee {
    constructor(name, salary, designation) {
        this.name = name;
        this.salary = salary;
        this.designation = designation;
    }

    add(employee) {
        throw new Error("Cannot add to abstract Employee");
    }

    remove(employee) {
        throw new Error("Cannot remove from abstract Employee");
    }

    getHierarchicalLevel(level) {
        throw new Error("Cannot display abstract Employee");
    }
}

class TeamLead extends Employee {
    constructor(name, salary, designation) {
        super(name, salary, designation);
        this.employees = [];
    }

    add(employee) {
        this.employees.push(employee);
    }

    remove(employee) {
        const employeeRemovalIndex = this.employees.indexOf(employee);

        if (employeeRemovalIndex !== -1) {
            this.employees.splice(index, 1);
        }
    }

    getHierarchicalLevel(level) {
        console.log(`${"-".repeat(level)}+ ${this.name} [${this.designation}] [$${this.salary}]`);

        for (const employee of this.employees) {
            employee.getHierarchicalLevel(level + 2);
        }
    }
}

class Developer extends Employee {
    constructor(name, salary, designation) {
        super(name, salary, designation);
    }

    add(employee) {
        console.log("Cannot add to a developer");
    }

    remove(employee) {
        console.log("Cannot remove from a developer");
    }

    getHierarchicalLevel(level) {
        console.log(`${"-".repeat(level)} ${this.name} [${this.designation}] [$${this.salary}]`);
    }
}

const companyManager = new TeamLead("John", 100000, "Manager");
companyManager.add(new Developer("Jack", 20000, "Senior .NET Backend Developer"));
companyManager.add(new Developer("Jim", 25000, "Senior Python Developer"));
companyManager.add(new Developer("Jacob", 27000, "Senior Frontend Developer"));

const groupArchitect = new TeamLead("Joe", 50000, "Group Architect");
groupArchitect.add(new Developer("James", 15000, "Junior .NET Developer"));
groupArchitect.add(new Developer("Jason", 12000, "Angular Developer"));
companyManager.add(groupArchitect);

const developer = new Developer("Jerry", 18000, "Junior Frontend Developer");
companyManager.add(developer);
companyManager.remove(developer);

companyManager.getHierarchicalLevel(1);