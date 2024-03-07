
const BaseControlComposite = require("./baseControlComposite");

class Form extends BaseControlComposite {
    constructor(name, width, height, foreColor, backColor) {
        super(name, width, height, foreColor, backColor);
    }
}

module.exports = Form;