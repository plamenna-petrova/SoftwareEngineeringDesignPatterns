
const CreateProductCommand = require("./createProductCommand");
const GetProductsRequest = require("./getProductsRequest");

class ProductsController {
    constructor(mediator) {
        this.mediator = mediator;
    }

    createProduct(productName, productPrice) {
        return this.mediator.send(new CreateProductCommand(productName, productPrice));
    }

    getProducts() {
        return this.mediator.send(new GetProductsRequest());
    }
}

module.exports = ProductsController;