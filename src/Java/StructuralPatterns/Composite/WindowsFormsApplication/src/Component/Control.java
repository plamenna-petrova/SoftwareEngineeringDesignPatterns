package Component;

import java.awt.Color;
import java.util.List;

public abstract class Control {
    private final String name;
    private final int width;
    private final int height;
    private final Color foreColor;
    private final Color backColor;

    public Control(String name, int width, int height, Color foreColor, Color backColor) {
        this.name = name;
        this.width = width;
        this.height = height;
        this.foreColor = foreColor;
        this.backColor = backColor;
    }

    public String getName() {
        return name;
    }

    public int getWidth() {
        return width;
    }

    public int getHeight() {
        return height;
    }

    public Color getForeColor() {
        return foreColor;
    }

    public Color getBackColor() {
        return backColor;
    }

    public abstract List<Control> getControls();

    public abstract void add(Control control);

    public abstract void remove(Control control);

    public abstract String getHierarchicalLevel(int depthIndicator);
}
