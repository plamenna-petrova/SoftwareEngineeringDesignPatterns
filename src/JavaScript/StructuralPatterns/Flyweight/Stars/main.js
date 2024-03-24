
class Star {
    print() { }
}

class WhiteDwarf extends Star {
    print() {
        console.log("Print white dwarf");
    }
}

class RedGiant extends Star {
    print() {
        console.log("Print red giant");
    }
}

class StarsFactory {
    constructor() {
        this.stars = new Map();
    }

    getStar(starType) {
        let star;

        if (this.stars.has(starType)) {
            star = this.stars.get(starType);
        } else {
            if (starType === "White Dwarf") {
                star = new WhiteDwarf();
                this.stars.set(starType, star);
            } else {
                star = new RedGiant();
                this.stars.set(starType, star);
            }
        }

        return star;
    }

    get starsCount() {
        return this.stars.size;
    }
}

const starsFactory = new StarsFactory();

let star = starsFactory.getStar("White Dwarf");
star.print();
star = starsFactory.getStar("White Dwarf");
star.print();
star = starsFactory.getStar("White Dwarf");
star.print();

console.log("-------------------------------");
star = starsFactory.getStar("Red Giant");
star.print();
star = starsFactory.getStar("Red Giant");
star.print();
star = starsFactory.getStar("Red Giant");
star.print();

console.log(`Get stars count : ${starsFactory.starsCount}`);