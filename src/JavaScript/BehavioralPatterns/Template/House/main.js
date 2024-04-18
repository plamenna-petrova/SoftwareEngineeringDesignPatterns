
class HouseTemplate {
    buildHouse() {
        this.buildFoundation();
        this.buildPillars();
        this.buildWalls();
        this.buildWindows();
        console.log("The house is built");
    }

    buildFoundation() {
        throw new Error("Abstract method buildFoundation() must be implemented.");
    }

    buildPillars() {
        throw new Error("Abstract method buildPillars() must be implemented.");
    }

    buildWalls() {
        throw new Error("Abstract method buildWalls() must be implemented.");
    }

    buildWindows() {
        throw new Error("Abstract method buildWindows() must be implemented.");
    }
}

class ConcreteHouse extends HouseTemplate {
    buildFoundation() {
        console.log("Building foundation with cement, iron rods and sand");
    }

    buildPillars() {
        console.log("Building concrete pillars with cement and sand");
    }

    buildWalls() {
        console.log("Building concrete walls");
    }

    buildWindows() {
        console.log("Building concrete windows");
    }
}

class WoodenHouse extends HouseTemplate {
    buildFoundation() {
        console.log("Building foundation with cement, iron rods and sand");
    }

    buildPillars() {
        console.log("Building wood pillars with wood coating");
    }

    buildWalls() {
        console.log("Building wood walls");
    }

    buildWindows() {
        console.log("Building wood windows");
    }
}

console.log("Building a concrete house\n");
let concreteHouse = new ConcreteHouse();
concreteHouse.buildHouse();

console.log("\nBuilding a wooden house\n");
let woodenHouse = new WoodenHouse();
woodenHouse.buildHouse();