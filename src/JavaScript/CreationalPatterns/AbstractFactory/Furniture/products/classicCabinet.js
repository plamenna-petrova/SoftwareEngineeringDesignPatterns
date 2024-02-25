
const IFurnitureFactory = require("../interfaces/furnitureFactory");

/**
 * @implements {IFurnitureFactory}
 */
class ClassicCabinet {
    /**
     * @override
     */
    showFurnitureStyle() {
        console.log("I am a classic cabinet");
    }
}

module.exports = ClassicCabinet;