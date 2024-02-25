
const EraObjectStylesFactory = require("../abstraction/eraObjectStylesFactory");
const MedievalClothing = require("../products/medievalClothing");
const RenaissanceClothing = require("../products/renaissanceClothing");
const VictorianClothing = require("../products/victorianClothing");

class ClothingFactory extends EraObjectStylesFactory {
    createMedievalStyleObject() {
        return new MedievalClothing();
    }

    createRenaissanceStyleObject() {
        return new RenaissanceClothing();
    }

    createVictorianEraStyleObject() {
        return new VictorianClothing();
    }
}

module.exports = ClothingFactory;