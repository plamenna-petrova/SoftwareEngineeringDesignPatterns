
const EraObject = require("../abstraction/eraObject");
const GlobalConstants = require("../constants/globalConstants");

class MedievalClothing extends EraObject {
    showDetails() {
        console.log(GlobalConstants.ClothingMessage.replace("{0}", "Medieval"));
    }
}

module.exports = MedievalClothing;