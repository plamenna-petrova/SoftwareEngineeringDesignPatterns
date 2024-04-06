
class OrderCommand {
    execute(fastFoodOrderMenuItems, menuItem) {
        throw new Error('Method must be implemented by subclasses');
    }
}

module.exports = OrderCommand;
