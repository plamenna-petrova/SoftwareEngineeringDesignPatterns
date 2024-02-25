
const IFurniture = require("./furniture");

/**
 * @interface
 */
class IFurnitureFactory {
    /**
     * @returns {IFurniture}
     */
    createCabintet() {

    }

    /**
     * @returns {IFurniture}
     */
    createChair() {

    }

    /**
     * @returns {IFurniture}
     */
    createDiningTable() {

    }
}

module.exports = IFurnitureFactory;
