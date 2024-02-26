<?php

class Product
{
    public $name;
    public $price;

    public function __construct($name, $price)
    {
        $this->name = $name;
        $this->price = $price;
    }
}

class ProductsStockReport
{
    public string $headerPart;
    public string $bodyPart;
    public string $footerPart;

    public function __toString()
    {
        return "{$this->headerPart}\n{$this->bodyPart}\n{$this->footerPart}";
    }
}

interface IProductStockReportBuilder
{
    public function buildHeader();

    public function buildBody();

    public function buildFooter();

    public function getProductsStockReport();
}

class ProductsStockReportBuilder implements IProductStockReportBuilder
{
    private array $products;
    private ProductsStockReport $productsStockReport;

    public function __construct($products)
    {
        $this->products = $products;
        $this->productsStockReport = new ProductsStockReport();
    }

    public function buildHeader(): static
    {
        $this->productsStockReport->headerPart = "STOCK REPORT FOR ALL THE PRODUCTS ON DATE: " . date("Y-m-d H:i:s") . "\n";
        return $this;
    }

    public function buildBody(): static
    {
        $this->productsStockReport->bodyPart = implode(
            PHP_EOL,
            array_map(
                function ($p) {
                    return "Product name: {$p->name}, product price: {$p->price}";
                },
                $this->products
            )
        );

        return $this;
    }

    public function buildFooter(): static
    {
        $this->productsStockReport->footerPart = "\nReport, provided by the SAMPLE_PRODUCTS company";
        return $this;
    }

    public function getProductsStockReport(): ProductsStockReport
    {
        return $this->productsStockReport;
    }
}

class ProductsStockReportDirector
{
    private IProductStockReportBuilder $productStockReportBuilder;

    public function __construct(IProductStockReportBuilder $productStockReportBuilder)
    {
        $this->productStockReportBuilder = $productStockReportBuilder;
    }

    public function buildStockReport(): void
    {
        $this->productStockReportBuilder
            ->buildHeader()
            ->buildBody()
            ->buildFooter();
    }
}

$products = [
    new Product("Monitor", 200.50),
    new Product("Mouse", 20.41),
    new Product("Keyboard", 30.15),
];

$productsStockReportBuilder = new ProductsStockReportBuilder($products);
$productsStockReportDirector = new ProductsStockReportDirector($productsStockReportBuilder);
$productsStockReportDirector->buildStockReport();
$report = $productsStockReportBuilder->getProductsStockReport();

echo $report;