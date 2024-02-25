
const IFurnitureFactory = require("../interfaces/furnitureFactory");
const ContemporaryCabinet = require("../products/contemporaryCabinet");
const ContemporaryChair = require("../products/contemporaryChair");
const ContemporaryDiningTable = require("../products/contemporaryDiningTable");

/**
 * @class
 * @implements {IFurnitureFactory}
 */
class ContemporaryFurnitureFactory {
    /**
     * @override
     */
    createCabinet() {
        return new ContemporaryCabinet();
    }

    /**
     * @override
     */
    createChair() {
        return new ContemporaryChair();
    }

    /**
     * @override
     */
    createDiningTable() {
        return new ContemporaryDiningTable();
    }
}

module.exports = ContemporaryFurnitureFactory;