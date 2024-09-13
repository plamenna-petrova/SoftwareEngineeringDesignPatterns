import java.util.ArrayList;
import java.util.List;

interface IElement {
    void accept(IVisitor visitor);
}

class Kid implements IElement {
    private String name;

    public Kid(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public void accept(IVisitor visitor) {
        visitor.visit(this);
    }
}

interface IVisitor {
    void visit(IElement element);
}

class Doctor implements IVisitor {
    private String name;

    public Doctor(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public void visit(IElement element) {
        if (element instanceof Kid) {
            Kid kid = (Kid) element;
            System.out.println("Doctor: " + name + " did the health checkup of the child: " + kid.getName());
        }
    }
}

class Teacher implements IVisitor {
    private String name;

    public Teacher(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public void visit(IElement element) {
        if (element instanceof Kid) {
            Kid kid = (Kid) element;
            System.out.println("Teacher: " + name + " assessed the daily work of the child: " + kid.getName());
        }
    }
}

class School {
    private static final List<IElement> elements;

    static {
        elements = new ArrayList<>();
        elements.add(new Kid("John"));
        elements.add(new Kid("Sarah"));
        elements.add(new Kid("Kim"));
    }

    public void performOperation(IVisitor visitor) {
        for (IElement kid : elements) {
            kid.accept(visitor);
        }
    }
}

public class Main {
    public static void main(String[] args) {
        School school = new School();

        IVisitor doctor = new Doctor("James");
        school.performOperation(doctor);
        System.out.println();

        IVisitor teacher = new Teacher("Mr. Smith");
        school.performOperation(teacher);
    }
}