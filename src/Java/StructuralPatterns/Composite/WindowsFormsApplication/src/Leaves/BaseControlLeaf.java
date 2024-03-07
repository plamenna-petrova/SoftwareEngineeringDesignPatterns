package Leaves;

import Component.Control;

import java.awt.Color;
import java.util.Collections;
import java.util.List;

public abstract class BaseControlLeaf extends Control {
    public BaseControlLeaf(String name, int width, int height, Color foreColor, Color backColor) {
        super(name, width, height, foreColor, backColor);
    }

    @Override
    public final List<Control> getControls() {
        return null;
    }

    @Override
    public final void add(Control control) {
        System.out.println("Cannot add control to " + getClass().getSimpleName());
    }

    @Override
    public final void remove(Control control) {
        System.out.println("Cannot remove control from " + getClass().getSimpleName());
    }

    @Override
    public String getHierarchicalLevel(int depthIndicator) {
        return String.format("%s+ Name: %s, Width: %d, Fore Color: (%d, %d, %d), Back Color: (%d, %d, %d)\r\n",
                "-".repeat(depthIndicator), getName(), getWidth(), getForeColor().getRed(), getForeColor().getGreen(), getForeColor().getBlue(),
                getBackColor().getRed(), getBackColor().getGreen(), getBackColor().getBlue());
    }
}
