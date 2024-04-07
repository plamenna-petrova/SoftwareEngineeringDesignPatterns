import java.util.ArrayList;
import java.util.List;

interface IDepartmentGroupMediator {
    void registerUser(User user);
    void sendAcknowledgement(String message, User user);
    void sendMultipleAcknowledgements(String message, User user);
}

class DepartmentGroupMediator implements IDepartmentGroupMediator {
    private final List<User> usersInDepartmentGroup = new ArrayList<>();

    @Override
    public void registerUser(User user) {
        usersInDepartmentGroup.add(user);
    }

    @Override
    public void sendAcknowledgement(String message, User user) {
        user.receiveAcknowledgement(message, user);
    }

    @Override
    public void sendMultipleAcknowledgements(String message, User user) {
        for (User userInDepartmentGroup : usersInDepartmentGroup) {
            if (userInDepartmentGroup.getDepartment().equals(user.getDepartment()) && !userInDepartmentGroup.isExaminer()) {
                userInDepartmentGroup.receiveAcknowledgement(message, userInDepartmentGroup);
            }
        }
    }
}

abstract class User {
    protected IDepartmentGroupMediator departmentGroupMediator;
    private final String name;
    private final String department;
    private final boolean isExaminer;

    public User(IDepartmentGroupMediator departmentGroupMediator, String name, String department, boolean isExaminer) {
        this.departmentGroupMediator = departmentGroupMediator;
        this.name = name;
        this.department = department;
        this.isExaminer = isExaminer;
    }

    public String getName() {
        return name;
    }

    public String getDepartment() {
        return department;
    }

    public boolean isExaminer() {
        return isExaminer;
    }

    public abstract void sendAcknowledgement(String message, User user);
    public abstract void sendNoticeToStudents(String message, User user);
    public abstract void receiveAcknowledgement(String message, User user);
    public abstract void registerSubjects(String[] subjects, User user);
}

class SchoolMember extends User {
    public SchoolMember(IDepartmentGroupMediator departmentGroupMediator, String name, String department, boolean isExaminer) {
        super(departmentGroupMediator, name, department, isExaminer);
    }

    @Override
    public void receiveAcknowledgement(String message, User user) {
        System.out.printf("%s : Received Message: %s%n", user.getName(), message);
    }

    @Override
    public void registerSubjects(String[] subjects, User user) {
        System.out.printf("%s : Submitting Subjects: %d subjects submitted to the department of %s%n", getName(), subjects.length, getDepartment());
        String acknowledgementMessage = String.format("%d subjects submitted by %s and Received by %s", subjects.length, getName(), user.getName());
        departmentGroupMediator.sendAcknowledgement(acknowledgementMessage, user);
    }

    @Override
    public void sendAcknowledgement(String message, User user) {
        System.out.printf("%s : Sending Message : %s%n", getName(), message);
        departmentGroupMediator.sendAcknowledgement(message, user);
    }

    @Override
    public void sendNoticeToStudents(String message, User user) {
        System.out.printf("%s : Sending Message : %s%n", getName(), message);
        departmentGroupMediator.sendMultipleAcknowledgements(message, user);
    }
}

public class Main {
    public static void main(String[] args) {
        IDepartmentGroupMediator departmentMediator = new DepartmentGroupMediator();

        User firstStudent = new SchoolMember(departmentMediator, "Bob", "Information Technologies", false);
        User secondStudent = new SchoolMember(departmentMediator, "Mary", "Mechanics", false);
        User thirdStudent = new SchoolMember(departmentMediator, "Frank", "Mechanics", false);

        User firstExaminer = new SchoolMember(departmentMediator, "Philip", "Information Technologies", true);
        User secondExaminer = new SchoolMember(departmentMediator, "Sarah", "Mechanics", true);

        departmentMediator.registerUser(firstStudent);
        departmentMediator.registerUser(secondStudent);
        departmentMediator.registerUser(thirdStudent);
        departmentMediator.registerUser(firstExaminer);
        departmentMediator.registerUser(secondExaminer);

        firstStudent.sendAcknowledgement("Hello sir, I would like to register my class subjects today", firstExaminer);
        System.out.println();
        secondExaminer.sendNoticeToStudents("June 30th is the deadline to submit all class subjects ", secondExaminer);
        System.out.println();

        firstExaminer.sendAcknowledgement("Go ahead, its about time you did", firstStudent);
        thirdStudent.sendAcknowledgement("Alright. I'll be submitting mine right away", secondExaminer);

        String[] computerSystemsAndTechnologiesSubjects = {"Java", "C#", "Python", "MS SQL"};
        firstStudent.registerSubjects(computerSystemsAndTechnologiesSubjects, firstExaminer);

        String[] mechanicsSubjects = {"English", "CAD", "Mathematics"};
        thirdStudent.registerSubjects(mechanicsSubjects, secondExaminer);
    }
}