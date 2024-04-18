import java.util.List;
import java.util.ArrayList;
import java.util.Collections;

abstract class SortStrategy {
    public abstract void sort(List<String> listOfStrings);
}

class QuickSort extends SortStrategy {
    @Override
    public void sort(List<String> listOfStrings) {
        Collections.sort(listOfStrings);
        System.out.println("Quick-sorted list");
    }
}

class ShellSort extends SortStrategy {
    @Override
    public void sort(List<String> listOfStrings) {
        // not-implemented
        System.out.println("Shell-sorted list");
    }
}

class MergeSort extends SortStrategy {
    @Override
    public void sort(List<String> listOfStrings) {
        // not-implemented
        System.out.println("Merge-sorted list");
    }
}

class SortedList {
    private final List<String> namesList = new ArrayList<>();
    private SortStrategy sortStrategy;

    public void setSortStrategy(SortStrategy sortStrategy) {
        this.sortStrategy = sortStrategy;
    }

    public void add(String name) {
        namesList.add(name);
    }

    public void sort() {
        sortStrategy.sort(namesList);

        for (String name : namesList) {
            System.out.println(" " + name);
        }

        System.out.println();
    }
}

public class Main {
    public static void main(String[] args) {
        SortedList studentRecords = new SortedList();

        studentRecords.add("Samuel");
        studentRecords.add("Jimmy");
        studentRecords.add("Sandra");
        studentRecords.add("Vivek");
        studentRecords.add("Anna");

        studentRecords.setSortStrategy(new QuickSort());
        studentRecords.sort();

        studentRecords.setSortStrategy(new ShellSort());
        studentRecords.sort();

        studentRecords.setSortStrategy(new MergeSort());
        studentRecords.sort();
    }
}