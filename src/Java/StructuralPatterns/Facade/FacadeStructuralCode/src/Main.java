class SubSystemOne {
    public void methodOne() {
        System.out.println(" SubSystemOne Method");
    }
}

class SubSystemTwo {
    public void methodTwo() {
        System.out.println(" SubSystemTwo Method");
    }
}

class SubSystemThree {
    public void methodThree() {
        System.out.println(" SubSystemThree Method");
    }
}

class SubSystemFour {
    public void methodFour() {
        System.out.println(" SubSystemFour Method");
    }
}

class Facade {
    private final SubSystemOne subSystemOne;
    private final SubSystemTwo subSystemTwo;
    private final SubSystemThree subSystemThree;
    private final SubSystemFour subSystemFour;

    public Facade() {
        subSystemOne = new SubSystemOne();
        subSystemTwo = new SubSystemTwo();
        subSystemThree = new SubSystemThree();
        subSystemFour = new SubSystemFour();
    }

    public void methodA() {
        System.out.println("\nMethodA() ---- ");
        subSystemOne.methodOne();
        subSystemTwo.methodTwo();
        subSystemFour.methodFour();
    }

    public void methodB() {
        System.out.println("\nMethodB() ---- ");
        subSystemTwo.methodTwo();
        subSystemThree.methodThree();
    }
}

public class Main {
    public static void main(String[] args) {
        Facade facade = new Facade();

        facade.methodA();
        facade.methodB();
    }
}