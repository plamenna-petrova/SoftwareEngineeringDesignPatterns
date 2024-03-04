abstract class Employee implements Cloneable {
    public String Name;
    public String Department;
    public Address Address;

    public Employee(String name, String department, Address address) {
        this.Name = name;
        this.Department = department;
        this.Address = address;
    }

    public abstract Employee GetShallowCopy();

    public abstract Employee GetDeepCopy();

    public void GetDetails() {
        System.out.printf("Employee Details: Name - %s, Department - %s, Address - %s%n",
                Name, Department, Address.Name);
    }

    @Override
    protected Object clone() throws CloneNotSupportedException {
        return super.clone();
    }
}

class SoftwareDeveloper extends Employee {
    public SoftwareDeveloper(String name, String department, Address address) {
        super(name, department, address);
    }

    @Override
    public Employee GetShallowCopy() {
        try {
            return (Employee) super.clone();
        } catch (CloneNotSupportedException cloneNotSupportedException) {
            throw new RuntimeException(cloneNotSupportedException);
        }
    }

    @Override
    public Employee GetDeepCopy() {
        Employee clonedEmployee = GetShallowCopy();
        clonedEmployee.Address = Address.GetClone();
        return clonedEmployee;
    }
}

class Address implements Cloneable {
    public String Name;

    public Address(String name) {
        this.Name = name;
    }

    public Address GetClone() {
        try {
            return (Address) super.clone();
        } catch (CloneNotSupportedException e) {
            throw new RuntimeException(e);
        }
    }
}

public class Main {
    public static void main(String[] args) {
        SoftwareDeveloper firstSoftwareDeveloper = new SoftwareDeveloper("John", "IT", new Address("London, UK"));
        SoftwareDeveloper secondSoftwareDeveloper = (SoftwareDeveloper) firstSoftwareDeveloper.GetShallowCopy();
        SoftwareDeveloper thirdSoftwareDeveloper = (SoftwareDeveloper) firstSoftwareDeveloper.GetDeepCopy();

        System.out.println("Original values: \r\n");

        firstSoftwareDeveloper.GetDetails();
        secondSoftwareDeveloper.GetDetails();
        thirdSoftwareDeveloper.GetDetails();

        System.out.println();

        secondSoftwareDeveloper.Name = "James";
        secondSoftwareDeveloper.Address.Name = "New York, USA";

        thirdSoftwareDeveloper.Address.Name = "Barcelona, Spain";

        System.out.println("After applying changes: \r\n");

        firstSoftwareDeveloper.GetDetails();
        secondSoftwareDeveloper.GetDetails();
        thirdSoftwareDeveloper.GetDetails();
    }
}