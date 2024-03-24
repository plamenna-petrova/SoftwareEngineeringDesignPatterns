
class Employee {
    constructor(username, password, role) {
        this.username = username;
        this.password = password;
        this.role = role;
    }
}

class ISharedFolder {
    performReadWriteOperations() {}
}

class SharedFolder extends ISharedFolder {
    performReadWriteOperations() {
        console.log("Performing Read Write operation on the Shared Folder");
    }
}

class SharedFolderProxy extends ISharedFolder {
    constructor(employee) {
        super();
        this.sharedFolder = null;
        this.employee = employee;
    }

    performReadWriteOperations() {
        if (this.employee.role.toUpperCase() === "CEO" || this.employee.role.toUpperCase() === "MANAGER") {
            this.sharedFolder = new SharedFolder();
            console.log("Shared Folder Proxy makes call to the RealFolder 'PerformReadWriteOperations method'");
            this.sharedFolder.performReadWriteOperations();
        } else {
            console.log("Shared Folder proxy says 'You don't have permission to access this folder'");
        }
    }
}

console.log("Client passing employee with Role Developer to folder proxy");
const firstEmployee = new Employee("john_doe123", "JohnDoe123/", "Developer");
const firstSharedFolderProxy = new SharedFolderProxy(firstEmployee);
firstSharedFolderProxy.performReadWriteOperations();

console.log();

console.log("Client passing employee with Role Manager to folder proxy");
const secondEmployee = new Employee("jane_doex", "JaneDoeX/", "Manager");
const secondSharedFolderProxy = new SharedFolderProxy(secondEmployee);
secondSharedFolderProxy.performReadWriteOperations();