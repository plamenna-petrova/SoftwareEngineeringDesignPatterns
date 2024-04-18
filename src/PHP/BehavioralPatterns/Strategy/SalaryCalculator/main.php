<?php

class DeveloperLevel {
    const Junior = 0;
    const Senior = 1;
}

class DeveloperReport {
    public int $id;
    public string $name;
    public $developerLevel;
    public int $workingHours;
    public float $hourlyRate;

    public function __construct($data) {
        $this->id = $data['Id'];
        $this->name = $data['Name'];
        $this->developerLevel = $data['DeveloperLevel'];
        $this->workingHours = $data['WorkingHours'];
        $this->hourlyRate = $data['HourlyRate'];
    }

    public function calculateSalary(): float|int
    {
        return $this->workingHours * $this->hourlyRate;
    }
}

interface ISalaryCalculatorStrategy {
    public function calculateTotalSalary($developerReports);
}

class JuniorDeveloperSalaryCalculatorStrategy implements ISalaryCalculatorStrategy {
    public function calculateTotalSalary($developerReports): float|int
    {
        return array_sum(array_map(function($dr) {
            return $dr->calculateSalary();
        }, array_filter($developerReports, function($dr) {
            return $dr->developerLevel == DeveloperLevel::Junior;
        })));
    }
}

class SeniorDeveloperSalaryCalculatorStrategy implements ISalaryCalculatorStrategy {
    public function calculateTotalSalary($developerReports): float|int
    {
        return array_sum(array_map(function($dr) {
            return $dr->calculateSalary();
        }, array_filter($developerReports, function($dr) {
            return $dr->developerLevel == DeveloperLevel::Senior;
        })));
    }
}

class SalaryCalculatorContext {
    private ISalaryCalculatorStrategy $salaryCalculatorStrategy;

    public function __construct(ISalaryCalculatorStrategy $salaryCalculatorStrategy) {
        $this->salaryCalculatorStrategy = $salaryCalculatorStrategy;
    }

    public function setSalaryCalculatorStrategy(ISalaryCalculatorStrategy $salaryCalculatorStrategy): void
    {
        $this->salaryCalculatorStrategy = $salaryCalculatorStrategy;
    }

    public function calculate($developerReports) {
        return $this->salaryCalculatorStrategy->calculateTotalSalary($developerReports);
    }
}

$developerReports = [
    new DeveloperReport([
        "Id" => 1,
        "Name" => "Developer 1",
        "DeveloperLevel" => DeveloperLevel::Senior,
        "HourlyRate" => 30.5,
        "WorkingHours" => 160
    ]),
    new DeveloperReport([
        "Id" => 2,
        "Name" => "Developer 2",
        "DeveloperLevel" => DeveloperLevel::Junior,
        "HourlyRate" => 20,
        "WorkingHours" => 120
    ]),
    new DeveloperReport([
        "Id" => 3,
        "Name" => "Developer 3",
        "DeveloperLevel" => DeveloperLevel::Senior,
        "HourlyRate" => 32.5,
        "WorkingHours" => 130
    ]),
    new DeveloperReport([
        "Id" => 4,
        "Name" => "Developer 4",
        "DeveloperLevel" => DeveloperLevel::Junior,
        "HourlyRate" => 24.5,
        "WorkingHours" => 140
    ])
];

$salaryCalculatorContext = new SalaryCalculatorContext(new JuniorDeveloperSalaryCalculatorStrategy());
$juniorsTotalSalary = $salaryCalculatorContext->calculate($developerReports);
echo "The total amount for the junior salaries is: $juniorsTotalSalary\n";

$salaryCalculatorContext->setSalaryCalculatorStrategy(new SeniorDeveloperSalaryCalculatorStrategy());
$seniorsTotalSalary = $salaryCalculatorContext->calculate($developerReports);
echo "The total amount for the senior salaries is: $seniorsTotalSalary\n";

$totalCost = $juniorsTotalSalary + $seniorsTotalSalary;
echo "The total cost for all salaries is: $totalCost\n";