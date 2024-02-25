abstract class Product {

}

class ConcreteProductA extends Product {

}

class ConcreteProductB extends Product {

}

abstract class Creator {
    public abstract Product createProduct();
}

class ConcreteCreatorA extends Creator {
    @Override
    public Product createProduct() {
        return new ConcreteProductA();
    }
}

class ConcreteCreatorB extends Creator {
    @Override
    public Product createProduct() {
        return new ConcreteProductB();
    }
}

class Program {
    public static void main(String[] args) {
        Creator[] creators = new Creator[2];

        creators[0] = new ConcreteCreatorA();
        creators[1] = new ConcreteCreatorB();

        for (Creator creator : creators) {
            Product createdProduct = creator.createProduct();
            System.out.println("Created: " + createdProduct.getClass().getSimpleName());
        }
    }
}