
class IDepartmentGroupMediator {
    registerUser(user) {
        throw new Error("Method 'registerUser' must be implemented.");
    }

    sendAcknowledgement(message, user) {
        throw new Error("Method 'sendAcknowledgement' must be implemented.");
    }

    sendMultipleAcknowledgements(message, user) {
        throw new Error("Method 'sendMultipleAcknowledgements' must be implemented.");
    }
}

class DepartmentGroupMediator extends IDepartmentGroupMediator {
    constructor() {
        super();
        this.usersInDepartmentGroup = [];
    }

    registerUser(user) {
        this.usersInDepartmentGroup.push(user);
    }

    sendAcknowledgement(message, user) {
        user.receiveAcknowledgement(message, user);
    }

    sendMultipleAcknowledgements(message, user) {
        for (let userInDepartmentGroup of this.usersInDepartmentGroup) {
            if (userInDepartmentGroup.department === user.department && !userInDepartmentGroup.isExaminer) {
                userInDepartmentGroup.receiveAcknowledgement(message, userInDepartmentGroup);
            }
        }
    }
}

class User {
    constructor(departmentGroupMediator, name, department, isExaminer) {
        this.departmentGroupMediator = departmentGroupMediator;
        this.name = name;
        this.department = department;
        this.isExaminer = isExaminer;
    }

    sendAcknowledgement(message, user) {
        this.departmentGroupMediator.sendAcknowledgement(message, user);
    }

    sendNoticeToStudents(message, user) {
        this.departmentGroupMediator.sendMultipleAcknowledgements(message, user);
    }

    receiveAcknowledgement(message, user) {
        console.log(`${user.name} : Received Message: ${message}`);
    }

    registerSubjects(subjects, user) {
        console.log(`${this.name} : Submitting Subjects: ${subjects.length} subjects submitted to the department of ${this.department} \n`);
        let acknowledgementMessage = `${subjects.length} subjects submitted by ${this.name} and Received by ${user.name}`;
        this.departmentGroupMediator.sendAcknowledgement(acknowledgementMessage, user);
    }
}

class SchoolMember extends User {
    constructor(departmentGroupMediator, name, department, isExaminer) {
        super(departmentGroupMediator, name, department, isExaminer);
    }
}

const departmentMediator = new DepartmentGroupMediator();

const firstStudent = new SchoolMember(departmentMediator, "Bob", "Information Technologies", false);
const secondStudent = new SchoolMember(departmentMediator, "Mary", "Mechanics", false);
const thirdStudent = new SchoolMember(departmentMediator, "Frank", "Mechanics", false);

const firstExaminer = new SchoolMember(departmentMediator, "Philip", "Information Technologies", true);
const secondExaminer = new SchoolMember(departmentMediator, "Sarah", "Mechanics", true);

departmentMediator.registerUser(firstStudent);
departmentMediator.registerUser(secondStudent);
departmentMediator.registerUser(thirdStudent);
departmentMediator.registerUser(firstExaminer);
departmentMediator.registerUser(secondExaminer);

firstStudent.sendAcknowledgement("Hello sir, I would like to register my class subjects today", firstExaminer);
console.log();
secondExaminer.sendNoticeToStudents("June 30th is the deadline to submit all class subjects ", secondExaminer);
console.log();

firstExaminer.sendAcknowledgement("Go ahead, its about time you did", firstStudent);
thirdStudent.sendAcknowledgement("Alright. I'll be submitting mine right away", secondExaminer);

const computerSystemsAndTechnologiesSubjects = ["Java", "C#", "Python", "MS SQL"];
firstStudent.registerSubjects(computerSystemsAndTechnologiesSubjects, firstExaminer);

const mechanicsSubjects = ["English", "CAD", "Mathematics"];
thirdStudent.registerSubjects(mechanicsSubjects, secondExaminer);  