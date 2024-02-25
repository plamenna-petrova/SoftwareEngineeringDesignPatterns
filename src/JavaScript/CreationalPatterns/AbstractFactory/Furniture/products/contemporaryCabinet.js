
const IFurnitureFactory = require("../interfaces/furnitureFactory");

/**
 * @implements {IFurnitureFactory}
 */
class ContemporaryCabinet {
    /**
     * @override
     */
    showFurnitureStyle() {
        console.log("I am a contemporary cabinet");
    }
}

module.exports = ContemporaryCabinet;