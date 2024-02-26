const LaptopBuilder = require("../Builder/laptopBuilder");
const Laptop = require("../Product/laptop");

const prompt = require('prompt-sync')();

class ASUSConcreteBuilder extends LaptopBuilder {
    constructor() {
        super();
        this.laptop = new Laptop();
    }

    getLaptop() {
        return this.laptop;
    }

    setModel() {
        const model = prompt("Enter Laptop Model: ");
        this.laptop.model = model;
    }

    setCPUSeries() {
        const cpuSeries = prompt("Enter CPU Series: ");
        this.laptop.cpuSeries = cpuSeries;
    }

    setGPUModel() {
        const gpuModel = prompt("Enter GPU Model: ");
        this.laptop.gpuModel = gpuModel;
    }

    setRAMType() {
        const ramType = prompt("Enter RAM Type: ");
        this.laptop.ramType = ramType;
    }

    setRAMSize() {
        const ramSize = parseFloat(prompt("Enter RAM Size: "));
        this.laptop.ramSize = ramSize;
    }

    setDisplayType() {
        const displayType = prompt("Enter Display Type: ");
        this.laptop.displayType = displayType;
    }

    setSSDType() {
        const ssdType = prompt("Enter SSD Type: ");
        this.laptop.ssdType = ssdType;
    }

    setSSDCapacity() {
        const ssdCapacity = parseFloat(prompt("Enter SSD Capacity: "));
        this.laptop.ssdCapacity = ssdCapacity;
    }

    setExtras() {
        let extraItem = prompt("Add extra item (Exit with END): ");

        while (extraItem !== "END") {
            this.laptop.extras.push(extraItem);
            extraItem = prompt("Add extra item (Exit with END): ");
        }
    }
}

module.exports = ASUSConcreteBuilder;