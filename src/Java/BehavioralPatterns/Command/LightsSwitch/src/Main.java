import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

class Light {
    public void turnOn() {
        System.out.println("The light is on");
    }

    public void turnOff() {
        System.out.println("The light is off");
    }
}

interface ICommand {
    void execute();
}

class FlipUpCommand implements ICommand {
    private final Light light;

    public FlipUpCommand(Light light) {
        this.light = light;
    }

    @Override
    public void execute() {
        light.turnOn();
    }
}

class FlipDownCommand implements ICommand {
    private final Light light;

    public FlipDownCommand(Light light) {
        this.light = light;
    }

    @Override
    public void execute() {
        light.turnOff();
    }
}

class Switch {
    private final List<ICommand> commands = new ArrayList<>();

    public void storeAndExecute(ICommand command) {
        commands.add(command);
        command.execute();
    }
}

public class Main {
    public static void main(String[] args) {
        System.out.println("Enter commands (ON/OFF) : ");

        Scanner scanner = new Scanner(System.in);
        String command = scanner.nextLine();

        Light lamp = new Light();

        ICommand switchUp = new FlipUpCommand(lamp);
        ICommand switchDown = new FlipDownCommand(lamp);

        Switch switchObject = new Switch();

        if (command.equals("ON")) {
            switchObject.storeAndExecute(switchUp);
        } else if (command.equals("OFF")) {
            switchObject.storeAndExecute(switchDown);
        } else {
            System.out.println("Command \"ON\" or \"OFF\" is required.");
        }

        scanner.close();
    }
}