
const OrderCommand = require('./orderCommand');

class ModifyMenuItemCommand extends OrderCommand {
    execute(fastFoodOrderMenuItems, menuItem) {
        const menuItemToModify = fastFoodOrderMenuItems.find(mi => mi.name === menuItem.name);

        if (menuItemToModify) {
            menuItemToModify.price = menuItem.price;
            menuItemToModify.amount = menuItem.amount;
        }
    }
}

module.exports = ModifyMenuItemCommand;