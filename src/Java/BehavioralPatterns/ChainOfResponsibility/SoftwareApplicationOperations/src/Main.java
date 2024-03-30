class Request {
    private String content;

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }
}

interface IRequestHandler {
    void setNextHandler(IRequestHandler requestHandler);

    void handleRequest(Request request);
}

abstract class BaseRequestHandler implements IRequestHandler {
    private IRequestHandler nextRequestHandler;

    public void setNextHandler(IRequestHandler nextRequestHandler) {
        this.nextRequestHandler = nextRequestHandler;
    }

    public void handleRequest(Request request) {
        processRequest(request);

        if (nextRequestHandler != null) {
            nextRequestHandler.handleRequest(request);
        }
    }

    protected abstract void processRequest(Request request);
}

class AuthenticationHandler extends BaseRequestHandler {
    @Override
    protected void processRequest(Request request) {
        System.out.println("Authentication handler processing request");
    }
}

class AuthorizationHandler extends BaseRequestHandler {
    @Override
    protected void processRequest(Request request) {
        System.out.println("Authorization handler processing request");
    }
}

class ValidationHandler extends BaseRequestHandler {
    @Override
    protected void processRequest(Request request) {
        System.out.println("Validation handler processing request");
    }
}

public class Main {
    public static void main(String[] args) {
        AuthenticationHandler authenticationHandler = new AuthenticationHandler();
        AuthorizationHandler authorizationHandler = new AuthorizationHandler();
        ValidationHandler validationHandler = new ValidationHandler();

        authenticationHandler.setNextHandler(authorizationHandler);
        authorizationHandler.setNextHandler(validationHandler);

        Request request = new Request();
        request.setContent("Simple Request");

        authenticationHandler.handleRequest(request);
    }
}