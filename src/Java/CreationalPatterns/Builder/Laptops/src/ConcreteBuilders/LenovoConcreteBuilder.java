package ConcreteBuilders;

import Builder.LaptopBuilder;
import Product.Laptop;

import java.util.Scanner;

public class LenovoConcreteBuilder extends LaptopBuilder {
    private Scanner scanner;

    public LenovoConcreteBuilder() {
        laptop = new Laptop();
        scanner = new Scanner(System.in);
    }

    @Override
    public void setModel() {
        System.out.print("Enter Laptop Model: ");
        laptop.setModel(scanner.nextLine());
    }

    @Override
    public void setCPUSeries() {
        System.out.print("Enter CPU Series: ");
        laptop.setCPUSeries(scanner.nextLine());
    }

    @Override
    public void setGPUModel() {
        System.out.print("Enter GPU Model: ");
        laptop.setGPUModel(scanner.nextLine());
    }

    @Override
    public void setRAMType() {
        System.out.print("Enter RAM Type: ");
        laptop.setRAMType(scanner.nextLine());
    }

    @Override
    public void setRAMSize() {
        System.out.print("Enter RAM Size: ");
        laptop.setRAMSize(Integer.parseInt(scanner.nextLine()));
    }

    @Override
    public void setDisplayType() {
        System.out.print("Enter Display Type: ");
        laptop.setDisplayType(scanner.nextLine());
    }

    @Override
    public void setSSDType() {
        System.out.print("Enter SSD Type: ");
        laptop.setSSDType(scanner.nextLine());
    }

    @Override
    public void setSSDCapacity() {
        System.out.print("Enter SSD Capacity: ");
        laptop.setSSDCapacity(Integer.parseInt(scanner.nextLine()));
    }

    @Override
    public void setExtras() {
        System.out.print("Add extra item (Exit with END): ");
        String extraItem = scanner.nextLine();

        while (!extraItem.equals("END")) {
            laptop.getExtras().add(extraItem);
            System.out.print("Add extra item (Exit with END): ");
            extraItem = scanner.nextLine();
        }
    }
}
