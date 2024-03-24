abstract class Subject {
    abstract void request();
}

class RealSubject extends Subject {
    @Override
    void request() {
        System.out.println("Called RealSubject.Request()");
    }
}

class Proxy extends Subject {
    private RealSubject realSubject;

    @Override
    void request() {
        if (realSubject == null) {
            realSubject = new RealSubject();
        }
        realSubject.request();
    }
}

public class Main {
    public static void main(String[] args) {
        Proxy proxy = new Proxy();
        proxy.request();
    }
}