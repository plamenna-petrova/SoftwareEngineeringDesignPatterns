
class Character {
    constructor() {
        this.symbol = '';
        this.width = 0;
        this.height = 0;
        this.ascent = 0;
        this.descent = 0;
        this.pointSize = 0;
    }

    display(pointSize) {
        this.pointSize = pointSize;
        console.log(`symbol (pointsize ${this.pointSize})`);
    }
}

class CharacterA extends Character {
    constructor() {
        super();
        this.symbol = 'A';
        this.height = 100;
        this.width = 120;
        this.ascent = 70;
        this.descent = 0;
    }
}

class CharacterB extends Character {
    constructor() {
        super();
        this.symbol = 'B';
        this.height = 100;
        this.width = 140;
        this.ascent = 72;
        this.descent = 0;
    }
}

class CharacterZ extends Character {
    constructor() {
        super();
        this.symbol = 'Z';
        this.height = 100;
        this.width = 100;
        this.ascent = 68;
        this.descent = 0;
    }

    display(pointSize) {
        this.pointSize = pointSize;
        console.log(`symbol (point size ${this.pointSize})`);
    }
}

class CharacterFactory {
    constructor() {
        this.characters = {};
    }

    getCharacter(key) {
        let character = null;

        if (this.characters.hasOwnProperty(key)) {
            character = this.characters[key];
        } else {
            switch (key) {
                case 'A':
                    character = new CharacterA();
                    break;
                case 'B':
                    character = new CharacterB();
                    break;
                case 'Z':
                    character = new CharacterZ();
                    break;
            }

            this.characters[key] = character;
        }

        return character;
    }
}

const documentText = "AAZZBBZB";
const documentTextCharacters = documentText.split('');

const characterFactory = new CharacterFactory();
let pointSize = 10;

documentTextCharacters.forEach(documentTextCharacter => {
    pointSize++;
    const character = characterFactory.getCharacter(documentTextCharacter);
    character.display(pointSize);
});