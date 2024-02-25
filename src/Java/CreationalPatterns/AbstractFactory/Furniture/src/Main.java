import ConcreteFactories.ClassicFurnitureFactory;
import ConcreteFactories.ContemporaryFurnitureFactory;
import ConcreteFactories.ScandinavianFurnitureFactory;
import Interfaces.IFurniture;
import Interfaces.IFurnitureFactory;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Please select your furniture style:");
        System.out.println("[1]Classic, [2]Contemporary, [3]Scandinavian");

        if (scanner.hasNextInt()) {
            int furnitureStyle = scanner.nextInt();
            IFurnitureFactory furnitureFactory = null;

            switch (furnitureStyle) {
                case 1:
                    furnitureFactory = new ClassicFurnitureFactory();
                    break;
                case 2:
                    furnitureFactory = new ContemporaryFurnitureFactory();
                    break;
                case 3:
                    furnitureFactory = new ScandinavianFurnitureFactory();
                    break;
            }

            System.out.println("Please select your furniture type:");
            System.out.println("[1]Cabinet, [2]Chair, [3]Dining Table");

            if (scanner.hasNextInt()) {
                int furnitureType = scanner.nextInt();
                IFurniture furniture = null;

                switch (furnitureType) {
                    case 1:
                        furniture = furnitureFactory.createCabinet();
                        break;
                    case 2:
                        furniture = furnitureFactory.createChair();
                        break;
                    case 3:
                        furniture = furnitureFactory.createDiningTable();
                        break;
                }

                if (furniture != null) {
                    furniture.showFurnitureStyle();
                }
            }
        }

        scanner.close();
    }
}