
const BaseControlComposite = require("./baseControlComposite");

class Panel extends BaseControlComposite {
    constructor(name, width, height, foreColor, backColor) {
        super(name, width, height, foreColor, backColor);
    }
}

module.exports = Panel;