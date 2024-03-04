import java.util.Date;

class IDInfo {
    public int IDNumber;

    public IDInfo(int idNumber) {
        this.IDNumber = idNumber;
    }
}

abstract class Person implements Cloneable {
    public int Age;
    public Date BirthDate;
    public String Name;
    public IDInfo IDInfo;

    public Person(int age, Date birthDate, String name, IDInfo idInfo) {
        this.Age = age;
        this.BirthDate = birthDate;
        this.Name = name;
        this.IDInfo = idInfo;
    }

    public abstract Person ShallowCopy();

    public abstract Person DeepCopy();
}

class Traveler extends Person {
    public Traveler(int age, Date birthDate, String name, IDInfo idInfo) {
        super(age, birthDate, name, idInfo);
    }

    @Override
    public Person ShallowCopy() {
        try {
            return (Person) super.clone();
        } catch (CloneNotSupportedException cloneNotSupportedException) {
            throw new RuntimeException(cloneNotSupportedException);
        }
    }

    @Override
    public Person DeepCopy() {
        Person clonedPerson = ShallowCopy();
        clonedPerson.IDInfo = new IDInfo(IDInfo.IDNumber);
        return clonedPerson;
    }
}

public class Main {
    public static void main(String[] args) {
        Traveler firstTraveler = new Traveler(42, new Date(77, 0, 1), "Jack Daniels", new IDInfo(666));
        Traveler secondTraveler = (Traveler) firstTraveler.ShallowCopy();
        Traveler thirdTraveler = (Traveler) firstTraveler.DeepCopy();

        System.out.println("Original values of the first, second, and third travelers: ");
        System.out.println("Traveler #1 instance values: ");
        DisplayValues(firstTraveler);
        System.out.println("Traveler #2 instance values: ");
        DisplayValues(secondTraveler);
        System.out.println("Traveler #3 instance values: ");
        DisplayValues(thirdTraveler);

        firstTraveler.Age = 32;
        firstTraveler.BirthDate = new Date(90, 4, 6);
        firstTraveler.Name = "Frank";
        firstTraveler.IDInfo.IDNumber = 7879;

        System.out.println("Values of the first, second, and third travelers after applying changes to the first one: ");
        System.out.println("Traveler #1 instance values: ");
        DisplayValues(firstTraveler);
        System.out.println("Traveler #2 instance values (reference values have changed - shallow copy) :");
        DisplayValues(secondTraveler);
        System.out.println("Traveler #3 instance values (everything was kept the same - deep copy) : ");
        DisplayValues(thirdTraveler);
    }

    private static void DisplayValues(Person person) {
        System.out.printf("%10sName: %s, Age: %d, BirthDate: %tD%n",
                " ", person.Name, person.Age, person.BirthDate);
        System.out.printf("%10sID#: %d%n", " ", person.IDInfo.IDNumber);
    }
}