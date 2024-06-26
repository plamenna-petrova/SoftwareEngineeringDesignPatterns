package Models;

public class MenuItem {
    private String name;
    private int amount;
    private double price;

    public MenuItem(String name, int amount, double price) {
        this.name = name;
        this.amount = amount;
        this.price = price;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getAmount() {
        return amount;
    }

    public void setAmount(int amount) {
        this.amount = amount;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public void display() {
        System.out.println("\nName: " + name);
        System.out.println("Amount: " + amount);
        System.out.println("Price: $" + price);
    }
}