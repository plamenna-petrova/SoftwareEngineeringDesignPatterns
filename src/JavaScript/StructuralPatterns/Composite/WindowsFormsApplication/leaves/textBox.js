
const BaseControlLeaf = require("./baseControlLeaf");

class TextBox extends BaseControlLeaf {
    constructor(name, width, height, foreColor, backColor) {
        super(name, width, height, foreColor, backColor);
    }
}

module.exports = TextBox;