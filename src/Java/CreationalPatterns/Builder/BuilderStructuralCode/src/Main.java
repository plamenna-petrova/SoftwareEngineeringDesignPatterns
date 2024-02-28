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

        Builder concreteBuilder1 = new ConcreteBuilder1();
        Builder concreteBuilder2 = new ConcreteBuilder2();

        director.construct(concreteBuilder1);
        Product firstProduct = concreteBuilder1.getResult();
        firstProduct.show();

        director.construct(concreteBuilder2);
        Product secondProduct = concreteBuilder2.getResult();
        secondProduct.show();
    }
}