
const EraObject = require("../abstraction/eraObject");
const GlobalConstants = require("../constants/globalConstants");

class RenaissanceShip extends EraObject {
    showDetails() {
        console.log(GlobalConstants.ShipMessage.replace("{0}", "Renaissance"));
    }
}

module.exports = RenaissanceShip;