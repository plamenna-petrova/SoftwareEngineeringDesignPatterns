
const IFurnitureFactory = require("../interfaces/furnitureFactory");

/**
 * @implements {IFurnitureFactory}
 */
class ContemporaryDiningTable {
    /**
     * @override
     */
    showFurnitureStyle() {
        console.log("I am a contemporary dining table");
    }
}

module.exports = ContemporaryDiningTable;