
class GetProductsRequestHandler {
    execute(getProductsRequest) {
        console.log("Returning the products");
        return [{ Name: "product 1" }, { Name: "product 2" }];
    }
}

module.exports = GetProductsRequestHandler;