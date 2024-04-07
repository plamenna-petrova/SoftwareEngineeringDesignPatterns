import java.math.BigDecimal;

public class ProductsController {
    private final IMediator mediator;

    public ProductsController(IMediator mediator) {
        this.mediator = mediator;
    }

    public void createProduct(String productName, BigDecimal productPrice) {
        mediator.send(new CreateProductCommand(productName, productPrice));
    }

    public Object getProducts() {
        return mediator.send(new GetProductsRequest());
    }
}
