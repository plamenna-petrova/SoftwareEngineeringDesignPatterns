
const BaseControlComposite = require("./baseControlComposite");

class GroupBox extends BaseControlComposite {
    constructor(name, width, height, foreColor, backColor) {
        super(name, width, height, foreColor, backColor);
    }
}

module.exports = GroupBox;