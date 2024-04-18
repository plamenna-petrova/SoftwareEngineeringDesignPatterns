
const VendingMachine = require("./vendingMachine");
const Product = require("./product");

const firstVendingMachine = new VendingMachine([
    new Product("SPCOM1", 1, 3),
    new Product("SPCOM2", 3, 1)
]);

firstVendingMachine.selectProduct("SPCOM1");
firstVendingMachine.insertMoney(1);

console.log("========================== || ==========================");

const secondVendingMachine = new VendingMachine([
    new Product("SPCOM1", 1, 1),
    new Product("SPCOM2", 3, 1)
]);

secondVendingMachine.insertMoney(1);
secondVendingMachine.selectProduct("SPCOM1");
secondVendingMachine.insertMoney(0.4);
secondVendingMachine.insertMoney(1.2);
secondVendingMachine.selectProduct("SPCOM2");
secondVendingMachine.insertMoney(3.2);

secondVendingMachine.refill([
    new Product("SPCOM1", 1, 3),
    new Product("SPCOM2", 3, 4)
]);

secondVendingMachine.selectProduct("SPCOM2");
secondVendingMachine.insertMoney(5.2);

console.log("========================== || ==========================");

const thirdVendingMachine = new VendingMachine([
    new Product("SPCOM1", 1, 3),
    new Product("SPCOM2", 3, 1)
]);

thirdVendingMachine.selectProduct("SPCOM1");
thirdVendingMachine.insertMoney(1);