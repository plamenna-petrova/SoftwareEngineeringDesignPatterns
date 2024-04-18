abstract class HouseTemplate {
    public void buildHouse() {
        buildFoundation();
        buildPillars();
        buildWalls();
        buildWindows();
        System.out.println("The house is built");
    }

    protected abstract void buildFoundation();

    protected abstract void buildPillars();

    protected abstract void buildWalls();

    protected abstract void buildWindows();
}

class ConcreteHouse extends HouseTemplate {
    @Override
    protected void buildFoundation() {
        System.out.println("Building foundation with cement, iron rods and sand");
    }

    @Override
    protected void buildPillars() {
        System.out.println("Building concrete pillars with cement and sand");
    }

    @Override
    protected void buildWalls() {
        System.out.println("Building concrete walls");
    }

    @Override
    protected void buildWindows() {
        System.out.println("Building concrete windows");
    }
}

class WoodenHouse extends HouseTemplate {
    @Override
    protected void buildFoundation() {
        System.out.println("Building foundation with cement, iron rods and sand");
    }

    @Override
    protected void buildPillars() {
        System.out.println("Building wood pillars with wood coating");
    }

    @Override
    protected void buildWalls() {
        System.out.println("Building wood walls");
    }

    @Override
    protected void buildWindows() {
        System.out.println("Building wood windows");
    }
}

public class Main {
    public static void main(String[] args) {
        System.out.println("Building a concrete house\n");

        HouseTemplate houseTemplate = new ConcreteHouse();
        houseTemplate.buildHouse();

        System.out.println("\nBuilding a wooden house\n");

        houseTemplate = new WoodenHouse();
        houseTemplate.buildHouse();
    }
}