
class Handler {
    setSuccessor(successor) {
        this.successor = successor;
    }

    handleRequest(request) {
        throw new Error("Method 'handleRequest' must be implemented");
    }
}

class FirstConcreteHandler extends Handler {
    handleRequest(request) {
        if (request >= 0 && request < 10) {
            console.log(`${this.constructor.name} handled request ${request}`);
        } else {
            this.successor?.handleRequest(request);
        }
    }
}

class SecondConcreteHandler extends Handler {
    handleRequest(request) {
        if (request >= 10 && request < 20) {
            console.log(`${this.constructor.name} handled request ${request}`);
        } else {
            this.successor?.handleRequest(request);
        }
    }
}

class ThirdConcreteHandler extends Handler {
    handleRequest(request) {
        if (request >= 20 && request < 30) {
            console.log(`${this.constructor.name} handled request ${request}`);
        } else {
            this.successor?.handleRequest(request);
        }
    }
}

const firstConcreteHandler = new FirstConcreteHandler();
const secondConcreteHandler = new SecondConcreteHandler();
const thirdConcreteHandler = new ThirdConcreteHandler();

firstConcreteHandler.setSuccessor(secondConcreteHandler);
secondConcreteHandler.setSuccessor(thirdConcreteHandler);

const requests = [2, 5, 14, 22, 18, 3, 27, 20];

requests.forEach(request => {
    firstConcreteHandler.handleRequest(request);
});