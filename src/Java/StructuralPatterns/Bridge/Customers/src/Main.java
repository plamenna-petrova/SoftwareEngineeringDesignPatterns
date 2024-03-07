import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

class CustomersBase {
    private DataObject dataObject;

    public DataObject getDataObject() {
        return dataObject;
    }

    public void setDataObject(DataObject dataObject) {
        this.dataObject = dataObject;
    }

    public void next() {
        dataObject.getNextRecord();
    }

    public void previous() {
        dataObject.getPreviousRecord();
    }

    public void add(String record) {
        dataObject.addRecord(record);
    }

    public void remove(String record) {
        dataObject.removeRecord(record);
    }

    public void show() {
        dataObject.showRecord();
    }

    public void showAll() {
        dataObject.showAllRecords();
    }
}

class RefinedCustomers extends CustomersBase {
    @Override
    public void showAll() {
        System.out.println();
        System.out.println(new String(new char[40]).replace('\0', '-'));
        super.showAll();
        System.out.println(new String(new char[40]).replace('\0', '-'));
    }
}

abstract class DataObject {
    public abstract void getNextRecord();

    public abstract void getPreviousRecord();

    public abstract void addRecord(String record);

    public abstract void removeRecord(String record);

    public abstract String getCurrentRecord();

    public abstract void showRecord();

    public abstract void showAllRecords();
}

class CustomersData extends DataObject {
    private final List<String> customers = new ArrayList<>();
    private int currentCustomerIndex = 0;
    private final String city;

    public CustomersData(String city) {
        this.city = city;

        customers.add("Jim Jones");
        customers.add("Samuel Jackson");
        customers.add("Allen Good");
        customers.add("Ann Stills");
        customers.add("Lisa Giolani");
    }

    public String getCity() {
        return city;
    }

    @Override
    public void getNextRecord() {
        if (currentCustomerIndex <= customers.size() - 1) {
            currentCustomerIndex++;
        }
    }

    @Override
    public void getPreviousRecord() {
        if (currentCustomerIndex > 0) {
            currentCustomerIndex--;
        }
    }

    @Override
    public void addRecord(String record) {
        customers.add(record);
    }

    @Override
    public void removeRecord(String record) {
        customers.remove(record);
    }

    @Override
    public String getCurrentRecord() {
        return customers.get(currentCustomerIndex);
    }

    @Override
    public void showRecord() {
        System.out.println(customers.get(currentCustomerIndex));
    }

    @Override
    public void showAllRecords() {
        System.out.println(new StringBuilder().append("Customers City: ").append(city)
                .append("\n")
                .append(customers.stream().map(c -> " " + c).collect(Collectors.joining(System.lineSeparator())))
        );
    }
}

public class Main {
    public static void main(String[] args) {
        CustomersBase customers = new RefinedCustomers();
        customers .setDataObject(new CustomersData("Chicago"));

        customers.show();
        customers.next();
        customers.show();
        customers.next();
        customers.show();
        customers.previous();
        customers.show();
        customers.add("Henry Velasquez");
        customers.showAll();
        customers.remove("Allen Good");
        customers.showAll();
    }
}