
const OrderCommand = require('./orderCommand');

class RemoveMenuItemCommand extends OrderCommand {
    execute(fastFoodOrderMenuItems, menuItem) {
        const menuItemRemovalIndex = fastFoodOrderMenuItems.findIndex(mi => mi.name === menuItem.name);

        if (menuItemRemovalIndex !== -1) {
            fastFoodOrderMenuItems.splice(menuItemRemovalIndex, 1);
        }
    }
}

module.exports = RemoveMenuItemCommand;
