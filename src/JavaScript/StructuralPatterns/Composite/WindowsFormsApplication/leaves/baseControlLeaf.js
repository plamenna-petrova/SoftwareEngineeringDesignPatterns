
const Control = require('../component/control');

class BaseControlLeaf extends Control {
    constructor(name, width, height, foreColor, backColor) {
        super(name, width, height, foreColor, backColor);
    }

    get Controls() {
        return null;
    }

    add(_) {
        console.log(`Cannot add control to ${this.constructor.name}`);
    }

    remove(_) {
        console.log(`Cannot remove control from ${this.constructor.name}`);
    }

    getHierarchicalLevel(depthIndicator) {
        return `${'-'.repeat(depthIndicator)}+ ` +
            `Name: ${this.name}, Width: ${this.width}, ` +
            `Fore Color: (${this.foreColor.red}, ${this.foreColor.green}, ${this.foreColor.blue}), ` +
            `Back Color: (${this.backColor.red}, ${this.backColor.green}, ${this.backColor.blue})\r\n`;
    }
}

module.exports = BaseControlLeaf;
