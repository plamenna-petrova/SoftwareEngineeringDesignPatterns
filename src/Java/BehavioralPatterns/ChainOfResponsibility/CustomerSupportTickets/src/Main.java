import java.util.ArrayList;
import java.util.List;

enum Severity {
    Low,
    Medium,
    High
}

class Ticket {
    public Severity severity;
}

interface ISupportHandler {
    void setNextHandler(ISupportHandler supportHandler);

    void distributeTicketHandling(Ticket ticket);
}

abstract class BaseSupportHandler implements ISupportHandler {
    private ISupportHandler nextSupportHandler;

    public void setNextHandler(ISupportHandler nextSupportHandler) {
        this.nextSupportHandler = nextSupportHandler;
    }

    public void distributeTicketHandling(Ticket ticket) {
        if (canHandleTicket(ticket)) {
            handleTicket(ticket);
        } else if (nextSupportHandler != null) {
            nextSupportHandler.distributeTicketHandling(ticket);
        } else {
            System.out.println("Ticket cannot be handled");
        }
    }

    protected abstract boolean canHandleTicket(Ticket ticket);

    protected abstract void handleTicket(Ticket ticket);
}

class FirstLevelSupportHandler extends BaseSupportHandler {
    protected boolean canHandleTicket(Ticket ticket) {
        return ticket.severity == Severity.Low;
    }

    protected void handleTicket(Ticket ticket) {
        System.out.println("Level 1 Support handles the ticket.");
    }
}

class SecondLevelSupportHandler extends BaseSupportHandler {
    protected boolean canHandleTicket(Ticket ticket) {
        return ticket.severity == Severity.Medium;
    }

    protected void handleTicket(Ticket ticket) {
        System.out.println("Level 2 Support handles the ticket.");
    }
}

class ThirdLevelSupportHandler extends BaseSupportHandler {
    protected boolean canHandleTicket(Ticket ticket) {
        return ticket.severity == Severity.High;
    }

    protected void handleTicket(Ticket ticket) {
        System.out.println("Level 3 Support handles the ticket.");
    }
}

public class Main {
    public static void main(String[] args) {
        FirstLevelSupportHandler firstLevelSupportHandler = new FirstLevelSupportHandler();
        SecondLevelSupportHandler secondLevelSupportHandler = new SecondLevelSupportHandler();
        ThirdLevelSupportHandler thirdLevelSupportHandler = new ThirdLevelSupportHandler();

        firstLevelSupportHandler.setNextHandler(secondLevelSupportHandler);
        secondLevelSupportHandler.setNextHandler(thirdLevelSupportHandler);

        Ticket firstTicket = new Ticket();
        firstTicket.severity = Severity.Low;
        Ticket secondTicket = new Ticket();
        secondTicket.severity = Severity.Medium;
        Ticket thirdTicket = new Ticket();
        thirdTicket.severity = Severity.High;

        List<Ticket> ticketsToHandle = new ArrayList<>();
        ticketsToHandle.add(firstTicket);
        ticketsToHandle.add(secondTicket);
        ticketsToHandle.add(thirdTicket);

        for (Ticket ticketToHandle : ticketsToHandle) {
            firstLevelSupportHandler.distributeTicketHandling(ticketToHandle);
        }
    }
}