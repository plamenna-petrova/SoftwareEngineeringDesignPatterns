class Memento {
    private String name;
    private String phone;
    private double budget;

    public Memento(String name, String phone, double budget) {
        this.name = name;
        this.phone = phone;
        this.budget = budget;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public double getBudget() {
        return budget;
    }

    public void setBudget(double budget) {
        this.budget = budget;
    }
}

class SalesProspect {
    private String name;
    private String phone;
    private double budget;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
        System.out.println("Name:  " + name);
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
        System.out.println("Phone:  " + phone);
    }

    public double getBudget() {
        return budget;
    }

    public void setBudget(double budget) {
        this.budget = budget;
        System.out.println("Budget: " + budget);
    }

    public Memento saveMemento() {
        System.out.println("\nSaving state --\n");
        return new Memento(name, phone, budget);
    }

    public void restoreMemento(Memento memento) {
        System.out.println("\nRestoring state --\n");
        setName(memento.getName());
        setPhone(memento.getPhone());
        setBudget(memento.getBudget());
    }
}

class ProspectMemory {
    private Memento memento;

    public Memento getMemento() {
        return memento;
    }

    public void setMemento(Memento memento) {
        this.memento = memento;
    }
}

public class Main {
    public static void main(String[] args) {
        SalesProspect salesProspect = new SalesProspect();
        salesProspect.setName("Noel van Halen");
        salesProspect.setPhone("(412) 256-0990");

        ProspectMemory prospectMemory = new ProspectMemory();
        prospectMemory.setMemento(salesProspect.saveMemento());

        salesProspect.setName("Leo Welch");
        salesProspect.setPhone("(310) 209-7111");
        salesProspect.setBudget(100000.0);

        salesProspect.restoreMemento(prospectMemory.getMemento());
    }
}