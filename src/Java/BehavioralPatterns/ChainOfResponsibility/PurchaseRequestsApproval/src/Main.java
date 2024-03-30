class Purchase {
    private final int number;
    private final double amount;
    private final String purpose;

    public Purchase(int number, double amount, String purpose) {
        this.number = number;
        this.amount = amount;
        this.purpose = purpose;
    }

    public int getNumber() {
        return number;
    }

    public double getAmount() {
        return amount;
    }

    public String getPurpose() {
        return purpose;
    }
}

abstract class Approver {
    protected Approver successor;
    protected final String name;

    public Approver(String name) {
        this.name = name;
    }

    public void setSuccessor(Approver successor) {
        this.successor = successor;
    }

    public String getName() {
        return name;
    }

    public abstract void processRequest(Purchase purchase);
}

class Director extends Approver {
    public Director(String name) {
        super(name);
    }

    @Override
    public void processRequest(Purchase purchase) {
        if (purchase.getAmount() < 10000.0) {
            System.out.println(getName() + " approved request# " + purchase.getNumber());
        } else {
            successor.processRequest(purchase);
        }
    }
}

class VicePresident extends Approver {
    public VicePresident(String name) {
        super(name);
    }

    @Override
    public void processRequest(Purchase purchase) {
        if (purchase.getAmount() < 25000.0) {
            System.out.println(getName() + " approved request# " + purchase.getNumber());
        } else {
            successor.processRequest(purchase);
        }
    }
}

class President extends Approver {
    public President(String name) {
        super(name);
    }

    @Override
    public void processRequest(Purchase purchase) {
        if (purchase.getAmount() < 100000.0) {
            System.out.println(getName() + " approved request# " + purchase.getNumber());
        } else {
            System.out.println("Request# " + purchase.getNumber() + " requires an executive meeting!");
        }
    }
}

public class Main {
    public static void main(String[] args) {
        Approver director = new Director("Larry");
        Approver vicePresident = new VicePresident("Sam");
        Approver president = new President("Tammy");

        director.setSuccessor(vicePresident);
        vicePresident.setSuccessor(president);

        Purchase purchase = new Purchase(2034, 350.00, "Supplies");
        director.processRequest(purchase);

        purchase = new Purchase(2035, 32590.10, "Project X");
        director.processRequest(purchase);

        purchase = new Purchase(2036, 122100.00, "Project Y");
        director.processRequest(purchase);
    }
}