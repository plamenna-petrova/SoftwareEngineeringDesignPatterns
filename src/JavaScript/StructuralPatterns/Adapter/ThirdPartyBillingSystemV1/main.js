
class Employee {
    constructor() {
        this.id = 0;
        this.name = '';
        this.designation = '';
        this.salary = 0.0;
    }
}

class EmployeesAdapter {
    constructor() {
        this.thirdPartyBillingSystem = new ThirdPartyBillingSystem();
    }

    processCompanySalary(employeesArray) {
        const adaptedEmployees = [];

        for (let i = 0; i < employeesArray.length; i++) {
            const employee = new Employee();

            for (let j = 0; j < employeesArray[i].length; j++) {
                const employeeDatum = employeesArray[i][j];

                switch (j) {
                    case 0:
                        employee.id = parseInt(employeeDatum);
                        break;
                    case 1:
                        employee.name = employeeDatum;
                        break;
                    case 2:
                        employee.designation = employeeDatum;
                        break;
                    case 3:
                        employee.salary = parseFloat(employeeDatum);
                        break;
                }
            }

            adaptedEmployees.push(employee);
        }

        console.log("Adapter converted array of employees to a list of employees");
        console.log("Then delegate to the ThirdPartyBillingSystem for processing the employees salary\n");

        this.thirdPartyBillingSystem.processSalary(adaptedEmployees);
    }
}

class ThirdPartyBillingSystem {
    processSalary(employees) {
        for (const employee of employees) {
            console.log(`Salary: ${employee.salary}, Credited to: ${employee.name} with designation: ${employee.designation}`);
        }
    }
}

class Engine {
    static run() {
        const employees2DDataArray = this.fill2DArrayElementsWithRowsAndCols(5, 4);
        console.log();

        const employeesTarget = new EmployeesAdapter();
        console.log("HR system passes employee string array to Adapter");
        employeesTarget.processCompanySalary(employees2DDataArray);
    }

    static fill2DArrayElementsWithRowsAndCols(rows, cols) {
        const twoDimensionalArray = [];

        for (let row = 0; row < rows; row++) {
            const rowArray = prompt("Enter employee data: ").split(" ");
            twoDimensionalArray.push(rowArray);
        }

        return twoDimensionalArray;
    }
}

const prompt = require("prompt-sync")();

Engine.run();
