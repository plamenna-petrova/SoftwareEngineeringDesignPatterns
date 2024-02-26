
class LaptopBuilder {
    constructor() {
        this.laptop = null;
    }

    set model(value) {
        this.laptop.model = value;
    }

    set cpuSeries(value) {
        this.laptop.cpuSeries = value;
    }

    set gpuModel(value) {
        this.laptop.gpuModel = value;
    }

    set ramType(value) {
        this.laptop.ramType = value;
    }

    set ramSize(value) {
        this.laptop.ramSize = value;
    }

    set displayType(value) {
        this.laptop.displayType = value;
    }

    set ssdType(value) {
        this.laptop.ssdType = value;
    }

    set ssdCapacity(value) {
        this.laptop.ssdCapacity = value;
    }

    setExtras(extras) {
        this.laptop.extras = extras;
    }

    build() {
        return this.laptop;
    }
}

module.exports = LaptopBuilder;