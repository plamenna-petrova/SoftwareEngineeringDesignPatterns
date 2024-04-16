
class CreateProductCommandHandler {
  execute(createProductCommand) {
    console.log("Creating the product: " + createProductCommand.name);
    return true;
  }
}

module.exports = CreateProductCommandHandler;