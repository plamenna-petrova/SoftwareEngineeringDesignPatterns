import java.util.HashMap;
import java.util.Map;

interface Shape {
    void draw();
}

class Circle implements Shape {
    private String color;

    public void setColor(String color) {
        this.color = color;
    }

    public void draw() {
        int xCoordinate = 10;
        int yCoordinate = 20;
        int radius = 30;

        System.out.println("Circle: draw() [Color: " + color + ", X Coordinate: " + xCoordinate + ", Y Coordinate: " + yCoordinate + ", Radius: " + radius + "]");
    }
}

class ShapeFactory {
    private static final Map<String, Shape> shapes = new HashMap<>();

    public static Shape getShape(String shapeType) {
        Shape shape = null;

        if (shapeType.equalsIgnoreCase("circle")) {
            if (!shapes.containsKey("circle")) {
                shape = new Circle();
                shapes.put("circle", shape);
                System.out.println("Creating circle object without any color in shape factory\n");
            }
        }

        return shapes.get("circle");
    }
}

public class Main {
    public static void main(String[] args) {
        System.out.println("\nRed color Circles");

        for (int i = 0; i < 3; i++) {
            Circle circle = (Circle) ShapeFactory.getShape("circle");
            circle.setColor("Red");
            circle.draw();
        }

        System.out.println("\nGreen color Circles");

        for (int i = 0; i < 3; i++) {
            Circle circle = (Circle) ShapeFactory.getShape("circle");
            circle.setColor("Green");
            circle.draw();
        }

        System.out.println("\nBlue color Circles");

        for (int i = 0; i < 3; ++i) {
            Circle circle = (Circle) ShapeFactory.getShape("circle");
            circle.setColor("Blue");
            circle.draw();
        }

        System.out.println("\nOrange color Circles");

        for (int i = 0; i < 3; ++i) {
            Circle circle = (Circle) ShapeFactory.getShape("circle");
            circle.setColor("Orange");
            circle.draw();
        }

        System.out.println("\nBlack color Circles");

        for (int i = 0; i < 3; ++i) {
            Circle circle = (Circle) ShapeFactory.getShape("circle");
            circle.setColor("Black");
            circle.draw();
        }
    }
}