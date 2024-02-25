
const ClassicFurnitureFactory = require('./concreteFactories/classicFurnitureFactory');
const ContemporaryFurnitureFactory = require('./concreteFactories/contemporaryFurnitureFactory');
const ScandinavianFurnitureFactory = require('./concreteFactories/scandinavianFurnitureFactory');

const prompt = require('prompt-sync')();

console.log("Please select your furniture style:");
console.log("[1] Classic, [2] Contemporary, [3] Scandinavian");

const furnitureStyle = parseInt(prompt("Enter your choice: "));
const furnitureFactory = getFurnitureFactory(furnitureStyle);

console.log("Please select your furniture type:");
console.log("[1] Cabinet, [2] Chair, [3] Dining Table");

const furnitureType = parseInt(prompt("Enter your choice: "));
const furniture = getFurniture(furnitureFactory, furnitureType);
furniture.showFurnitureStyle();

function getFurnitureFactory(style) {
    switch (style) {
        case 1:
            return new ClassicFurnitureFactory();
        case 2:
            return new ContemporaryFurnitureFactory();
        case 3:
            return new ScandinavianFurnitureFactory();
        default:
            throw new Error("Invalid choice");
    }
}

function getFurniture(factory, type) {
    switch (type) {
        case 1:
            return factory.createCabinet();
        case 2:
            return factory.createChair();
        case 3:
            return factory.createDiningTable();
        default:
            throw new Error("Invalid choice");
    }
}