
const IFurnitureFactory = require("../interfaces/furnitureFactory");

/**
 * @implements {IFurnitureFactory}
 */
class ClassicDiningTable {
    /**
     * @override
     */
    showFurnitureStyle() {
        console.log("I am a classic dining table");
    }
}

module.exports = ClassicDiningTable;