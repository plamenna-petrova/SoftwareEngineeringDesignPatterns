
const IFurnitureFactory = require("../interfaces/furnitureFactory");
const ClassicCabinet = require("../products/classicCabinet");
const ClassicChair = require("../products/classicChair");
const ClassicDiningTable = require("../products/classicDiningTable");

/**
 * @class
 * @implements {IFurnitureFactory}
 */
class ClassicFurnitureFactory {
    /**
     * @override
     */
    createCabinet() {
        return new ClassicCabinet();
    }

    /**
     * @override
     */
    createChair() {
        return new ClassicChair();
    }

    /**
     * @override
     */
    createDiningTable() {
        return new ClassicDiningTable();
    }
}

module.exports = ClassicFurnitureFactory;