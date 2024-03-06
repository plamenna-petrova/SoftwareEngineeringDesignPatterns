class Target {
    public void executeRequest() {
        System.out.println("Called Target executeRequest()");
    }
}

class Adapter extends Target {
    private Adaptee adaptee = new Adaptee();

    @Override
    public void executeRequest() {
        adaptee.executeSpecificRequest();
    }
}

class Adaptee {
    public void executeSpecificRequest() {
        System.out.println("Called executeSpecificRequest()");
    }

}

public class Main {
    public static void main(String[] args) {
        Target target = new Adapter();
        target.executeRequest();
    }
}