
class Mediator {
    constructor(requestHandlers) {
        this.requestHandlers = requestHandlers;
    }

    send(request) {
        const requestHandlerType = this.requestHandlers[request.constructor.name];

        if (!requestHandlerType) {
            throw new Error("Handler not found for request type.");
        }
        const requestHandler = new requestHandlerType();
        return requestHandler.execute(request);
    }
}

module.exports = Mediator;