
const BaseControlLeaf = require("./baseControlLeaf");

class CheckBox extends BaseControlLeaf {
    constructor(name, width, height, foreColor, backColor) {
        super(name, width, height, foreColor, backColor);
    }
}

module.exports = CheckBox;