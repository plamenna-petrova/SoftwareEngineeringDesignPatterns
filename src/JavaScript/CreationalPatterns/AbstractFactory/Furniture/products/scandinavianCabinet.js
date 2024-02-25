
const IFurnitureFactory = require("../interfaces/furnitureFactory");

/**
 * @implements {IFurnitureFactory}
 */
class ScandinavianCabinet {
    /**
     * @override
     */
    showFurnitureStyle() {
        console.log("I am a Scandinavian cabinet");
    }
}

module.exports = ScandinavianCabinet;