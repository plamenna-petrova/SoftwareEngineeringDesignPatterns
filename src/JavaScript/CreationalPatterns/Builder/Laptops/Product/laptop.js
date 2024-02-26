
class Laptop {
    constructor() {
        this.model = '';
        this.cpuSeries = '';
        this.gpuModel = '';
        this.ramType = '';
        this.ramSize = 0;
        this.displayType = '';
        this.ssdType = '';
        this.ssdCapacity = 0;
        this.extras = [];
    }

    showDetails() {
        const separator = '-'.repeat(40);
        const extrasString = this.extras.map((extra, i) => `Extra #${i + 1}: ${extra}`).join('\n');

        const detailsString = `${separator}
            Model: ${this.model}
            CPU Model: ${this.cpuSeries}
            GPU Model: ${this.gpuModel}
            RAM Type: ${this.ramType}
            RAM Size: ${this.ramSize} GB
            Display Type: ${this.displayType}
            SSD Type: ${this.ssdType}
            SSD Capacity: ${this.ssdCapacity} GB
            Extras:
            ${extrasString}
            ${separator}
        `;

        console.log(detailsString);
    }
}

module.exports = Laptop;
