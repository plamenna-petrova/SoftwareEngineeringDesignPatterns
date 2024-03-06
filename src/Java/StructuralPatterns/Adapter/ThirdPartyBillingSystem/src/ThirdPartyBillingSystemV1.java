import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

class EmployeeV1 {
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

    public EmployeeV1() {

    }
}

interface IEmployeesTargetV1 {
    void ProcessCompanySalary(String[][] employeesArray);
}

class EmployeesAdapterV1 implements IEmployeesTargetV1 {
    private final ThirdPartyBillingSystemV1 thirdPartyBillingSystem = new ThirdPartyBillingSystemV1();

    @Override
    public void ProcessCompanySalary(String[][] employeesArray) {
        List<EmployeeV1> adaptedEmployees = new ArrayList<>();

        for (String[] strings : employeesArray) {
            EmployeeV1 employee = new EmployeeV1();

            for (int j = 0; j < strings.length; j++) {
                String employeeDatum = strings[j];

                switch (j) {
                    case 0 -> employee.setID(Integer.parseInt(employeeDatum));
                    case 1 -> employee.setName(employeeDatum);
                    case 2 -> employee.setDesignation(employeeDatum);
                    case 3 -> employee.setSalary(Double.parseDouble(employeeDatum));
                }
            }

            adaptedEmployees.add(employee);
        }

        System.out.println("Adapter converted array of employees to a list of employees");
        System.out.println("Then delegate to the ThirdPartyBillingSystem for processing the employees salary\n");

        thirdPartyBillingSystem.ProcessSalary(adaptedEmployees);
    }
}

class ThirdPartyBillingSystemV1 {
    public void ProcessSalary(List<EmployeeV1> employees) {
        for (EmployeeV1 employee : employees) {
            System.out.println("Salary: " + employee.getSalary() + ", " +
                    "Credited to: " + employee.getName() + " with designation: " + employee.getDesignation());
        }
    }
}

class EngineV1 {
    public static void run() {
        String[][] employees2DDataArray = Fill2DArrayElementsWithRowsAndCols(5, 4);
        System.out.println();

        IEmployeesTargetV1 employeesTarget = new EmployeesAdapterV1();
        System.out.println("HR system passes employee string array to Adapter");
        employeesTarget.ProcessCompanySalary(employees2DDataArray);
    }

    private static String[][] Fill2DArrayElementsWithRowsAndCols(int rows, int cols) {
        Scanner scanner = new Scanner(System.in);
        String[][] twoDimensionalArray = new String[rows][cols];

        for (int row = 0; row < rows; row++) {
            String[] rowArray = scanner.nextLine().split(" ");

            System.arraycopy(rowArray, 0, twoDimensionalArray[row], 0, cols);
        }

        return twoDimensionalArray;
    }
}
