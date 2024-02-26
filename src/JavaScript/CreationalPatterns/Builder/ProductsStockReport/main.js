
class Product {
    constructor(name, price) {
        this.Name = name;
        this.Price = price;
    }
}

class ProductsStockReport {
    constructor() {
        this.HeaderPart = '';
        this.BodyPart = '';
        this.FooterPart = '';
    }

    toString() {
        return `${this.HeaderPart}\n${this.BodyPart}\n${this.FooterPart}`;
    }
}

class IProductStockReportBuilder {
    buildHeader() { }
    buildBody() { }
    buildFooter() { }
    getProductsStockReport() { }
}

class ProductsStockReportBuilder extends IProductStockReportBuilder {
    constructor(products) {
        super();
        this.products = products;
        this.productsStockReport = new ProductsStockReport();
    }

    buildHeader() {
        this.productsStockReport.HeaderPart = `STOCK REPORT FOR ALL THE PRODUCTS ON DATE: ${new Date().toLocaleString()}\n`;
        return this;
    }

    buildBody() {
        this.productsStockReport.BodyPart = this.products.map(p => `Product name: ${p.Name}, product price: ${p.Price}`).join('\n');
        return this;
    }

    buildFooter() {
        this.productsStockReport.FooterPart = '\nReport, provided by the SAMPLE_PRODUCTS company';
        return this;
    }

    getProductsStockReport() {
        return this.productsStockReport;
    }
}

class ProductsStockReportDirector {
    constructor(productStockReportBuilder) {
        this.productStockReportBuilder = productStockReportBuilder;
    }

    buildStockReport() {
        this.productStockReportBuilder
            .buildHeader()
            .buildBody()
            .buildFooter();
    }
}

const products = [
    new Product("Monitor", 200.50),
    new Product("Mouse", 20.41),
    new Product("Keyboard", 30.15)
];

const productsStockReportBuilder = new ProductsStockReportBuilder(products);
const productsStockReportDirector = new ProductsStockReportDirector(productsStockReportBuilder);

productsStockReportDirector.buildStockReport();

const report = productsStockReportBuilder.getProductsStockReport();

console.log(report.toString());