
class LaptopStore {
    buildLaptopConfiguration(laptopBuilder) {
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

module.exports = LaptopStore;