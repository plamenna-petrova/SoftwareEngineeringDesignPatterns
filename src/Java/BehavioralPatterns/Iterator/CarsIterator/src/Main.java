import java.util.*;

interface Iterator {
    boolean moveNext();
    Object currentItem();
}

class ConcreteIteratorForItems implements Iterator {
    private final String[] data;
    private int currentPosition = -1;

    public ConcreteIteratorForItems(String[] data) {
        this.data = data;
    }

    @Override
    public Object currentItem() {
        return data[currentPosition];
    }

    @Override
    public boolean moveNext() {
        if (currentPosition < data.length - 1) {
            currentPosition++;
            return true;
        }
        return false;
    }
}

interface IIterable {
    Iterator createIterator();
}

class Collection implements IIterable {
    private final String[] items;

    public Collection(String[] items) {
        this.items = items;
    }

    @Override
    public Iterator createIterator() {
        return new ConcreteIteratorForItems(items);
    }
}

abstract class Company implements IIterable {
    @Override
    public abstract Iterator createIterator();
}

class Car {
    private final String name;

    public Car(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    @Override
    public String toString() {
        return name;
    }
}

class Ferrari implements Iterable<Car> {
    private final List<Car> cars;

    public Ferrari() {
        cars = new ArrayList<>();
    }

    public void addCar(Car car) {
        cars.add(car);
    }

    public void removeCar(String name) {
        cars.removeIf(car -> car.getName().equals(name));
    }

    @Override
    public java.util.Iterator<Car> iterator() {
        return cars.iterator();
    }
}

class Ford implements Iterable<Car> {
    private final Car[] cars;

    public Ford(Car[] cars) {
        this.cars = cars;
    }

    @Override
    public java.util.Iterator<Car> iterator() {
        return Arrays.asList(cars).iterator();
    }
}

class CarDealer {
    private final List<Iterable<Car>> carCompanies;

    @SafeVarargs
    public CarDealer(Iterable<Car>... carCompanies) {
        this.carCompanies = Arrays.asList(carCompanies);
    }

    public void printCars() {
        for (Iterable<Car> company : carCompanies) {
            for (Car car : company) {
                System.out.println(car);
            }
        }
    }
}

class Node {
    public int value;
    public Node left, right;

    public Node(int value) {
        this.value = value;
        left = right = null;
    }
}

abstract class BinaryTreeIterator implements java.util.Iterator<Node> {
    protected Queue<Node> queue;
    private final Node root;

    public BinaryTreeIterator(Node root) {
        this.root = root;
        queue = new LinkedList<>();
        traverse(root);
    }

    @Override
    public Node next() {
        return queue.poll();
    }

    protected abstract void traverse(Node node);

    @Override
    public boolean hasNext() {
        return !queue.isEmpty();
    }

    public void reset() {
        queue.clear();
        traverse(root);
    }
}

class PreOrderIterator extends BinaryTreeIterator {
    public PreOrderIterator(Node root) {
        super(root);
    }

    @Override
    protected void traverse(Node node) {
        if (node == null) return;
        queue.add(node);
        traverse(node.left);
        traverse(node.right);
    }
}

class InOrderIterator extends BinaryTreeIterator {
    public InOrderIterator(Node root) {
        super(root);
    }

    @Override
    protected void traverse(Node node) {
        if (node == null) return;
        traverse(node.left);
        queue.add(node);
        traverse(node.right);
    }
}

class PostOrderIterator extends BinaryTreeIterator {
    public PostOrderIterator(Node root) {
        super(root);
    }

    @Override
    protected void traverse(Node node) {
        if (node == null) return;
        traverse(node.left);
        traverse(node.right);
        queue.add(node);
    }
}

class Main {
    public static void main(String[] args) {
        Collection collectionToIterateOver = new Collection(new String[]{"Item1", "Item2", "Item3"});
        Iterator iterator = collectionToIterateOver.createIterator();

        while (iterator.moveNext()) {
            System.out.println(iterator.currentItem());
        }

        Ferrari ferrari = new Ferrari();
        ferrari.addCar(new Car("Ferrari F40"));
        ferrari.addCar(new Car("Ferrari F355"));
        ferrari.addCar(new Car("Ferrari 250 GT0"));
        ferrari.addCar(new Car("Ferrari 125 S"));
        ferrari.addCar(new Car("Ferrari 488 GTB"));

        Ford ford = new Ford(new Car[]{
                new Car("Ford Model T"),
                new Car("Ford GT40"),
                new Car("Ford Escort"),
                new Car("Ford Focus"),
                new Car("Ford Mustang")
        });

        CarDealer carDealer = new CarDealer(ferrari, ford);
        carDealer.printCars();

        Node root = new Node(25);
        root.left = new Node(15);
        root.right = new Node(50);

        root.left.left = new Node(10);
        root.left.right = new Node(22);
        root.right.left = new Node(35);
        root.right.right = new Node(70);

        root.left.left.left = new Node(4);
        root.left.left.right = new Node(12);
        root.left.right.left = new Node(18);
        root.left.right.right = new Node(24);

        root.right.left.left = new Node(31);
        root.right.left.right = new Node(44);
        root.right.right.left = new Node(66);
        root.right.right.right = new Node(90);

        PreOrderIterator preOrderIterator = new PreOrderIterator(root);
        PostOrderIterator postOrderIterator = new PostOrderIterator(root);
        InOrderIterator inOrderIterator = new InOrderIterator(root);

        iterateTree(preOrderIterator);
        iterateTree(postOrderIterator);
        iterateTree(inOrderIterator);
    }

    private static void iterateTree(BinaryTreeIterator iterator) {
        List<Integer> results = new ArrayList<>();

        while (iterator.hasNext()) {
            results.add(iterator.next().value);
        }

        System.out.println(iterator.getClass().getSimpleName() + " results: " + results);
    }
}