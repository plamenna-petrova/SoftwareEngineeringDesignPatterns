interface ISharedFolder {
    void performReadWriteOperations();
}

class Employee {
    private String username;
    private String password;
    private String role;

    public Employee(String username, String password, String role) {
        this.username = username;
        this.password = password;
        this.role = role;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }
}

class SharedFolder implements ISharedFolder {
    @Override
    public void performReadWriteOperations() {
        System.out.println("Performing Read Write operation on the Shared Folder");
    }
}

class SharedFolderProxy implements ISharedFolder {
    private final Employee employee;

    public SharedFolderProxy(Employee employee) {
        this.employee = employee;
    }

    @Override
    public void performReadWriteOperations() {
        if (employee.getRole().equalsIgnoreCase("CEO") || employee.getRole().equalsIgnoreCase("MANAGER")) {
            ISharedFolder sharedFolder = new SharedFolder();
            System.out.println("Shared Folder Proxy makes call to the RealFolder 'performReadWriteOperations' method");
            sharedFolder.performReadWriteOperations();
        } else {
            System.out.println("Shared Folder proxy says 'You don't have permission to access this folder'");
        }
    }
}

public class Main {
    public static void main(String[] args) {
        System.out.println("Client passing employee with Role Developer to folder proxy");
        Employee firstEmployee = new Employee("john_doe123", "JohnDoe123/", "Developer");
        SharedFolderProxy firstSharedFolderProxy = new SharedFolderProxy(firstEmployee);
        firstSharedFolderProxy.performReadWriteOperations();

        System.out.println();

        System.out.println("Client passing employee with Role Manager to folder proxy");
        Employee secondEmployee = new Employee("jane_doex", "JaneDoeX/", "Manager");
        SharedFolderProxy secondSharedFolderProxy = new SharedFolderProxy(secondEmployee);
        secondSharedFolderProxy.performReadWriteOperations();
    }
}