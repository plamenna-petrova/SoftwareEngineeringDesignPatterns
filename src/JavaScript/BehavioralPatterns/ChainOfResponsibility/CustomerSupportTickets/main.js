
const Severity = {
    Low: "Low",
    Medium: "Medium",
    High: "High"
};

class Ticket {
    constructor(severity) {
        this.severity = severity;
    }
}

class ISupportHandler {
    constructor() {
        this.nextHandler = null;
    }

    setNextHandler(handler) {
        this.nextHandler = handler;
    }

    distributeTicketHandling(ticket) {
        throw new Error("Method 'distributeTicketHandling' must be implemented");
    }
}

class BaseSupportHandler extends ISupportHandler {
    distributeTicketHandling(ticket) {
        if (this.canHandleTicket(ticket)) {
            this.handleTicket(ticket);
        } else if (this.nextHandler !== null) {
            this.nextHandler.distributeTicketHandling(ticket);
        } else {
            console.log("Ticket cannot be handled");
        }
    }

    canHandleTicket(ticket) {
        throw new Error("Method 'canHandleTicket' must be implemented");
    }

    handleTicket(ticket) {
        throw new Error("Method 'handleTicket' must be implemented");
    }
}

class FirstLevelSupportHandler extends BaseSupportHandler {
    canHandleTicket(ticket) {
        return ticket.severity === Severity.Low;
    }

    handleTicket(ticket) {
        console.log("Level 1 Support handles the ticket.");
    }
}

class SecondLevelSupportHandler extends BaseSupportHandler {
    canHandleTicket(ticket) {
        return ticket.severity === Severity.Medium;
    }

    handleTicket(ticket) {
        console.log("Level 2 Support handles the ticket.");
    }
}

class ThirdLevelSupportHandler extends BaseSupportHandler {
    canHandleTicket(ticket) {
        return ticket.severity === Severity.High;
    }

    handleTicket(ticket) {
        console.log("Level 3 Support handles the ticket.");
    }
}

const firstLevelSupportHandler = new FirstLevelSupportHandler();
const secondLevelSupportHandler = new SecondLevelSupportHandler();
const thirdLevelSupportHandler = new ThirdLevelSupportHandler();

firstLevelSupportHandler.setNextHandler(secondLevelSupportHandler);
secondLevelSupportHandler.setNextHandler(thirdLevelSupportHandler);

const firstTicket = new Ticket(Severity.Low);
const secondTicket = new Ticket(Severity.Medium);
const thirdTicket = new Ticket(Severity.High);

const ticketsToHandle = [firstTicket, secondTicket, thirdTicket];

ticketsToHandle.forEach(ticketToHandle => {
    firstLevelSupportHandler.distributeTicketHandling(ticketToHandle);
});