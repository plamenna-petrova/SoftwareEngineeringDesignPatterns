package SalaryCalculator;

import java.util.List;
import java.util.ArrayList;

enum DeveloperLevel {
    Junior,
    Senior
}

class DeveloperReport {
    private int id;
    private String name;
    private DeveloperLevel developerLevel;
    private int workingHours;
    private double hourlyRate;

    public DeveloperReport(int id, String name, DeveloperLevel developerLevel, int workingHours, double hourlyRate) {
        this.id = id;
        this.name = name;
        this.developerLevel = developerLevel;
        this.workingHours = workingHours;
        this.hourlyRate = hourlyRate;
    }

    public double calculateSalary() {
        return workingHours * hourlyRate;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public DeveloperLevel getDeveloperLevel() {
        return developerLevel;
    }

    public int getWorkingHours() {
        return workingHours;
    }

    public double getHourlyRate() {
        return hourlyRate;
    }
}

interface ISalaryCalculatorStrategy {
    double calculateTotalSalary(List<DeveloperReport> developerReports);
}

class JuniorDeveloperSalaryCalculatorStrategy implements ISalaryCalculatorStrategy {
    @Override
    public double calculateTotalSalary(List<DeveloperReport> developerReports) {
        return developerReports.stream()
                .filter(dr -> dr.getDeveloperLevel() == DeveloperLevel.Junior)
                .mapToDouble(DeveloperReport::calculateSalary)
                .sum();
    }
}

class SeniorDeveloperSalaryCalculatorStrategy implements ISalaryCalculatorStrategy {
    @Override
    public double calculateTotalSalary(List<DeveloperReport> developerReports) {
        return developerReports.stream()
                .filter(dr -> dr.getDeveloperLevel() == DeveloperLevel.Senior)
                .mapToDouble(DeveloperReport::calculateSalary)
                .sum();
    }
}

class SalaryCalculatorContext {
    private ISalaryCalculatorStrategy salaryCalculatorStrategy;

    public SalaryCalculatorContext(ISalaryCalculatorStrategy salaryCalculatorStrategy) {
        this.salaryCalculatorStrategy = salaryCalculatorStrategy;
    }

    public void setSalaryCalculatorStrategy(ISalaryCalculatorStrategy salaryCalculatorStrategy) {
        this.salaryCalculatorStrategy = salaryCalculatorStrategy;
    }

    public double calculate(List<DeveloperReport> developerReports) {
        return salaryCalculatorStrategy.calculateTotalSalary(developerReports);
    }
}

public class Main {
    public static void main(String[] args) {
        List<DeveloperReport> developerReports = new ArrayList<>();
        developerReports.add(new DeveloperReport(1, "Developer 1", DeveloperLevel.Senior, 160, 30.5));
        developerReports.add(new DeveloperReport(2, "Developer 2", DeveloperLevel.Junior, 120, 20));
        developerReports.add(new DeveloperReport(3, "Developer 3", DeveloperLevel.Senior, 130, 32.5));
        developerReports.add(new DeveloperReport(4, "Developer 4", DeveloperLevel.Junior, 140, 24.5));

        SalaryCalculatorContext salaryCalculatorContext = new SalaryCalculatorContext(new JuniorDeveloperSalaryCalculatorStrategy());
        double juniorsTotalSalary = salaryCalculatorContext.calculate(developerReports);
        System.out.println("The total amount for the junior salaries is: " + juniorsTotalSalary);

        salaryCalculatorContext.setSalaryCalculatorStrategy(new SeniorDeveloperSalaryCalculatorStrategy());
        double seniorsTotalSalary = salaryCalculatorContext.calculate(developerReports);
        System.out.println("The total amount for the senior salaries is: " + seniorsTotalSalary);

        System.out.println("The total cost for all salaries is: " + (juniorsTotalSalary + seniorsTotalSalary));
    }
}