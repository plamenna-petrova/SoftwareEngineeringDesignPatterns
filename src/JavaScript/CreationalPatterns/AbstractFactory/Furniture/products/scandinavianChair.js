
const IFurnitureFactory = require("../interfaces/furnitureFactory");

/**
 * @implements {IFurnitureFactory}
 */
class ScandinavianChair {
    /**
     * @override
     */
    showFurnitureStyle() {
        console.log("I am a Scandinavian chair");
    }
}

module.exports = ScandinavianChair;