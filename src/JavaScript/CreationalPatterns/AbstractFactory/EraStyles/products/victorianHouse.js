
const EraObject = require("../abstraction/eraObject");
const GlobalConstants = require("../constants/globalConstants");

class VictorianHouse extends EraObject {
    showDetails() {
        console.log(GlobalConstants.HouseMessage.replace("{0}", "Victorian Era"));
    }
}

module.exports = VictorianHouse;