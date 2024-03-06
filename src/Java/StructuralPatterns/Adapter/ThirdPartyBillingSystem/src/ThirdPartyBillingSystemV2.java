import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

class EmployeeV2 {
    private int ID;
    private String Name;
    private String Designation;
    private double Salary;

    public int getID() {
        return ID;
    }

    public void setID(int ID) {
        this.ID = ID;
    }

    public String getName() {
        return Name;
    }

    public void setName(String Name) {
        this.Name = Name;
    }

    public String getDesignation() {
        return Designation;
    }

    public void setDesignation(String Designation) {
        this.Designation = Designation;
    }

    public double getSalary() {
        return Salary;
    }

    public void setSalary(double Salary) {
        this.Salary = Salary;
    }

    public EmployeeV2(int ID, String Name, String Designation, double Salary) {
        this.ID = ID;
        this.Name = Name;
        this.Designation = Designation;
        this.Salary = Salary;
    }
}

interface IEmployeesTargetV2 {
    void ProcessCompanySalary(List<EmployeeV2> employees);
}

class EmployeesAdapterV2 implements IEmployeesTargetV2 {
    private ThirdPartyBillingSystemV2 thirdPartyBillingSystem = new ThirdPartyBillingSystemV2();

    @Override
    public void ProcessCompanySalary(List<EmployeeV2> employees) {
        String[][] adaptedEmployeesJaggedArray = employees
                .stream()
                .map(e -> new String[]{String.valueOf(e.getID()), e.getName(), e.getDesignation(), String.valueOf(e.getSalary())})
                .toArray(String[][]::new);

        System.out.println("Adapter converted list of employees to a 2D array");
        System.out.println("Then delegate to the ThirdPartyBillingSystem for processing the employees salary\n");

        thirdPartyBillingSystem.ProcessSalary(adaptedEmployeesJaggedArray);
    }
}

class ThirdPartyBillingSystemV2 {
    public void ProcessSalary(String[][] employeesJaggedArray) {
        for (String[] employeeArray : employeesJaggedArray) {
            System.out.println("Salary: " + employeeArray[3] + ", " +
                    "Credited to: " + employeeArray[1] + " with designation: " + employeeArray[2]);
        }
    }
}

class EngineV2 {
    public static void run() {
        List<EmployeeV2> employeesToProcessCompanySalary = new ArrayList<>();

        Scanner scanner = new Scanner(System.in);
        String employeeCommand = scanner.nextLine();

        while (!employeeCommand.equals("END")) {
            String[] employeeCommands = employeeCommand.split(" ");

            EmployeeV2 employeeToProcessCompanySalary = new EmployeeV2(
                    Integer.parseInt(employeeCommands[0]),
                    employeeCommands[1],
                    employeeCommands[2],
                    Double.parseDouble(employeeCommands[3])
            );

            employeesToProcessCompanySalary.add(employeeToProcessCompanySalary);

            employeeCommand = scanner.nextLine();
        }

        IEmployeesTargetV2 employeesTarget = new EmployeesAdapterV2();
        employeesTarget.ProcessCompanySalary(employeesToProcessCompanySalary);
    }
}