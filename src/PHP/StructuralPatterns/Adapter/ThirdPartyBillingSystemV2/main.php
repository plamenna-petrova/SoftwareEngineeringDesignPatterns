<?php

class Employee
{
    public int $id;

    public string $name;
    public string $designation;

    public float $salary;
}

interface IEmployeesTarget
{
    public function processCompanySalary(array $employees): void;
}

class EmployeesAdapter implements IEmployeesTarget
{
    private ThirdPartyBillingSystem $thirdPartyBillingSystem;

    public function __construct()
    {
        $this->thirdPartyBillingSystem = new ThirdPartyBillingSystem();
    }

    public function processCompanySalary(array $employees): void
    {
        $adaptedEmployeesJaggedArray = array_map(function ($employee) {
            return [
                $employee->id,
                $employee->name,
                $employee->designation,
                $employee->salary,
            ];
        }, $employees);

        echo "Adapter converted array of employees to a list of employees\n";
        echo "Then delegate to the ThirdPartyBillingSystem for processing the employees salary\n\n";

        $this->thirdPartyBillingSystem->processSalary($adaptedEmployeesJaggedArray);
    }
}

class ThirdPartyBillingSystem
{
    public function processSalary(array $employeesJaggedArray): void
    {
        foreach ($employeesJaggedArray as $employeeArray) {
            echo "Salary: {$employeeArray[3]}, Credited to: {$employeeArray[1]} with designation: {$employeeArray[2]}\n";
        }
    }
}

class Engine
{
    public static function run(): void
    {
        $employeesToProcessCompanySalary = [];

        $employeeCommand = readline();

        while ($employeeCommand !== "END") {
            $employeeCommands = explode(' ', $employeeCommand);

            $employeeToProcessCompanySalary = new Employee();
            $employeeToProcessCompanySalary->id = (int)$employeeCommands[0];
            $employeeToProcessCompanySalary->name = $employeeCommands[1];
            $employeeToProcessCompanySalary->designation = $employeeCommands[2];
            $employeeToProcessCompanySalary->salary = (float)$employeeCommands[3];

            $employeesToProcessCompanySalary[] = $employeeToProcessCompanySalary;

            $employeeCommand = readline();
        }

        $employeesTarget = new EmployeesAdapter();
        $employeesTarget->processCompanySalary($employeesToProcessCompanySalary);
    }
}

Engine::run();