
const EraObject = require("../abstraction/eraObject");
const GlobalConstants = require("../constants/globalConstants");

class VictorianClothing extends EraObject {
    showDetails() {
        console.log(GlobalConstants.ClothingMessage.replace("{0}", "Victorian Era"));
    }
}

module.exports = VictorianClothing;