
class MedievalShipTemplate {
    buildMedievalShip() {
        this.buildFoundation();
        this.buildHull();
        this.buildDeck();
        this.buildMasts();
        this.buildCabins();
        this.buildExteriorDetails();
        console.log("The ship is built.");
    }

    buildFoundation() {
        throw new Error("Method 'buildFoundation()' must be implemented.");
    }

    buildHull() {
        throw new Error("Method 'buildHull()' must be implemented.");
    }

    buildDeck() {
        throw new Error("Method 'buildDeck()' must be implemented.");
    }

    buildMasts() {
        throw new Error("Method 'buildMasts()' must be implemented.");
    }

    buildCabins() {
        throw new Error("Method 'buildCabins()' must be implemented.");
    }

    buildExteriorDetails() {
        throw new Error("Method 'buildExteriorDetails()' must be implemented.");
    }
}

class Cog extends MedievalShipTemplate {

    buildFoundation() {
        console.log("Building foundation with oak");
    }

    buildHull() {
        console.log("Building a double-ended hull");
    }

    buildDeck() {
        console.log("Building a small deck");
    }

    buildMasts() {
        console.log("Building one mast");
    }

    buildCabins() {
        console.log("Building four cabins");
    }

    buildExteriorDetails() {
        console.log("Building a rear tower");
    }
}

class Caravel extends MedievalShipTemplate {

    buildFoundation() {
        console.log("Building foundation, using carvel method of construction");
    }

    buildHull() {
        console.log("Building a lateen rigged hull");
    }

    buildDeck() {
        console.log("Building a large deck");
    }

    buildMasts() {
        console.log("Building three masts");
    }

    buildCabins() {
        console.log("Building eight cabins");
    }

    buildExteriorDetails() {
        console.log("Building templar flags ornaments");
    }
}

console.log("Building the medieval ship Cog");
let medievalShip = new Cog();
medievalShip.buildMedievalShip();

console.log("\n");

console.log("Building the medieval ship Caravel");
medievalShip = new Caravel();
medievalShip.buildMedievalShip();