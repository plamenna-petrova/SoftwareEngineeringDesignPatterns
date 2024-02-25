
const EraObject = require("../abstraction/eraObject");
const GlobalConstants = require("../constants/globalConstants");

class MedievalHouse extends EraObject {
    showDetails() {
        console.log(GlobalConstants.HouseMessage.replace("{0}", "Medieval"));
    }
}

module.exports = MedievalHouse;