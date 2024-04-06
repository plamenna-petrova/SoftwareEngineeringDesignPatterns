
const OrderCommand = require('./orderCommand');

class AddMenuItemCommand extends OrderCommand {
    execute(fastFoodOrderMenuItems, menuItem) {
        fastFoodOrderMenuItems.push(menuItem);
    }
}

module.exports = AddMenuItemCommand;
