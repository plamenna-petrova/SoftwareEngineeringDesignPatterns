
class IServer {
    takeOrder(order) {}
    deliverOrder() {}
    processPayment(payment) {}
}

class Server extends IServer {
    constructor() {
        super();
        this.order = '';
    }

    takeOrder(order) {
        console.log(`Server takes order for ${order}.`);
        this.order = order;
    }

    deliverOrder() {
        return this.order;
    }

    processPayment(payment) {
        console.log(`Payment for order (${payment}) processed.`);
    }
}

class ServerProxy extends IServer {
    constructor() {
        super();
        this.order = '';
        this.server = new Server();
    }

    takeOrder(order) {
        console.log(`New trainee server takes order for ${order}.`);
        this.order = order;
    }

    deliverOrder() {
        return this.order;
    }

    processPayment(payment) {
        console.log("New trainee cannot process payments yet!");
        this.server.processPayment(payment);
    }
}

const serverProxy = new ServerProxy();
serverProxy.takeOrder("Order #1");
serverProxy.processPayment("via Credit Card");
console.log(`${serverProxy.deliverOrder()} delivered successfully.`);
