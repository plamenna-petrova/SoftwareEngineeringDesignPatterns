import Commands.FastFoodOrder;
import Commands.OrderCommand;
import Models.MenuItem;

public class Patron {
    private OrderCommand orderCommand;
    private MenuItem menuItem;
    private final FastFoodOrder fastFoodOrder;

    public Patron() {
        fastFoodOrder = new FastFoodOrder();
    }

    public void setCommand(int commandOption) {
        orderCommand = new CommandFactory().getCommand(commandOption);
    }

    public void setMenuItem(MenuItem menuItem) {
        this.menuItem = menuItem;
    }

    public void executeFastFoodOrderCommand() {
        fastFoodOrder.executeCommand(orderCommand, menuItem);
    }

    public void showCurrentOrder() {
        fastFoodOrder.showCurrentItems();
    }
}

