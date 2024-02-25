
const EraObject = require("../abstraction/eraObject");
const GlobalConstants = require("../constants/globalConstants");

class RenaissanceClothing extends EraObject {
    showDetails() {
        console.log(GlobalConstants.ClothingMessage.replace("{0}", "Renaissance"));
    }
}

module.exports = RenaissanceClothing;