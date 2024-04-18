
const DeveloperLevel = {
    Junior: 0,
    Senior: 1
};

class DeveloperReport {
    constructor(id, name, developerLevel, workingHours, hourlyRate) {
        this.Id = id;
        this.Name = name;
        this.DeveloperLevel = developerLevel;
        this.WorkingHours = workingHours;
        this.HourlyRate = hourlyRate;
    }

    calculateSalary() {
        return this.WorkingHours * this.HourlyRate;
    }
}

class SalaryCalculatorStrategy {
    calculateTotalSalary(developerReports) {}
}

class JuniorDeveloperSalaryCalculatorStrategy extends SalaryCalculatorStrategy {
    calculateTotalSalary(developerReports) {
        return developerReports
            .filter(dr => dr.DeveloperLevel === DeveloperLevel.Junior)
            .map(dr => dr.calculateSalary())
            .reduce((acc, curr) => acc + curr, 0);
    }
}

class SeniorDeveloperSalaryCalculatorStrategy extends SalaryCalculatorStrategy {
    calculateTotalSalary(developerReports) {
        return developerReports
            .filter(dr => dr.DeveloperLevel === DeveloperLevel.Senior)
            .map(dr => dr.calculateSalary())
            .reduce((acc, curr) => acc + curr, 0);
    }
}

class SalaryCalculatorContext {
    constructor(salaryCalculatorStrategy) {
        this.salaryCalculatorStrategy = salaryCalculatorStrategy;
    }

    setSalaryCalculatorStrategy(salaryCalculatorStrategy) {
        this.salaryCalculatorStrategy = salaryCalculatorStrategy;
    }

    calculate(developerReports) {
        return this.salaryCalculatorStrategy.calculateTotalSalary(developerReports);
    }
}

const developerReports = [
    new DeveloperReport(1, "Developer 1", DeveloperLevel.Senior, 160, 30.5),
    new DeveloperReport(2, "Developer 2", DeveloperLevel.Junior, 120, 20),
    new DeveloperReport(3, "Developer 3", DeveloperLevel.Senior, 130, 32.5),
    new DeveloperReport(4, "Developer 4", DeveloperLevel.Junior, 140, 24.5)
];

const salaryCalculatorContext = new SalaryCalculatorContext(new JuniorDeveloperSalaryCalculatorStrategy());
const juniorsTotalSalary = salaryCalculatorContext.calculate(developerReports);
console.log(`The total amount for the junior salaries is: ${juniorsTotalSalary}`);

salaryCalculatorContext.setSalaryCalculatorStrategy(new SeniorDeveloperSalaryCalculatorStrategy());
const seniorsTotalSalary = salaryCalculatorContext.calculate(developerReports);
console.log(`The total amount for the senior salaries is: ${seniorsTotalSalary}`);

const totalCost = juniorsTotalSalary + seniorsTotalSalary;
console.log(`The total cost for all salaries is: ${totalCost}`);