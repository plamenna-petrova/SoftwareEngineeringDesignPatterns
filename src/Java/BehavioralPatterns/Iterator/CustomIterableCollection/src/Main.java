import java.util.Iterator;

class CustomIterableList implements Iterable<Integer> {
    private final int[] frequencyArray;
    private final int arrayCapacity;

    public CustomIterableList(int arrayCapacity) {
        this.arrayCapacity = arrayCapacity;
        frequencyArray = new int[arrayCapacity];
    }

    public int[] getFrequencyArray() {
        return frequencyArray;
    }

    public int getArrayCapacity() {
        return arrayCapacity;
    }

    public void add(int i) {
        frequencyArray[i]++;
    }

    @Override
    public Iterator<Integer> iterator() {
        return new CustomListIterator(this);
    }
}

class CustomListIterator implements Iterator<Integer> {
    private final CustomIterableList customEnumerableList;
    private int currentItemIndex;
    private int itemsCount;

    public CustomListIterator(CustomIterableList customEnumerableList) {
        this.customEnumerableList = customEnumerableList;
        reset();
    }

    @Override
    public boolean hasNext() {
        return itemsCount > 0 || currentItemIndex + 1 < customEnumerableList.getArrayCapacity();
    }

    @Override
    public Integer next() {
        if (!hasNext()) {
            throw new IllegalStateException("No more elements");
        }
        if (itemsCount == 0) {
            do {
                currentItemIndex++;
            } while (currentItemIndex < customEnumerableList.getArrayCapacity()
                    && customEnumerableList.getFrequencyArray()[currentItemIndex] == 0);
            itemsCount = customEnumerableList.getFrequencyArray()[currentItemIndex] - 1;
            return currentItemIndex;
        } else {
            itemsCount--;
            return currentItemIndex;
        }
    }

    private void reset() {
        currentItemIndex = -1;
        itemsCount = 0;
    }
}

public class Main {
    public static void main(String[] args) {
        CustomIterableList numbersCollection = new CustomIterableList(4);
        numbersCollection.add(1);
        numbersCollection.add(2);
        numbersCollection.add(2);
        numbersCollection.add(3);

        for (int number : numbersCollection) {
            System.out.println(number);
        }
    }
}