import java.util.ArrayList;
import java.util.List;

abstract class Builder {
    public abstract void buildPartA();

    public abstract void buildPartB();

    public abstract Product getResult();
}

class Product {
    private List<String> parts = new ArrayList<>();

    public void add(String part) {
        parts.add(part);
    }

    public void show() {
        System.out.println("\nProduct Parts" + "-".repeat(10));

        for (String part : parts) {
            System.out.println(part);
        }
    }
}

class ConcreteBuilder1 extends Builder {
    private Product product = new Product();

    @Override
    public void buildPartA() {
        product.add("PartA");
    }

    @Override
    public void buildPartB() {
        product.add("PartB");
    }

    @Override
    public Product getResult() {
        return product;
    }
}

class ConcreteBuilder2 extends Builder {
    private Product product = new Product();

    @Override
    public void buildPartA() {
        product.add("PartX");
    }

    @Override
    public void buildPartB() {
        product.add("PartY");
    }

    @Override
    public Product getResult() {
        return product;
    }
}

class Director {
    public void construct(Builder builder) {
        builder.buildPartA();
        builder.buildPartB();
    }
}

public class Main {
    public static void main(String[] args) {
        Director director = new Director();

        Builder firstBuilder = new ConcreteBuilder1();
        Builder secondBuilder = new ConcreteBuilder2();

        director.construct(firstBuilder);
        Product firstProduct = firstBuilder.getResult();
        firstProduct.show();

        director.construct(secondBuilder);
        Product secondProduct = secondBuilder.getResult();
        secondProduct.show();
    }
}