package Commands;

import Models.MenuItem;

import java.util.List;

public class AddMenuItemCommand extends OrderCommand {
    @Override
    public void execute(List<MenuItem> fastFoodOrderMenuItems, MenuItem menuItem) {
        fastFoodOrderMenuItems.add(menuItem);
    }
}

