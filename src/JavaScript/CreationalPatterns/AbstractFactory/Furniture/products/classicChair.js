
const IFurnitureFactory = require("../interfaces/furnitureFactory");

/**
 * @implements {IFurnitureFactory}
 */
class ClassicChair {
    /**
     * @override
     */
    showFurnitureStyle() {
        console.log("I am a classic chair");
    }
}

module.exports = ClassicChair;