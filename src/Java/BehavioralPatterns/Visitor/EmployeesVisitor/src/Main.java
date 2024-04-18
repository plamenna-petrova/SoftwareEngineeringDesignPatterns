import java.util.ArrayList;
import java.util.List;

interface IVisitor {
    void visit(Element element);
}

class IncomeVisitor implements IVisitor {
    @Override
    public void visit(Element element) {
        Employee employee = (Employee) element;
        employee.setIncome(employee.getIncome() * 1.10);
        System.out.printf("%s %s's new income: $%.2f%n", employee.getClass().getSimpleName(), employee.getName(), employee.getIncome());
    }
}

class VacationVisitor implements IVisitor {
    @Override
    public void visit(Element element) {
        Employee employee = (Employee) element;
        employee.setVacationDays(employee.getVacationDays() + 3);
        System.out.printf("%s %s's new vacation days: %d%n", employee.getClass().getSimpleName(), employee.getName(), employee.getVacationDays());
    }
}

abstract class Element {
    public abstract void accept(IVisitor visitor);
}

class Employee extends Element {
    private final String name;
    private double income;
    private int vacationDays;

    public Employee(String name, double income, int vacationDays) {
        this.name = name;
        this.income = income;
        this.vacationDays = vacationDays;
    }

    public String getName() {
        return name;
    }

    public double getIncome() {
        return income;
    }

    public void setIncome(double income) {
        this.income = income;
    }

    public int getVacationDays() {
        return vacationDays;
    }

    public void setVacationDays(int vacationDays) {
        this.vacationDays = vacationDays;
    }

    @Override
    public void accept(IVisitor visitor) {
        visitor.visit(this);
    }
}

class Clerk extends Employee {
    public Clerk() {
        super("Kevin", 25000.0, 14);
    }
}

class Director extends Employee {
    public Director() {
        super("Elly", 35000.0, 16);
    }
}

class President extends Employee {
    public President() {
        super("Eric", 45000.0, 21);
    }
}

class Employees {
    private final List<Employee> employees = new ArrayList<>();

    public void attach(Employee employee) {
        employees.add(employee);
    }

    public void detach(Employee employee) {
        employees.remove(employee);
    }

    public void accept(IVisitor visitor) {
        for (Employee employee : employees) {
            employee.accept(visitor);
        }
        System.out.println();
    }
}

public class Main {
    public static void main(String[] args) {
        Employees employees = new Employees();

        employees.attach(new Clerk());
        employees.attach(new Director());
        employees.attach(new President());

        employees.accept(new IncomeVisitor());
        employees.accept(new VacationVisitor());
    }
}