
const Control = require('../component/control');

class BaseControlComposite extends Control {
    constructor(name, width, height, foreColor, backColor) {
        super(name, width, height, foreColor, backColor);
        this.controls = new Set();
    }

    add(control) {
        this.controls.add(control);
    }

    remove(control) {
        this.controls.delete(control);
    }

    getHierarchicalLevel(depthIndicator) {
        let groupBoxHierarchicalInfo = `${'-'.repeat(depthIndicator)}+ ` +
            `Name: ${this.name}, Width: ${this.width}, Fore Color: (${this.foreColor.red}, ${this.foreColor.green}, ${this.foreColor.blue}), ` +
            `Back Color: (${this.backColor.red}, ${this.backColor.green}, ${this.backColor.blue})\r\n`;

        for (const control of this.controls) {
            groupBoxHierarchicalInfo += control.getHierarchicalLevel(depthIndicator + 2);
        }

        return groupBoxHierarchicalInfo;
    }
}

module.exports = BaseControlComposite;
