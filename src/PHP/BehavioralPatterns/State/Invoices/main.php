<?php

interface IInvoiceState {
    public function pay(Invoice $invoice);
    public function cancel(Invoice $invoice);
    public function refund(Invoice $invoice);
}

class Invoice {
    private int $number;
    private float $amount;
    private string $description;
    private IInvoiceState $state;

    public function __construct(int $number, float $amount, string $description) {
        $this->number = $number;
        $this->amount = $amount;
        $this->description = $description;
        $this->state = new UnpaidState();
    }

    public function pay(): void {
        $this->state->pay($this);
        $this->state = new PaidState();
    }

    public function cancel(): void {
        $this->state->cancel($this);
        $this->state = new CanceledState();
    }

    public function refund(): void {
        $this->state->refund($this);
        $this->state = new RefundedState();
    }

    public function getNumber(): int {
        return $this->number;
    }

    public function getAmount(): float {
        return $this->amount;
    }

    public function getDescription(): string {
        return $this->description;
    }
}

class UnpaidState implements IInvoiceState {
    public function pay(Invoice $invoice): void {
        echo "Paying invoice {$invoice->getNumber()}...\n";
    }

    public function cancel(Invoice $invoice): void {
        echo "Cancelling invoice {$invoice->getNumber()}...\n";
    }

    public function refund(Invoice $invoice): void {
        echo "Invoice {$invoice->getNumber()} is unpaid and cannot be refunded.\n";
    }
}

class PaidState implements IInvoiceState {
    public function pay(Invoice $invoice): void {
        echo "Invoice {$invoice->getNumber()} has already been paid.\n";
    }

    public function cancel(Invoice $invoice): void {
        echo "Invoice {$invoice->getNumber()} cannot be cancelled.\n";
    }

    public function refund(Invoice $invoice): void {
        echo "Invoice {$invoice->getNumber()} has been refunded.\n";
    }
}

class CanceledState implements IInvoiceState {
    public function pay(Invoice $invoice): void {
        echo "Invoice {$invoice->getNumber()} has been cancelled and cannot be paid.\n";
    }

    public function cancel(Invoice $invoice): void {
        echo "Invoice {$invoice->getNumber()} has been cancelled and cannot be cancelled again.\n";
    }

    public function refund(Invoice $invoice): void {
        echo "Invoice {$invoice->getNumber()} has been cancelled and cannot be refunded.\n";
    }
}

class RefundedState implements IInvoiceState {
    public function pay(Invoice $invoice): void {
        echo "Invoice {$invoice->getNumber()} was refunded and cannot be paid.\n";
    }

    public function cancel(Invoice $invoice): void {
        echo "Invoice {$invoice->getNumber()} was refunded and cannot be cancelled.\n";
    }

    public function refund(Invoice $invoice): void {
        echo "Invoice {$invoice->getNumber()} was refunded and cannot be refunded again.\n";
    }
}

$invoice = new Invoice(123, 1000.0, "Software Devs Services");

$invoice->pay();
$invoice->refund();
