package Composites;

import Component.Control;

import java.awt.Color;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public abstract class BaseControlComposite extends Control {
    private List<Control> controls = new ArrayList<>();

    public BaseControlComposite(String name, int width, int height, Color foreColor, Color backColor) {
        super(name, width, height, foreColor, backColor);
    }

    @Override
    public List<Control> getControls() {
        return controls;
    }

    @Override
    public void add(Control control) {
        controls.add(control);
    }

    @Override
    public void remove(Control control) {
        controls.remove(control);
    }

    @Override
    public String getHierarchicalLevel(int depthIndicator) {
        StringBuilder compositeHierarchicalInfo = new StringBuilder(
                String.format("%s+ Name: %s, Width: %d, Fore Color: (%d, %d, %d), Back Color: (%d, %d, %d)\r\n",
                        new String(new char[depthIndicator]).replace('\0', '-'),
                        getName(), getWidth(),
                        getForeColor().getRed(), getForeColor().getGreen(), getForeColor().getBlue(),
                        getBackColor().getRed(), getBackColor().getGreen(), getBackColor().getBlue()
                )
        );

        for (Control control : controls) {
            compositeHierarchicalInfo.append(control.getHierarchicalLevel(depthIndicator + 2));
        }

        return compositeHierarchicalInfo.toString();
    }
}
