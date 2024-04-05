package Commands;

import Models.MenuItem;

import java.util.List;

public class ModifyMenuItemCommand extends OrderCommand {
    @Override
    public void execute(List<MenuItem> fastFoodOrderMenuItems, MenuItem menuItem) {
        for (MenuItem item : fastFoodOrderMenuItems) {
            if (item.getName().equals(menuItem.getName())) {
                item.setPrice(menuItem.getPrice());
                item.setAmount(menuItem.getAmount());
                break;
            }
        }
    }
}

