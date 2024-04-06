import java.util.ArrayList;
import java.util.List;

abstract class Iterator {
    public abstract Object getFirstItem();
    public abstract Object getNextItem();
    public abstract boolean isIterationDone();
    public abstract Object getCurrentItem();
}

class ConcreteIterator extends Iterator {
    private final ConcreteAggregate concreteAggregate;
    private int currentItemIndex = 0;

    public ConcreteIterator(ConcreteAggregate concreteAggregate) {
        this.concreteAggregate = concreteAggregate;
    }

    @Override
    public Object getFirstItem() {
        return concreteAggregate.getItem(0);
    }

    @Override
    public Object getNextItem() {
        Object nextItem = null;
        if (currentItemIndex < concreteAggregate.getCount() - 1) {
            nextItem = concreteAggregate.getItem(++currentItemIndex);
        }
        return nextItem;
    }

    @Override
    public Object getCurrentItem() {
        return concreteAggregate.getItem(currentItemIndex);
    }

    @Override
    public boolean isIterationDone() {
        return currentItemIndex >= concreteAggregate.getCount();
    }
}

abstract class Aggregate {
    public abstract Iterator createIterator();
}

class ConcreteAggregate extends Aggregate {
    private final List<Object> items = new ArrayList<>();

    @Override
    public Iterator createIterator() {
        return new ConcreteIterator(this);
    }

    public void setItem(int index, Object item) {
        items.add(index, item);
    }

    public Object getItem(int index) {
        return items.get(index);
    }

    public int getCount() {
        return items.size();
    }
}

public class Main {
    public static void main(String[] args) {
        ConcreteAggregate concreteAggregate = new ConcreteAggregate();

        concreteAggregate.setItem(0, "Item A");
        concreteAggregate.setItem(1, "Item B");
        concreteAggregate.setItem(2, "Item C");
        concreteAggregate.setItem(3, "Item D");

        Iterator iterator = concreteAggregate.createIterator();

        System.out.println("Iterating over collection: ");

        Object currentItem = iterator.getFirstItem();

        while (currentItem != null) {
            System.out.println(currentItem);
            currentItem = iterator.getNextItem();
        }
    }
}