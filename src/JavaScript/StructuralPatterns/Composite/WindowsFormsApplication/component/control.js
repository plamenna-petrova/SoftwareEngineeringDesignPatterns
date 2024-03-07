
class Control {
    constructor(name, width, height, foreColor, backColor) {
        this.name = name;
        this.width = width;
        this.height = height;
        this.foreColor = foreColor;
        this.backColor = backColor;
        this.controls = [];
    }

    add(control) {
        this.controls.push(control);
    }

    remove(control) {
        const controlRemovalIndex = this.controls.indexOf(control);

        if (controlRemovalIndex !== -1) {
            this.controls.splice(index, 1);
        }
    }

    getHierarchicalLevel(depthIndicator) {
        const controlHierarchicalInfo = `${'-'.repeat(depthIndicator)}+ Name: ${this.name}, Width: ${this.width}, Fore Color: (${this.foreColor.red}, ${this.foreColor.green}, ${this.foreColor.blue}), Back Color: (${this.backColor.red}, ${this.backColor.green}, ${this.backColor.blue})\n`;

        for (const control of this.controls) {
            controlHierarchicalInfo += control.getHierarchicalLevel(depthIndicator + 2);
        }

        return controlHierarchicalInfo;
    }
}

module.exports = Control;


