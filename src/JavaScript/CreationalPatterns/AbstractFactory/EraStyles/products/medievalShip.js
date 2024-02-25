
const EraObject = require("../abstraction/eraObject");
const GlobalConstants = require("../constants/globalConstants");

class MedievalShip extends EraObject {
    showDetails() {
        console.log(GlobalConstants.ShipMessage.replace("{0}", "Medieval"));
    }
}

module.exports = MedievalShip;