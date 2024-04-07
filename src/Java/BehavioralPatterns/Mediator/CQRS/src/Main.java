import java.math.BigDecimal;
import java.util.HashMap;
import java.util.Map;

public class Main {
    public static void main(String[] args) {
        ProductsController productsController = new ProductsController(new Mediator(createRequestHandlers()));

        productsController.createProduct("Product 1", BigDecimal.valueOf(100));

        Object products = productsController.getProducts();
    }

    private static Map<Class<?>, Class<?>> createRequestHandlers() {
        Map<Class<?>, Class<?>> requestHandlers = new HashMap<>();
        requestHandlers.put(CreateProductCommand.class, CreateProductCommandHandler.class);
        requestHandlers.put(GetProductsRequest.class, GetProductsRequestHandler.class);
        return requestHandlers;
    }
}