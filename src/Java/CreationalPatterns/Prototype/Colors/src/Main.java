import java.util.HashMap;

abstract class ColorPrototype implements Cloneable {
    @Override
    public ColorPrototype clone() {
        try {
            return (ColorPrototype) super.clone();
        } catch (CloneNotSupportedException cloneNotSupportedException) {
            throw new RuntimeException(cloneNotSupportedException);
        }
    }
}

class ColorConcretePrototype extends ColorPrototype {
    private final int red;
    private final int green;
    private final int blue;

    public ColorConcretePrototype(int red, int green, int blue) {
        this.red = red;
        this.green = green;
        this.blue = blue;
    }

    @Override
    public String toString() {
        return String.format("Cloned color RGB: %3d,%3d,%3d", red, green, blue);
    }
}

class ColorManager {
    private final HashMap<String, ColorPrototype> colors = new HashMap<>();

    public ColorPrototype getColor(String key) {
        return colors.get(key).clone();
    }

    public void setColor(String key, ColorPrototype color) {
        colors.put(key, color);
    }
}

class Program {
    public static void main(String[] args) {
        ColorManager colorManager = new ColorManager();

        colorManager.setColor("red", new ColorConcretePrototype(255, 0, 0));
        colorManager.setColor("green", new ColorConcretePrototype(0, 255, 0));
        colorManager.setColor("blue", new ColorConcretePrototype(0, 0, 255));

        colorManager.setColor("angry", new ColorConcretePrototype(255, 54, 0));
        colorManager.setColor("peace", new ColorConcretePrototype(128, 211, 128));
        colorManager.setColor("flame", new ColorConcretePrototype(211, 34, 20));

        ColorConcretePrototype redColor = (ColorConcretePrototype) colorManager.getColor("red");
        ColorConcretePrototype peaceColor = (ColorConcretePrototype) colorManager.getColor("peace");
        ColorConcretePrototype flameColor = (ColorConcretePrototype) colorManager.getColor("flame");

        System.out.println(redColor.toString());
        System.out.println(peaceColor.toString());
        System.out.println(flameColor.toString());
    }
}