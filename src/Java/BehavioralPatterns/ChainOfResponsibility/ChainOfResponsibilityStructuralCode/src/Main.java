abstract class Handler {
    protected Handler successor;

    public void setSuccessor(Handler successor) {
        this.successor = successor;
    }

    public abstract void handleRequest(int request);
}

class FirstConcreteHandler extends Handler {
    @Override
    public void handleRequest(int request) {
        if (request >= 0 && request < 10) {
            System.out.println(getClass().getSimpleName() + " handled request " + request);
        } else if (successor != null) {
            successor.handleRequest(request);
        }
    }
}

class SecondConcreteHandler extends Handler {
    @Override
    public void handleRequest(int request) {
        if (request >= 10 && request < 20) {
            System.out.println(getClass().getSimpleName() + " handled request " + request);
        } else if (successor != null) {
            successor.handleRequest(request);
        }
    }
}

class ThirdConcreteHandler extends Handler {
    @Override
    public void handleRequest(int request) {
        if (request >= 20 && request < 30) {
            System.out.println(getClass().getSimpleName() + " handled request " + request);
        } else if (successor != null) {
            successor.handleRequest(request);
        }
    }
}

public class Main {
    public static void main(String[] args) {
        Handler firstConcreteHandler = new FirstConcreteHandler();
        Handler secondConcreteHandler = new SecondConcreteHandler();
        Handler thirdConcreteHandler = new ThirdConcreteHandler();

        firstConcreteHandler.setSuccessor(secondConcreteHandler);
        secondConcreteHandler.setSuccessor(thirdConcreteHandler);

        int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

        for (int request : requests) {
            firstConcreteHandler.handleRequest(request);
        }
    }
}