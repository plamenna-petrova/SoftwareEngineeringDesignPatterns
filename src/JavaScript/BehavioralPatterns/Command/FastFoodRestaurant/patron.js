
const FastFoodOrder = require('./commands/fastFoodOrder');
const CommandFactory = require('./commandFactory');

class Patron {
    constructor() {
        this.orderCommand = null;
        this.menuItem = null;
        this.fastFoodOrder = new FastFoodOrder();
    }

    setCommand(commandOption) {
        this.orderCommand = new CommandFactory().getCommand(commandOption);
    }

    setMenuItem(menuItem) {
        this.menuItem = menuItem;
    }

    executeFastFoodOrderCommand() {
        this.fastFoodOrder.executeCommand(this.orderCommand, this.menuItem);
    }

    showCurrentOrder() {
        this.fastFoodOrder.showCurrentItems();
    }
}

module.exports = Patron;