
const IFurnitureFactory = require("../interfaces/furnitureFactory");

/**
 * @implements {IFurnitureFactory}
 */
class ContemporaryChair {
    /**
     * @override
     */
    showFurnitureStyle() {
        console.log("I am a contemporary chair");
    }
}

module.exports = ContemporaryChair;