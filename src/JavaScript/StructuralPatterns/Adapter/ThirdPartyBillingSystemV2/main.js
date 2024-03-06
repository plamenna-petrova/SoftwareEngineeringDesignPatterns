
class Employee {
    constructor(ID, Name, Designation, Salary) {
        this.ID = ID;
        this.Name = Name;
        this.Designation = Designation;
        this.Salary = Salary;
    }
}

class EmployeesAdapter {
    constructor() {
        this.thirdPartyBillingSystem = new ThirdPartyBillingSystem();
    }

    processCompanySalary(employees) {
        const adaptedEmployeesJaggedArray = employees.map(e => [e.ID.toString(), e.Name, e.Designation, e.Salary.toString()]);

        console.log("Adapter converted array of employees to a list of employees");
        console.log("Then delegate to the ThirdPartyBillingSystem for processing the employees salary\n");

        this.thirdPartyBillingSystem.processSalary(adaptedEmployeesJaggedArray);
    }
}

class ThirdPartyBillingSystem {
    processSalary(employeesJaggedArray) {
        employeesJaggedArray.forEach(employeeDataArray => {
            console.log(`Salary: ${employeeDataArray[3]}, Credited to: ${employeeDataArray[1]} with designation: ${employeeDataArray[2]}`);
        });
    }
}

class Engine {
    static run() {
        const employeesToProcessCompanySalary = [];

        let employeeCommand = prompt("Enter employee data: ");

        while (employeeCommand !== "END") {
            const employeeCommands = employeeCommand.split(" ");

            const employeeToProcessCompanySalary = new Employee(
                parseInt(employeeCommands[0]),
                employeeCommands[1],
                employeeCommands[2],
                parseFloat(employeeCommands[3])
            );

            employeesToProcessCompanySalary.push(employeeToProcessCompanySalary);

            employeeCommand = prompt("Enter employee data: ");
        }

        const employeesTarget = new EmployeesAdapter();
        employeesTarget.processCompanySalary(employeesToProcessCompanySalary);
    }
}

const prompt = require("prompt-sync")();

Engine.run();
