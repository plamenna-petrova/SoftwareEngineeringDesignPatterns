class Customer {
    private String name;

    public Customer(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }
}

class Bank {
    public boolean hasSufficientSavings(Customer customer, int amount) {
        System.out.println("Check bank for " + customer.getName() + " with amount: $" + amount);
        return true;
    }
}

class Credit {
    public boolean hasGoodCredit(Customer customer) {
        System.out.println("Check credit for " + customer.getName());
        return true;
    }
}

class Loan {
    public boolean hasNoBadLoans(Customer customer) {
        System.out.println("Check loans for " + customer.getName());
        return true;
    }
}

class Mortgage {
    private final Bank bank = new Bank();
    private final Loan loan = new Loan();
    private final Credit credit = new Credit();

    public boolean isEligible(Customer customer, int amount) {
        System.out.println(customer.getName() + " applies for $" + amount + " loan\n");

        boolean isEligible = true;

        if (!bank.hasSufficientSavings(customer, amount)) {
            isEligible = false;
        } else if (!loan.hasNoBadLoans(customer)) {
            isEligible = false;
        } else if (!credit.hasGoodCredit(customer)) {
            isEligible = false;
        }

        return isEligible;
    }
}

public class Main {
    public static void main(String[] args) {
        Mortgage mortgage = new Mortgage();

        Customer customer = new Customer("Ann McKinsey");

        boolean isEligibleForMortgage = mortgage.isEligible(customer, 1250000);

        System.out.println("\nCustomer " + customer.getName() + " has been " +
                (isEligibleForMortgage ? "Approved" : "Rejected"));
    }
}