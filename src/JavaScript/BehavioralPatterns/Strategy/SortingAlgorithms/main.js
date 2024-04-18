
class SortStrategy {
    Sort(listOfStrings) {}
}

class QuickSort extends SortStrategy {
    Sort(listOfStrings) {
        listOfStrings.sort();
        console.log("Quick-sorted list");
    }
}

class ShellSort extends SortStrategy {
    Sort(listOfStrings) {
        // not implemented
        console.log("Shell-sorted list");
    }
}

class MergeSort extends SortStrategy {
    Sort(listOfStrings) {
        // not implemented
        console.log("Merge-sorted list");
    }
}

class SortedList {
    constructor() {
        this.namesList = [];
        this.sortStrategy = null;
    }

    SetSortStrategy(sortStrategy) {
        this.sortStrategy = sortStrategy;
    }

    Add(name) {
        this.namesList.push(name);
    }

    Sort() {
        this.sortStrategy.Sort(this.namesList);

        for (const name of this.namesList) {
            console.log(` ${name}`);
        }

        console.log();
    }
}

let studentRecords = new SortedList();

studentRecords.Add("Samuel");
studentRecords.Add("Jimmy");
studentRecords.Add("Sandra");
studentRecords.Add("Vivek");
studentRecords.Add("Anna");

studentRecords.SetSortStrategy(new QuickSort());
studentRecords.Sort();

studentRecords.SetSortStrategy(new ShellSort());
studentRecords.Sort();

studentRecords.SetSortStrategy(new MergeSort());
studentRecords.Sort();