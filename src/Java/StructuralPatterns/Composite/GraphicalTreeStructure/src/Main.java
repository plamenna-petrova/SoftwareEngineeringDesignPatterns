import java.util.ArrayList;
import java.util.List;

abstract class DrawingElement {
    protected String name;

    public DrawingElement(String name) {
        this.name = name;
    }

    public abstract void add(DrawingElement drawingElement);

    public abstract void remove(DrawingElement drawingElement);

    public abstract void display(int indent);
}

class CompositeElement extends DrawingElement {
    private final List<DrawingElement> drawingElements = new ArrayList<>();

    public CompositeElement(String name) {
        super(name);
    }

    @Override
    public void add(DrawingElement drawingElement) {
        drawingElements.add(drawingElement);
    }

    @Override
    public void remove(DrawingElement drawingElement) {
        drawingElements.remove(drawingElement);
    }

    @Override
    public void display(int indent) {
        System.out.println("-".repeat(indent) + "+ " + name);

        for (DrawingElement drawingElement : drawingElements) {
            drawingElement.display(indent + 2);
        }
    }
}

class PrimitiveElement extends DrawingElement {
    public PrimitiveElement(String name) {
        super(name);
    }

    @Override
    public void add(DrawingElement drawingElement) {
        System.out.println("Cannot add to a primitive element");
    }

    @Override
    public void remove(DrawingElement drawingElement) {
        System.out.println("Cannot remove from a primitive element");
    }

    @Override
    public void display(int indent) {
        System.out.println("-".repeat(indent) + " " + name);
    }
}

public class Main {
    public static void main(String[] args) {
        CompositeElement canvas = new CompositeElement("Canvas");
        canvas.add(new PrimitiveElement("Red Line"));
        canvas.add(new PrimitiveElement("Blue Circle"));
        canvas.add(new PrimitiveElement("Green Box"));

        CompositeElement compositeElement = new CompositeElement("Two Circles");
        compositeElement.add(new PrimitiveElement("Black Circle"));
        compositeElement.add(new PrimitiveElement("White Circle"));
        canvas.add(compositeElement);

        PrimitiveElement primitiveElement = new PrimitiveElement("Orange Line");
        canvas.add(primitiveElement);
        canvas.remove(primitiveElement);

        canvas.display(1);
    }
}