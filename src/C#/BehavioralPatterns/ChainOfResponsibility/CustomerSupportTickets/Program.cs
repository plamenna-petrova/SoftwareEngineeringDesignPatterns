using System;
using System.Collections.Generic;

namespace CustomerSupportTickets
{
    public enum Severity
    {
        Low,
        Medium,
        High
    }

    public class Ticket
    {
        public Severity Severity;
    }

    public interface ISupportHandler
    {
        void SetNextHandler(ISupportHandler supportHandler);

        void DistributeTicketHandling(Ticket ticket);
    }

    public abstract class BaseSupportHandler : ISupportHandler
    {
        private ISupportHandler nextSupportHandler;

        public void SetNextHandler(ISupportHandler nextSupportHandler)
        {
            this.nextSupportHandler = nextSupportHandler;
        }

        public virtual void DistributeTicketHandling(Ticket ticket)
        {
            if (CanHandleTicket(ticket))
            {
                HandleTicket(ticket);
            }
            else if (nextSupportHandler != null)
            {
                nextSupportHandler.DistributeTicketHandling(ticket);
            }
            else
            {
                Console.WriteLine("Ticket cannot be handled");
            }
        }

        protected abstract bool CanHandleTicket(Ticket ticket);

        protected abstract void HandleTicket(Ticket ticket);
    }

    public class FirstLevelSupportHandler : BaseSupportHandler
    {
        protected override bool CanHandleTicket(Ticket ticket) => ticket.Severity == Severity.Low;

        protected override void HandleTicket(Ticket ticket)
        {
            Console.WriteLine("Level 1 Support handles the ticket.");
        }
    }

    public class SecondLevelSupportHandler : BaseSupportHandler
    {
        protected override bool CanHandleTicket(Ticket ticket) => ticket.Severity == Severity.Medium;

        protected override void HandleTicket(Ticket ticket)
        {
            Console.WriteLine("Level 2 Support handles the ticket.");
        }
    }

    public class ThirdLevelSupportHandler : BaseSupportHandler
    {
        protected override bool CanHandleTicket(Ticket ticket) => ticket.Severity == Severity.High;

        protected override void HandleTicket(Ticket ticket)
        {
            Console.WriteLine("Level 3 Support handles the ticket.");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            FirstLevelSupportHandler firstLevelSupportHandler = new FirstLevelSupportHandler();
            SecondLevelSupportHandler secondLevelSupportHandler = new SecondLevelSupportHandler();
            ThirdLevelSupportHandler thirdLevelSupportHandler = new ThirdLevelSupportHandler();

            firstLevelSupportHandler.SetNextHandler(secondLevelSupportHandler);
            secondLevelSupportHandler.SetNextHandler(thirdLevelSupportHandler);

            Ticket firstTicket = new Ticket { Severity = Severity.Low };
            Ticket secondTicket = new Ticket { Severity = Severity.Medium };
            Ticket thirdTicket = new Ticket { Severity = Severity.High };

            List<Ticket> ticketsToHandle = new List<Ticket>() { firstTicket, secondTicket, thirdTicket };

            foreach (var ticketToHandle in ticketsToHandle)
            {
                firstLevelSupportHandler.DistributeTicketHandling(ticketToHandle);
            }
        }
    }
}
