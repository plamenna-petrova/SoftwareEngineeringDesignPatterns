import java.util.List;

public class Main {
    public static void main(String[] args) {
        VendingMachine firstVendingMachine = new VendingMachine(List.of(
                new Product("SPCOM1", 1, 3),
                new Product("SPCOM2", 3, 1)
        ));

        firstVendingMachine.selectProduct("SPCOM1");
        firstVendingMachine.insertMoney(1);

        System.out.println("========================== || ==========================");

        VendingMachine secondVendingMachine = new VendingMachine(List.of(
                new Product("SPCOM1", 1, 1),
                new Product("SPCOM2", 3, 1)
        ));

        secondVendingMachine.insertMoney(1);
        secondVendingMachine.selectProduct("SPCOM1");
        secondVendingMachine.insertMoney(0.4);
        secondVendingMachine.insertMoney(1.2);
        secondVendingMachine.selectProduct("SPCOM2");
        secondVendingMachine.insertMoney(3.2);

        secondVendingMachine.refill(List.of(
                new Product("SPCOM1", 1, 3),
                new Product("SPCOM2", 3, 4)
        ));

        secondVendingMachine.selectProduct("SPCOM2");
        secondVendingMachine.insertMoney(5.2);

        System.out.println("========================== || ==========================");

        VendingMachine thirdVendingMachine = new VendingMachine(List.of(
                new Product("SPCOM1", 1, 3),
                new Product("SPCOM2", 3, 1)
        ));

        thirdVendingMachine.selectProduct("SPCOM1");
        thirdVendingMachine.insertMoney(1);
    }
}