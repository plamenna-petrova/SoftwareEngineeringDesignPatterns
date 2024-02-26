const ASUSConcreteBuilder = require("./ConcreteBuilders/asusConcreteBuilder");
const LenovoConcreteBuilder = require("./ConcreteBuilders/lenovoConcreteBuilder");
const LaptopStore = require("./Director/laptopStore");

const laptopStore = new LaptopStore();

const asusBuilder = new ASUSConcreteBuilder();
laptopStore.buildLaptopConfiguration(asusBuilder);
const asusLaptop = asusBuilder.getLaptop();
asusLaptop.showDetails();

const lenovoBuilder = new LenovoConcreteBuilder();
laptopStore.buildLaptopConfiguration(lenovoBuilder);
const lenovoLaptop = lenovoBuilder.getLaptop();
lenovoLaptop.showDetails();