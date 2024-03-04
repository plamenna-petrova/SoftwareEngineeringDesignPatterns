class Singleton {

    private static Singleton instance;

    private Singleton() {

    }

    public static Singleton getInstance() {
        if (instance == null) {
            instance = new Singleton();
        }

        return instance;
    }
}

public class Main {
    public static void main(String[] args) {
        Singleton firstSingletonInstance = Singleton.getInstance();
        Singleton secondSingletonInstance = Singleton.getInstance();

        if (firstSingletonInstance == secondSingletonInstance) {
            System.out.println("The objects share the same instance");
        }
    }
}
