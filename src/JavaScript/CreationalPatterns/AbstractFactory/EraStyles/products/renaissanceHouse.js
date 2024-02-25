
const EraObject = require("../abstraction/eraObject");
const GlobalConstants = require("../constants/globalConstants");

class RenaissanceHouse extends EraObject {
    showDetails() {
        console.log(GlobalConstants.HouseMessage.replace("{0}", "Renaissance"));
    }
}

module.exports = RenaissanceHouse;