
const EraObjectStylesFactory = require("../abstraction/eraObjectStylesFactory");
const MedievalShip = require("../products/medievalShip");
const RenaissanceShip = require("../products/renaissanceShip");
const VictorianShip = require("../products/victorianShip");

class ShipFactory extends EraObjectStylesFactory {
    createMedievalStyleObject() {
        return new MedievalShip();
    }

    createRenaissanceStyleObject() {
        return new RenaissanceShip();
    }

    createVictorianEraStyleObject() {
        return new VictorianShip();
    }
}

module.exports = ShipFactory;