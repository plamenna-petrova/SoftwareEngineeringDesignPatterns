package Commands;

import Models.MenuItem;

import java.util.List;

public abstract class OrderCommand {
    public abstract void execute(List<MenuItem> fastFoodOrderMenuItems, MenuItem menuItem);
}
