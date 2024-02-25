import Abstraction.EraObjectStylesFactory;
import Client.Era;
import ConcreteFactories.ClothingFactory;
import ConcreteFactories.HouseFactory;
import ConcreteFactories.ShipFactory;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        int objectsCount = 1;
        Scanner scanner = new Scanner(System.in);

        System.out.println("Please select your object type number: " + objectsCount);
        System.out.println("[H]House, [S]Ship, [C]Clothing");

        char objectType = scanner.next().charAt(0);

        System.out.println();

        while (objectType != 'E') {
            EraObjectStylesFactory factory = null;

            switch (objectType) {
                case 'H':
                    factory = new HouseFactory();
                    break;
                case 'S':
                    factory = new ShipFactory();
                    break;
                case 'C':
                    factory = new ClothingFactory();
                    break;
            }

            System.out.println("Enter era name: ");
            System.out.println("[M]Medieval, [R]Renaissance, [V]Victorian Era");

            char eraCharacter = scanner.next().charAt(0);

            System.out.println();

            Era era = new Era(factory, eraCharacter);
            System.out.print("Object Number #" + objectsCount + " ");
            era.info();

            System.out.println(new String(new char[50]).replace('\0', '-'));

            System.out.println("Please select your object type: " + ++objectsCount);
            System.out.println("[H]House, [S]Ship, [C]Clothing");

            objectType = scanner.next().charAt(0);

            System.out.println();
        }

        scanner.close();
    }
}