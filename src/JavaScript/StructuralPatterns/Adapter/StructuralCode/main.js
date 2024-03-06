
class Target {
    executeRequest() {
        console.log("Called Target executeRequest()");
    }
}

class Adapter extends Target {
    constructor() {
        super();
        this.adaptee = new Adaptee();
    }

    executeRequest() {
        this.adaptee.executeSpecificRequest();
    }
}

class Adaptee {
    executeSpecificRequest() {
        console.log("Called executeSpecificRequest()");
    }
}

const target = new Adapter();
target.executeRequest();