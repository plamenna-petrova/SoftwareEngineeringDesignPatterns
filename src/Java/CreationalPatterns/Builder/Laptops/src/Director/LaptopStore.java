package Director;

import Builder.LaptopBuilder;

public class LaptopStore {
    public void buildLaptopConfiguration(LaptopBuilder laptopBuilder) {
        laptopBuilder.setModel();
        laptopBuilder.setCPUSeries();
        laptopBuilder.setGPUModel();
        laptopBuilder.setRAMType();
        laptopBuilder.setRAMSize();
        laptopBuilder.setDisplayType();
        laptopBuilder.setSSDType();
        laptopBuilder.setSSDCapacity();
        laptopBuilder.setExtras();
    }
}
