class ToyCarMemento {
    private final String color;

    public ToyCarMemento(String color) {
        this.color = color;
    }

    public String getColor() {
        return color;
    }
}

class ToyCar {
    private String color;

    public String getColor() {
        return color;
    }

    public void setColor(String color) {
        this.color = color;
        System.out.println("Car color changed to " + color);
    }

    public ToyCarMemento saveState() {
        return new ToyCarMemento(color);
    }

    public void restoreState(ToyCarMemento toyCarMemento) {
        setColor(toyCarMemento.getColor());
    }
}

class ColorChanger {
    private ToyCarMemento toyCarMemento;

    public void changeColor(ToyCar toyCar, String color) {
        toyCarMemento = toyCar.saveState();
        toyCar.setColor(color);
    }

    public void undoColorChange(ToyCar toyCar) {
        toyCar.restoreState(toyCarMemento);
    }
}

public class Main {
    public static void main(String[] args) {
        ToyCar toyCar = new ToyCar();
        ColorChanger colorChanger = new ColorChanger();

        colorChanger.changeColor(toyCar, "Red");

        ToyCarMemento savedState = toyCar.saveState();
        colorChanger.changeColor(toyCar, "Blue");
        colorChanger.changeColor(toyCar, "Green");

        colorChanger.undoColorChange(toyCar);
        System.out.println("Current car color: " + toyCar.getColor());

        toyCar.restoreState(savedState);
        System.out.println("Restored car color: " + toyCar.getColor());
    }
}