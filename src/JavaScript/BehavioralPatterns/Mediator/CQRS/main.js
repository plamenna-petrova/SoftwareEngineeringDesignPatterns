
const ProductsController = require('./productsController');
const Mediator = require('./mediator');
const CreateProductCommand = require('./createProductCommand');
const CreateProductCommandHandler = require('./createProductCommandHandler');
const GetProductsRequest = require('./getProductsRequest');
const GetProductsRequestHandler = require('./getProductsRequestHandler');

function executeCQRSExample() {
  const mediator = new Mediator({
    CreateProductCommand: CreateProductCommandHandler,
    GetProductsRequest: GetProductsRequestHandler
  });

  const productsController = new ProductsController(mediator);

  productsController.createProduct("Product 1", 100);

  const products = productsController.getProducts();
}

executeCQRSExample();