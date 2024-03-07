
const BaseControlLeaf = require("./baseControlLeaf");

class RadioButton extends BaseControlLeaf {
    constructor(name, width, height, foreColor, backColor) {
        super(name, width, height, foreColor, backColor);
    }
}

module.exports = RadioButton;