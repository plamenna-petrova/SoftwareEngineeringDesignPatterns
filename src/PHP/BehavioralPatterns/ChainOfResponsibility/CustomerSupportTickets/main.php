<?php

interface ISupportHandler {
    public function setNextHandler($supportHandler);
    public function distributeTicketHandling($ticket);
}

abstract class BaseSupportHandler implements ISupportHandler {
    private ISupportHandler $nextSupportHandler;

    public function setNextHandler($nextSupportHandler): void
    {
        $this->nextSupportHandler = $nextSupportHandler;
    }

    public function distributeTicketHandling($ticket): void
    {
        if ($this->canHandleTicket($ticket)) {
            $this->handleTicket($ticket);
        } elseif ($this->nextSupportHandler !== null) {
            $this->nextSupportHandler->distributeTicketHandling($ticket);
        } else {
            echo "Ticket cannot be handled\n";
        }
    }

    protected abstract function canHandleTicket($ticket);

    protected abstract function handleTicket($ticket);
}

class FirstLevelSupportHandler extends BaseSupportHandler {
    protected function canHandleTicket($ticket): bool
    {
        return $ticket->severity === Severity::Low;
    }

    protected function handleTicket($ticket): void
    {
        echo "Level 1 Support handles the ticket.\n";
    }
}

class SecondLevelSupportHandler extends BaseSupportHandler {
    protected function canHandleTicket($ticket): bool
    {
        return $ticket->severity === Severity::Medium;
    }

    protected function handleTicket($ticket): void
    {
        echo "Level 2 Support handles the ticket.\n";
    }
}

class ThirdLevelSupportHandler extends BaseSupportHandler {
    protected function canHandleTicket($ticket): bool
    {
        return $ticket->severity === Severity::High;
    }

    protected function handleTicket($ticket): void
    {
        echo "Level 3 Support handles the ticket.\n";
    }
}

class Severity {
    const Low = 'Low';
    const Medium = 'Medium';
    const High = 'High';
}

class Ticket {
    public string $severity;
}

$firstLevelSupportHandler = new FirstLevelSupportHandler();
$secondLevelSupportHandler = new SecondLevelSupportHandler();
$thirdLevelSupportHandler = new ThirdLevelSupportHandler();

$firstLevelSupportHandler->setNextHandler($secondLevelSupportHandler);
$secondLevelSupportHandler->setNextHandler($thirdLevelSupportHandler);

$firstTicket = new Ticket();
$firstTicket->severity = Severity::Low;
$secondTicket = new Ticket();
$secondTicket->severity = Severity::Medium;
$thirdTicket = new Ticket();
$thirdTicket->severity = Severity::High;

$ticketsToHandle = array($firstTicket, $secondTicket, $thirdTicket);

foreach ($ticketsToHandle as $ticketToHandle) {
    $firstLevelSupportHandler->distributeTicketHandling($ticketToHandle);
}