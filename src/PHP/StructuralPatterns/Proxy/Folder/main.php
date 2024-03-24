<?php

interface ISharedFolder {
    public function performReadWriteOperations();
}

class SharedFolder implements ISharedFolder {
    public function performReadWriteOperations(): void
    {
        echo "Performing Read Write operation on the Shared Folder\n";
    }
}

class Employee {
    private string $username;
    private string $password;
    private string $role;

    public function __construct($username, $password, $role) {
        $this->username = $username;
        $this->password = $password;
        $this->role = $role;
    }

    public function getUsername(): string
    {
        return $this->username;
    }

    public function getPassword(): string
    {
        return $this->password;
    }

    public function getRole(): string
    {
        return $this->role;
    }
}

class SharedFolderProxy implements ISharedFolder {
    private Employee $employee;

    public function __construct($employee) {
        $this->employee = $employee;
    }

    public function performReadWriteOperations(): void
    {
        if (strtoupper($this->employee->getRole()) === "CEO" || strtoupper($this->employee->getRole()) === "MANAGER") {
            $sharedFolder = new SharedFolder();
            echo "Shared Folder Proxy makes call to the RealFolder 'PerformReadWriteOperations method'\n";
            $sharedFolder->performReadWriteOperations();
        } else {
            echo "Shared Folder proxy says 'You don't have permission to access this folder'\n";
        }
    }
}

echo "Client passing employee with Role Developer to folder proxy\n";
$firstEmployee = new Employee("john_doe123", "JohnDoe123/", "Developer");
$firstSharedFolderProxy = new SharedFolderProxy($firstEmployee);
$firstSharedFolderProxy->performReadWriteOperations();

echo "\n";

echo "Client passing employee with Role Manager to folder proxy\n";
$secondEmployee = new Employee("jane_doex", "JaneDoeX/", "Manager");
$secondSharedFolderProxy = new SharedFolderProxy($secondEmployee);
$secondSharedFolderProxy->performReadWriteOperations();
