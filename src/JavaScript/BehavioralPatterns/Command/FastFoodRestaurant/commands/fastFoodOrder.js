
const MenuItem = require('../models/menuItem');

class FastFoodOrder {
    constructor() {
        this.fastFoodOrderMenuItems = [];
    }

    executeCommand(orderCommand, menuItem) {
        orderCommand.execute(this.fastFoodOrderMenuItems, menuItem);
    }

    showCurrentItems() {
        this.fastFoodOrderMenuItems.forEach(fastFoodOrderMenuItem => {
            fastFoodOrderMenuItem.display();
        });

        console.log('-'.repeat(15));
    }
}

module.exports = FastFoodOrder;