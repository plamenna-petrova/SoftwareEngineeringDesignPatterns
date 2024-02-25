
const Era = require('./client/era');
const ClothingFactory = require('./concreteFactories/clothingFactory');
const HouseFactory = require('./concreteFactories/houseFactory');
const ShipFactory = require('./concreteFactories/shipFactory');

const prompt = require('prompt-sync')();

let objectsCount = 1;

console.log(`Please select your object type number: ${objectsCount}`);
console.log("[H]House, [S]Ship, [C]Clothing");

let objectType = prompt('Enter your choice: ').toUpperCase();

console.log();

while (objectType !== 'E') {
    let factory = null;

    switch (objectType) {
        case 'H':
            factory = new HouseFactory();
            break;
        case 'S':
            factory = new ShipFactory();
            break;
        case 'C':
            factory = new ClothingFactory();
            break;
    }

    console.log("Enter era name: ");
    console.log("[M]Medieval, [R]Renaissance, [V]Victorian Era");

    let eraCharacter = prompt('Enter your choice: ').toUpperCase();

    console.log();

    let era = new Era(factory, eraCharacter);
    console.log(`Object Number #${objectsCount} `);
    era.info();

    console.log('-'.repeat(50));

    console.log(`Please select your object type: ${++objectsCount}`);
    console.log("[H]House, [S]Ship, [C]Clothing");

    objectType = prompt('Enter your choice: ').toUpperCase();

    console.log();
}