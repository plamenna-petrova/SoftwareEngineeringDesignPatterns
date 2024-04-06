
const AddMenuItemCommand = require('./commands/addMenuItemCommand');
const ModifyMenuItemCommand = require('./commands/modifyMenuItemCommand');
const RemoveMenuItemCommand = require('./commands/removeMenuItemCommand');

class CommandFactory {
    getCommand(commandOption) {
        switch (commandOption) {
            case 1:
                return new AddMenuItemCommand();
            case 2:
                return new ModifyMenuItemCommand();
            case 3:
                return new RemoveMenuItemCommand();
            default:
                return new AddMenuItemCommand();
        }
    }
}

module.exports = CommandFactory;