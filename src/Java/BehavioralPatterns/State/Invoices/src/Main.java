interface InvoiceState {
    void pay(Invoice invoice);

    void cancel(Invoice invoice);

    void refund(Invoice invoice);
}

class Invoice {
    private final int number;
    private final double amount;
    private final String description;
    private InvoiceState state;

    public Invoice(int number, double amount, String description) {
        this.number = number;
        this.amount = amount;
        this.description = description;
        this.state = new UnpaidState();
    }

    public int getNumber() {
        return number;
    }

    public double getAmount() {
        return amount;
    }

    public String getDescription() {
        return description;
    }

    public void setState(InvoiceState state) {
        this.state = state;
    }

    public void pay() {
        state.pay(this);
        setState(new PaidState());
    }

    public void cancel() {
        state.cancel(this);
        setState(new CanceledState());
    }

    public void refund() {
        state.refund(this);
        setState(new RefundedState());
    }
}

class UnpaidState implements InvoiceState {
    @Override
    public void pay(Invoice invoice) {
        System.out.println("Paying invoice " + invoice.getNumber() + "...");
    }

    @Override
    public void cancel(Invoice invoice) {
        System.out.println("Cancelling invoice " + invoice.getNumber() + "...");
    }

    @Override
    public void refund(Invoice invoice) {
        System.out.println("Invoice " + invoice.getNumber() + " is unpaid and cannot be refunded.");
    }
}

class PaidState implements InvoiceState {
    @Override
    public void pay(Invoice invoice) {
        System.out.println("Invoice " + invoice.getNumber() + " has already been paid.");
    }

    @Override
    public void cancel(Invoice invoice) {
        System.out.println("Invoice " + invoice.getNumber() + " cannot be cancelled.");
    }

    @Override
    public void refund(Invoice invoice) {
        System.out.println("Invoice " + invoice.getNumber() + " has been refunded.");
    }
}

class CanceledState implements InvoiceState {
    @Override
    public void pay(Invoice invoice) {
        System.out.println("Invoice " + invoice.getNumber() + " has been cancelled and cannot be paid.");
    }

    @Override
    public void cancel(Invoice invoice) {
        System.out.println("Invoice " + invoice.getNumber() + " has been cancelled and cannot be cancelled again.");
    }

    @Override
    public void refund(Invoice invoice) {
        System.out.println("Invoice " + invoice.getNumber() + " has been cancelled and cannot be refunded.");
    }
}

class RefundedState implements InvoiceState {
    @Override
    public void pay(Invoice invoice) {
        System.out.println("Invoice " + invoice.getNumber() + " was refunded and cannot be paid.");
    }

    @Override
    public void cancel(Invoice invoice) {
        System.out.println("Invoice " + invoice.getNumber() + " was refunded and cannot be cancelled.");
    }

    @Override
    public void refund(Invoice invoice) {
        System.out.println("Invoice " + invoice.getNumber() + " was refunded and cannot be refunded again.");
    }
}

public class Main {
    public static void main(String[] args) {
        Invoice invoice = new Invoice(123, 1000.0, "Software Devs Services");

        invoice.pay();
        invoice.refund();
    }
}