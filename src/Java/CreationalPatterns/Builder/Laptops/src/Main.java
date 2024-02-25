import Builder.LaptopBuilder;
import ConcreteBuilders.ASUSConcreteBuilder;
import ConcreteBuilders.LenovoConcreteBuilder;
import Director.LaptopStore;

public class Main {
    public static void main(String[] args) {
        LaptopStore laptopStore = new LaptopStore();

        LaptopBuilder laptopBuilder = new ASUSConcreteBuilder();
        laptopStore.buildLaptopConfiguration(laptopBuilder);
        laptopBuilder.getLaptop().showDetails();

        laptopBuilder = new LenovoConcreteBuilder();
        laptopStore.buildLaptopConfiguration(laptopBuilder);
        laptopBuilder.getLaptop().showDetails();
    }
}