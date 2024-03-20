
class CharacterBuild {
    constructor() {
        this.health = 0;
        this.stamina = 0;
        this.strength = 0;
        this.dexterity = 0;
        this.endurance = 0;
        this.attunement = 0;
    }

    showStats() {
        console.log(`Health: ${this.health}`);
        console.log(`Stamina: ${this.stamina}`);
        console.log(`Strength: ${this.strength}`);
        console.log(`Dexterity: ${this.dexterity}`);
        console.log(`Endurance: ${this.endurance}`);
        console.log(`Attunement: ${this.attunement}\r\n`);
    }
}

class Knight extends CharacterBuild {
    constructor() {
        super();
        this.health = 120;
        this.stamina = 110;
        this.strength = 15;
        this.dexterity = 10;
        this.endurance = 12;
        this.attunement = 3;
    }
}

class Wanderer extends CharacterBuild {
    constructor() {
        super();
        this.health = 100;
        this.stamina = 120;
        this.strength = 10;
        this.dexterity = 15;
        this.endurance = 12;
        this.attunement = 4;
    }
}

class CharacterBuildDecorator extends CharacterBuild {
    constructor(characterBuild) {
        super();
        this.characterBuild = characterBuild;
    }

    increaseHealth(points) {
        this.characterBuild.health += points;
    }

    increaseStrength(points) {
        this.characterBuild.strength += points;
    }

    increaseDexterity(points) {
        this.characterBuild.dexterity += points;
    }

    increaseEndurance(points) {
        this.characterBuild.endurance += points;
    }

    increaseAttunement(points) {
        this.characterBuild.attunement += points;
    }

    showStats() {
        this.characterBuild.showStats();
    }
}

class StrengthBuild extends CharacterBuildDecorator {
    constructor(characterBuild) {
        super(characterBuild);
        this.characterBuild.strength += 10;
        this.characterBuild.health -= 10;
    }
}

class DexterityBuild extends CharacterBuildDecorator {
    constructor(characterBuild) {
        super(characterBuild);
        this.characterBuild.dexterity += 10;
        this.characterBuild.strength -= 2;
    }
}

class MagicKnightBuild extends CharacterBuildDecorator {
    constructor(characterBuild) {
        super(characterBuild);
        if (characterBuild instanceof CharacterBuildDecorator) {
            characterBuild.increaseAttunement(15);
        } else {
            characterBuild.attunement += 15;
        }
    }
}

const knight = new Knight();
console.log("Base Knight Stats:");
knight.showStats();

const strengthenedKnight = new StrengthBuild(knight);
console.log("Knight Stats After Strength Build:");
strengthenedKnight.showStats();

const wanderer = new Wanderer();
console.log("Base Wanderer Stats:");
wanderer.showStats();

const dexterousWanderer = new DexterityBuild(wanderer);
console.log("Wanderer Stats After Dexterity Build:");
dexterousWanderer.showStats();

const magicKnight = new MagicKnightBuild(strengthenedKnight);
console.log("Strengthened Knight After Magic Build:");
magicKnight.showStats();