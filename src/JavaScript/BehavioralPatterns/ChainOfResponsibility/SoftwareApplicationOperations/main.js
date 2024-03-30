
class Request {
    constructor(content) {
        this.content = content;
    }
}

class IRequestHandler {
    setNextHandler(requestHandler) {
        this.nextRequestHandler = requestHandler;
    }

    handleRequest(request) {
        throw new Error("Method 'handleRequest' must be implemented");
    }
}

class BaseRequestHandler extends IRequestHandler {
    setNextHandler(nextRequestHandler) {
        this.nextRequestHandler = nextRequestHandler;
    }

    handleRequest(request) {
        this.processRequest(request);
        this.nextRequestHandler?.handleRequest(request);
    }

    processRequest(request) {
        throw new Error("Method 'processRequest' must be implemented");
    }
}

class AuthenticationHandler extends BaseRequestHandler {
    processRequest(request) {
        console.log("Authentication handler processing request");
    }
}

class AuthorizationHandler extends BaseRequestHandler {
    processRequest(request) {
        console.log("Authorization handler processing request");
    }
}

class ValidationHandler extends BaseRequestHandler {
    processRequest(request) {
        console.log("Validation handler processing request");
    }
}

const authenticationHandler = new AuthenticationHandler();
const authorizationHandler = new AuthorizationHandler();
const validationHandler = new ValidationHandler();

authenticationHandler.setNextHandler(authorizationHandler);
authorizationHandler.setNextHandler(validationHandler);

const request = new Request("Simple Request");

authenticationHandler.handleRequest(request);