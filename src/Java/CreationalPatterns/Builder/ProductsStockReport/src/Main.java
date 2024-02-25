import java.util.List;
import java.util.ArrayList;
import java.util.stream.Collectors;

class Product {
    private String name;
    private double price;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }
}

class ProductsStockReport {
    private String headerPart;
    private String bodyPart;
    private String footerPart;

    public String getHeaderPart() {
        return headerPart;
    }

    public void setHeaderPart(String headerPart) {
        this.headerPart = headerPart;
    }

    public String getBodyPart() {
        return bodyPart;
    }

    public void setBodyPart(String bodyPart) {
        this.bodyPart = bodyPart;
    }

    public String getFooterPart() {
        return footerPart;
    }

    public void setFooterPart(String footerPart) {
        this.footerPart = footerPart;
    }

    @Override
    public String toString() {
        return new StringBuilder()
                .append(headerPart)
                .append(bodyPart)
                .append(footerPart)
                .toString();
    }
}

interface IProductStockReportBuilder {
    IProductStockReportBuilder buildHeader();

    IProductStockReportBuilder buildBody();

    IProductStockReportBuilder buildFooter();

    ProductsStockReport getProductsStockReport();
}

class ProductsStockReportBuilder implements IProductStockReportBuilder {
    private List<Product> products;
    private ProductsStockReport productsStockReport;

    public ProductsStockReportBuilder(List<Product> products) {
        this.products = products;
        this.productsStockReport = new ProductsStockReport();
    }

    @Override
    public IProductStockReportBuilder buildHeader() {
        productsStockReport.setHeaderPart("STOCK REPORT FOR ALL THE PRODUCTS ON DATE: " + java.time.LocalDateTime.now() + "\n");
        return this;
    }

    @Override
    public IProductStockReportBuilder buildBody() {
        productsStockReport.setBodyPart(products.stream()
                .map(p -> "Product name: " + p.getName() + ", product price: " + p.getPrice())
                .collect(Collectors.joining(System.lineSeparator())));
        return this;
    }

    @Override
    public IProductStockReportBuilder buildFooter() {
        productsStockReport.setFooterPart("\nReport, provided by the SAMPLE_PRODUCTS company");
        return this;
    }

    @Override
    public ProductsStockReport getProductsStockReport() {
        return productsStockReport;
    }
}

class ProductsStockReportDirector {
    private final IProductStockReportBuilder productStockReportBuilder;

    public ProductsStockReportDirector(IProductStockReportBuilder productStockReportBuilder) {
        this.productStockReportBuilder = productStockReportBuilder;
    }

    public void buildStockReport() {
        productStockReportBuilder
                .buildHeader()
                .buildBody()
                .buildFooter();
    }
}

public class Main {
    public static void main(String[] args) {
        List<Product> products = new ArrayList<>();
        products.add(new Product() {{ setName("Monitor"); setPrice(200.50); }});
        products.add(new Product() {{ setName("Mouse"); setPrice(20.41); }});
        products.add(new Product() {{ setName("Keyboard"); setPrice(30.15); }});

        ProductsStockReportBuilder productsStockReportBuilder = new ProductsStockReportBuilder(products);

        ProductsStockReportDirector productsStockReportDirector = new ProductsStockReportDirector(productsStockReportBuilder);

        productsStockReportDirector.buildStockReport();

        ProductsStockReport report = productsStockReportBuilder.getProductsStockReport();

        System.out.println(report);
    }
}