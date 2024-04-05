import Commands.AddMenuItemCommand;
import Commands.ModifyMenuItemCommand;
import Commands.OrderCommand;
import Commands.RemoveMenuItemCommand;

public class CommandFactory {
    public OrderCommand getCommand(int commandOption) {
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

