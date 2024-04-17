import java.util.ArrayList;
import java.util.List;

class LEDTV {
    private String size;
    private double price;
    private boolean hasUSBSupport;

    public LEDTV(String size, double price, boolean hasUSBSupport) {
        this.size = size;
        this.price = price;
        this.hasUSBSupport = hasUSBSupport;
    }

    public String getSize() {
        return size;
    }

    public void setSize(String size) {
        this.size = size;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public boolean hasUSBSupport() {
        return hasUSBSupport;
    }

    public void setHasUSBSupport(boolean hasUSBSupport) {
        this.hasUSBSupport = hasUSBSupport;
    }

    public String getDetails() {
        return String.format("LEDTV [Size = %s, Price = %.2f, USBSupport = %s]", size, price, (hasUSBSupport ? "Yes" : "No"));
    }
}

class LEDTVMemento {
    private final LEDTV ledTV;

    public LEDTVMemento(LEDTV ledTV) {
        this.ledTV = ledTV;
    }

    public LEDTV getLEDTV() {
        return ledTV;
    }

    public String getDetails() {
        return "Memento [LedTV = " + ledTV.getDetails() + "]";
    }
}

class Caretaker {
    private final List<LEDTVMemento> ledTVs = new ArrayList<>();

    public void addMemento(LEDTVMemento ledTVMemento) {
        ledTVs.add(ledTVMemento);
        System.out.println("LED TV's snapshots maintained by caretaker : " + ledTVMemento.getDetails());
    }

    public LEDTVMemento getLEDTVMemento(int index) {
        return ledTVs.get(index);
    }
}

class Originator {
    private LEDTV ledTV;

    public LEDTV getLEDTV() {
        return ledTV;
    }

    public void setLEDTV(LEDTV ledTV) {
        this.ledTV = ledTV;
    }

    public LEDTVMemento createLEDTVMemento() {
        return new LEDTVMemento(ledTV);
    }

    public void setMemento(LEDTVMemento ledTVMemento) {
        ledTV = ledTVMemento.getLEDTV();
    }

    public String getDetails() {
        return "Originator [LEDTV = " + ledTV.getDetails() + "]";
    }
}

public class Main {
    public static void main(String[] args) {
        Originator originator = new Originator();
        originator.setLEDTV(new LEDTV("42-Inch", 60000, false));

        Caretaker caretaker = new Caretaker();

        LEDTVMemento ledTVMemento = originator.createLEDTVMemento();

        caretaker.addMemento(ledTVMemento);

        originator.setLEDTV(new LEDTV("46-Inch", 80000, true));

        ledTVMemento = originator.createLEDTVMemento();
        caretaker.addMemento(ledTVMemento);

        originator.setLEDTV(new LEDTV("50-Inch", 100000, true));

        System.out.println("Originator's current state : " + originator.getDetails());

        System.out.println("\nOriginator restoring to 42-Inch LED TV");

        originator.setMemento(caretaker.getLEDTVMemento(0));

        System.out.println("\nOriginator current state: " + originator.getDetails());
    }
}