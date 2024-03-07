import java.util.ArrayList;
import java.util.List;

abstract class Employee {
    protected String name;
    protected double salary;
    protected String designation;

    public Employee(String name, double salary, String designation) {
        this.name = name;
        this.salary = salary;
        this.designation = designation;
    }

    public abstract void add(Employee employee);

    public abstract void remove(Employee employee);

    public abstract void getHierarchicalLevel(int level);
}

class TeamLead extends Employee {
    private List<Employee> employees = new ArrayList<>();

    public TeamLead(String name, double salary, String designation) {
        super(name, salary, designation);
    }

    @Override
    public void add(Employee employee) {
        employees.add(employee);
    }

    @Override
    public void remove(Employee employee) {
        employees.remove(employee);
    }

    @Override
    public void getHierarchicalLevel(int level) {
        System.out.printf("%s+ %s [%s] [$%.2f]%n", "-".repeat(level), name, designation, salary);

        for (Employee employee : employees) {
            employee.getHierarchicalLevel(level + 2);
        }
    }
}

class Developer extends Employee {
    public Developer(String name, double salary, String designation) {
        super(name, salary, designation);
    }

    @Override
    public void add(Employee employee) {
        System.out.println("Cannot add to a developer");
    }

    @Override
    public void remove(Employee employee) {
        System.out.println("Cannot remove from a developer");
    }

    @Override
    public void getHierarchicalLevel(int indent) {
        System.out.printf("%s %s [%s] [$%.2f]%n", "-".repeat(indent), name, designation, salary);
    }
}

public class Main {
    public static void main(String[] args) {
        TeamLead companyManager = new TeamLead("John", 100000, "Manager");
        companyManager.add(new Developer("Jack", 20000, "Senior .NET Backend Developer"));
        companyManager.add(new Developer("Jim", 25000, "Senior Python Developer"));
        companyManager.add(new Developer("Jacob", 27000, "Senior Frontend Developer"));

        TeamLead groupArchitect = new TeamLead("Joe", 50000, "Group Architect");
        groupArchitect.add(new Developer("James", 15000, "Junior .NET Developer"));
        groupArchitect.add(new Developer("Jason", 12000, "Angular Developer"));
        companyManager.add(groupArchitect);

        Developer developer = new Developer("Jerry", 18000, "Junior Frontend Developer");
        companyManager.add(developer);
        companyManager.remove(developer);

        companyManager.getHierarchicalLevel(1);
    }
}