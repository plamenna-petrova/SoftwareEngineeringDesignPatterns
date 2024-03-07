import java.util.ArrayList;
import java.util.List;

interface IComponent {
    void displayPrice();
}

class Part implements IComponent {
    private final String name;
    private final double price;

    public Part(String name, double price) {
        this.name = name;
        this.price = price;
    }

    @Override
    public void displayPrice() {
        System.out.println(name + " : " + price);
    }
}

class Composite implements IComponent {
    private final List<IComponent> components = new ArrayList<>();
    private final String name;

    public Composite(String name) {
        this.name = name;
    }

    public void addComponent(IComponent component) {
        components.add(component);
    }

    @Override
    public void displayPrice() {
        System.out.println(name);

        for (IComponent component : components) {
            component.displayPrice();
        }
    }
}

public class Main {
    public static void main(String[] args) {
        IComponent hardDisk = new Part("Hard Disk", 2000);
        IComponent ram = new Part("RAM", 3000);
        IComponent cpu = new Part("CPU", 2000);
        IComponent mouse = new Part("Mouse", 2000);
        IComponent keyboard = new Part("Keyboard", 2000);

        Composite motherBoard = new Composite("Mother Board");
        Composite cabinet = new Composite("Cabinet");
        Composite peripherals = new Composite("Peripherals");
        Composite computer = new Composite("Computer");

        motherBoard.addComponent(cpu);
        motherBoard.addComponent(ram);

        cabinet.addComponent(motherBoard);
        cabinet.addComponent(hardDisk);

        peripherals.addComponent(mouse);
        peripherals.addComponent(keyboard);

        computer.addComponent(cabinet);
        computer.addComponent(peripherals);

        computer.displayPrice();
        System.out.println();

        keyboard.displayPrice();
        System.out.println();

        cabinet.displayPrice();
    }
}