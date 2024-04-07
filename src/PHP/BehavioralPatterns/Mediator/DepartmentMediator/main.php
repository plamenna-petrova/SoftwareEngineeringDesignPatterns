<?php

interface IDepartmentGroupMediator {
    public function registerUser($user);
    public function sendAcknowledgement($message, $user);
    public function sendMultipleAcknowledgements($message, $user);
}

class DepartmentGroupMediator implements IDepartmentGroupMediator {
    private array $usersInDepartmentGroup = [];

    public function registerUser($user): void
    {
        $this->usersInDepartmentGroup[] = $user;
    }

    public function sendAcknowledgement($message, $user): void
    {
        $user->receiveAcknowledgement($message, $user);
    }

    public function sendMultipleAcknowledgements($message, $user): void
    {
        foreach ($this->usersInDepartmentGroup as $userInDepartmentGroup) {
            if ($userInDepartmentGroup->getDepartment() == $user->getDepartment() && !$userInDepartmentGroup->getIsExaminer()) {
                $userInDepartmentGroup->receiveAcknowledgement($message, $userInDepartmentGroup);
            }
        }
    }
}

abstract class User {
    protected DepartmentGroupMediator $departmentGroupMediator;

    protected string $name;
    protected string $department;
    protected bool $isExaminer;

    public function __construct($departmentGroupMediator, $name, $department, $isExaminer) {
        $this->departmentGroupMediator = $departmentGroupMediator;
        $this->name = $name;
        $this->department = $department;
        $this->isExaminer = $isExaminer;
    }

    public function getName(): string
    {
        return $this->name;
    }

    public function getDepartment(): string
    {
        return $this->department;
    }

    public function getIsExaminer(): bool
    {
        return $this->isExaminer;
    }

    abstract public function sendAcknowledgement($message, $user);
    abstract public function sendNoticeToStudents($message, $user);
    abstract public function receiveAcknowledgement($message, $user);
    abstract public function registerSubjects($subjects, $user);
}

class SchoolMember extends User {
    public function __construct($departmentGroupMediator, $name, $department, $isExaminer) {
        parent::__construct($departmentGroupMediator, $name, $department, $isExaminer);
    }

    public function receiveAcknowledgement($message, $user): void
    {
        echo "{$user->getName()} : Received Message: {$message}\n";
    }

    public function registerSubjects($subjects, $user): void
    {
        echo "{$this->getName()} : Submitting Subjects: " . count($subjects) . " subjects submitted to the department of {$this->getDepartment()}\n";
        $acknowledgementMessage = count($subjects) . " subjects submitted by {$this->getName()} and Received by {$user->getName()}";
        $this->departmentGroupMediator->sendAcknowledgement($acknowledgementMessage, $user);
    }

    public function sendAcknowledgement($message, $user): void
    {
        echo "{$this->getName()} : Sending Message : {$message}\n";
        $this->departmentGroupMediator->sendAcknowledgement($message, $user);
    }

    public function sendNoticeToStudents($message, $user): void
    {
        echo "{$this->getName()} : Sending Message : {$message}\n";
        $this->departmentGroupMediator->sendMultipleAcknowledgements($message, $user);
    }
}

$departmentMediator = new DepartmentGroupMediator();

$firstStudent = new SchoolMember($departmentMediator, "Bob", "Information Technologies", false);
$secondStudent = new SchoolMember($departmentMediator, "Mary", "Mechanics", false);
$thirdStudent = new SchoolMember($departmentMediator, "Frank", "Mechanics", false);

$firstExaminer = new SchoolMember($departmentMediator, "Philip", "Information Technologies", true);
$secondExaminer = new SchoolMember($departmentMediator, "Sarah", "Mechanics", true);

$departmentMediator->registerUser($firstStudent);
$departmentMediator->registerUser($secondStudent);
$departmentMediator->registerUser($thirdStudent);
$departmentMediator->registerUser($firstExaminer);
$departmentMediator->registerUser($secondExaminer);

$firstStudent->sendAcknowledgement("Hello sir, I would like to register my class subjects today", $firstExaminer);
echo "\n";
$secondExaminer->sendNoticeToStudents("June 30th is the deadline to submit all class subjects ", $secondExaminer);
echo "\n";

$firstExaminer->sendAcknowledgement("Go ahead, its about time you did", $firstStudent);
$thirdStudent->sendAcknowledgement("Alright. I'll be submitting mine right away", $secondExaminer);

$computerSystemsAndTechnologiesSubjects = ["Java", "C#", "Python", "MS SQL"];
$firstStudent->registerSubjects($computerSystemsAndTechnologiesSubjects, $firstExaminer);

$mechanicsSubjects = ["English", "CAD", "Mathematics"];
$thirdStudent->registerSubjects($mechanicsSubjects, $secondExaminer);