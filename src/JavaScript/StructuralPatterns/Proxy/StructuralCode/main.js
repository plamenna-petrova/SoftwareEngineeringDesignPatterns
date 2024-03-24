
class Subject {
    request() { }
}

class RealSubject extends Subject {
    request() {
        console.log("Called RealSubject.Request()");
    }
}

class Proxy extends Subject {
    constructor() {
        super();
        this.realSubject = null;
    }

    request() {
        if (!this.realSubject) {
            this.realSubject = new RealSubject();
        }
        this.realSubject.request();
    }
}

const proxy = new Proxy();
proxy.request();