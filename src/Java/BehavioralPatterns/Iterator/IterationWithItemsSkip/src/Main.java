import java.util.ArrayList;
import java.util.List;

interface IAbstractIterator {
    Item getFirstItem();
    Item getNextItem();
    boolean isIterationDone();
    Item getCurrentItem();
}

class Iterator implements IAbstractIterator {
    private final Collection collection;
    private int currentItemIndex;
    private int stepsToSkip = 1;

    public Iterator(Collection collection) {
        this.collection = collection;
    }

    @Override
    public boolean isIterationDone() {
        return currentItemIndex >= collection.getCount();
    }

    @Override
    public Item getCurrentItem() {
        return collection.getItem(currentItemIndex);
    }

    public int getStepsToSkip() {
        return stepsToSkip;
    }

    public void setStepsToSkip(int stepsToSkip) {
        this.stepsToSkip = stepsToSkip;
    }

    @Override
    public Item getFirstItem() {
        currentItemIndex = 0;
        return collection.getItem(currentItemIndex);
    }

    @Override
    public Item getNextItem() {
        currentItemIndex += stepsToSkip;

        if (isIterationDone()) {
            return null;
        } else {
            return collection.getItem(currentItemIndex);
        }
    }
}

interface IAbstractCollection {
    Iterator createIterator();
}

class Collection implements IAbstractCollection {
    private final List<Item> items = new ArrayList<>();

    @Override
    public Iterator createIterator() {
        return new Iterator(this);
    }

    public void setItem(int index, Item item) {
        items.add(index, item);
    }

    public Item getItem(int index) {
        return items.get(index);
    }

    public int getCount() {
        return items.size();
    }
}

class Item {
    private final String name;

    public Item(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }
}

public class Main {
    public static void main(String[] args) {
        Collection collectionToIterateOver = new Collection();

        for (int i = 0; i < 8; i++) {
            collectionToIterateOver.setItem(i, new Item("Item " + (i + 1)));
        }

        Iterator iterator = collectionToIterateOver.createIterator();

        iterator.setStepsToSkip(2);

        System.out.println("Iterating over a collection: ");

        for (Item currentItem = iterator.getFirstItem(); !iterator.isIterationDone(); currentItem = iterator.getNextItem()) {
            System.out.println(currentItem.getName());
        }
    }
}