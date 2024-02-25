
const IFurnitureFactory = require("../interfaces/furnitureFactory");
const ScandinavianCabinet = require("../products/scandinavianCabinet");
const ScandinavianChair = require("../products/scandinavianChair");
const ScandinavianDiningTable = require("../products/scandinavianDiningTable");

/**
 * @class
 * @implements {IFurnitureFactory}
 */
class ScandinavianFurnitureFactory {
    /**
     * @override
     */
    createCabinet() {
        return new ScandinavianCabinet();
    }

    /**
     * @override
     */
    createChair() {
        return new ScandinavianChair();
    }

    /**
     * @override
     */
    createDiningTable() {
        return new ScandinavianDiningTable();
    }
}

module.exports = ScandinavianFurnitureFactory;