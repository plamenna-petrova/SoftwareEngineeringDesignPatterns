
const IFurnitureFactory = require("../interfaces/furnitureFactory");

/**
 * @implements {IFurnitureFactory}
 */
class ScandinavianDiningTable {
    /**
     * @override
     */
    showFurnitureStyle() {
        console.log("I am a Scandinavian dining table");
    }
}

module.exports = ScandinavianDiningTable;