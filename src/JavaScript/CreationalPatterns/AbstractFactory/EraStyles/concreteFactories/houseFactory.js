
const EraObjectStylesFactory = require("../abstraction/eraObjectStylesFactory");
const MedievalHouse = require("../products/medievalHouse");
const RenaissanceClothing = require("../products/renaissanceClothing");
const VictorianHouse = require("../products/victorianHouse");

class HouseFactory extends EraObjectStylesFactory {
    createMedievalStyleObject() {
        return new MedievalHouse();
    }

    createRenaissanceStyleObject() {
        return new RenaissanceClothing();
    }

    createVictorianEraStyleObject() {
        return new VictorianHouse();
    }
}

module.exports = HouseFactory;