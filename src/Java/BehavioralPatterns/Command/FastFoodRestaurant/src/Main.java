import Models.MenuItem;

public class Main {
    public static void main(String[] args) {
        Patron patron = new Patron();

        patron.setCommand(1);
        patron.setMenuItem(new MenuItem("French Fries", 2, 1.99));
        patron.executeFastFoodOrderCommand();

        patron.setCommand(1);
        patron.setMenuItem(new MenuItem("Hamburger", 2, 2.59));
        patron.executeFastFoodOrderCommand();

        patron.setCommand(1);
        patron.setMenuItem(new MenuItem("Drink", 2, 1.20));
        patron.executeFastFoodOrderCommand();

        patron.showCurrentOrder();

        patron.setCommand(3);
        patron.setMenuItem(new MenuItem("French Fries", 2, 1.99));
        patron.executeFastFoodOrderCommand();

        patron.showCurrentOrder();

        patron.setCommand(2);
        patron.setMenuItem(new MenuItem("Hamburger", 4, 2.59));
        patron.executeFastFoodOrderCommand();

        patron.showCurrentOrder();
    }
}