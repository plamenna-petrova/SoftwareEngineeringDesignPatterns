package Commands;

import Models.MenuItem;

import java.util.Iterator;
import java.util.List;

public class RemoveMenuItemCommand extends OrderCommand {
    @Override
    public void execute(List<MenuItem> fastFoodOrderMenuItems, MenuItem menuItem) {
        Iterator<MenuItem> iterator = fastFoodOrderMenuItems.iterator();
        while (iterator.hasNext()) {
            MenuItem item = iterator.next();
            if (item.getName().equals(menuItem.getName())) {
                iterator.remove();
                break;
            }
        }
    }
}
