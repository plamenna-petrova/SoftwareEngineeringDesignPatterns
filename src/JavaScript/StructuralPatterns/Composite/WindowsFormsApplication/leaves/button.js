
const BaseControlLeaf = require("./baseControlLeaf");

class Button extends BaseControlLeaf {
    constructor(name, width, height, foreColor, backColor) {
        super(name, width, height, foreColor, backColor);
    }
}

module.exports = Button;