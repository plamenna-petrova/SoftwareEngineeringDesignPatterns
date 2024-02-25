
const EraObject = require("../abstraction/eraObject");
const GlobalConstants = require("../constants/globalConstants");

class VictorianShip extends EraObject {
    showDetails() {
        console.log(GlobalConstants.ShipMessage.replace("{0}", "Victorian Era"));
    }
}

module.exports = VictorianShip;