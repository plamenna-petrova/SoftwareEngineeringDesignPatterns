package Commands;

import Models.MenuItem;

import java.util.ArrayList;
import java.util.List;

public class FastFoodOrder {
    private final List<MenuItem> fastFoodOrderMenuItems = new ArrayList<>();

    public void executeCommand(OrderCommand orderCommand, MenuItem menuItem) {
        orderCommand.execute(fastFoodOrderMenuItems, menuItem);
    }

    public void showCurrentItems() {
        for (MenuItem menuItem : fastFoodOrderMenuItems) {
            menuItem.display();
        }
        System.out.println(new String(new char[15]).replace("\0", "-"));
    }
}

