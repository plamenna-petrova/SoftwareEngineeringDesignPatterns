import java.util.ArrayList;
import java.util.List;

public class GetProductsRequestHandler implements IRequestHandler<GetProductsRequest> {
    @Override
    public Object execute(GetProductsRequest getProductsRequest) {
        System.out.println("Returning the products");
        List<Product> products = new ArrayList<>();
        products.add(new Product("product 1"));
        products.add(new Product("product 2"));
        return products;
    }

    // Define a simple Product class to represent product data
    private static class Product {
        private String name;

        public Product(String name) {
            this.name = name;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }
    }
}