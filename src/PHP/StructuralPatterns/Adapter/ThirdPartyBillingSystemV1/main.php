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
    public function processCompanySalary(array $employeesArray): void;
}

class EmployeesAdapter implements IEmployeesTarget
{
    private ThirdPartyBillingSystem $thirdPartyBillingSystem;

    public function __construct()
    {
        $this->thirdPartyBillingSystem = new ThirdPartyBillingSystem();
    }

    public function processCompanySalary(array $employeesArray): void
    {
        $adaptedEmployees = [];

        foreach ($employeesArray as $employeeData) {
            $employee = new Employee();

            $employee->id = (int)$employeeData[0];
            $employee->name = $employeeData[1];
            $employee->designation = $employeeData[2];
            $employee->salary = (float)$employeeData[3];

            $adaptedEmployees[] = $employee;
        }

        echo "Adapter converted array of employees to a list of employees\n";
        echo "Then delegate to the ThirdPartyBillingSystem for processing the employees salary\n\n";

        $this->thirdPartyBillingSystem->processSalary($adaptedEmployees);
    }
}

class ThirdPartyBillingSystem
{
    public function processSalary(array $employees): void
    {
        foreach ($employees as $employee) {
            echo "Salary: {$employee->salary}, Credited to: {$employee->name} with designation: {$employee->designation}\n";
        }
    }
}

class Engine
{
    // Enter data from EmployeesV1.txt

    public static function run(): void
    {
        $employees2DDataArray = self::fill2DArrayElementsWithRowsAndCols(5, 4);
        echo "\n";

        $employeesTarget = new EmployeesAdapter();
        echo "HR system passes employee string array to Adapter\n";
        $employeesTarget->processCompanySalary($employees2DDataArray);
    }

    private static function fill2DArrayElementsWithRowsAndCols(int $rows, int $cols): array
    {
        $twoDimensionalArray = [];

        for ($row = 0; $row < $rows; $row++) {
            $rowArray = explode(' ', trim(fgets(STDIN)));

            for ($col = 0; $col < $cols; $col++) {
                $twoDimensionalArray[$row][$col] = $rowArray[$col];
            }
        }

        return $twoDimensionalArray;
    }
}

Engine::run();