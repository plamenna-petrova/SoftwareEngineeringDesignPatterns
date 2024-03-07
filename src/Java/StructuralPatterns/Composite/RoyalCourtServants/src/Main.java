import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

interface IServant {
    String getName();
    double getWage();
    String getRole();
    int getProductivity();
    int getReliability();
}

class Housemaid implements IServant {
    private String name;
    private double wage;
    private String role;
    private int productivity;
    private int reliability;

    public Housemaid(String name, double wage, String role, int productivity, int reliability) {
        this.name = name;
        this.wage = wage;
        this.role = role;
        this.productivity = productivity;
        this.reliability = reliability;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public double getWage() {
        return wage;
    }

    @Override
    public String getRole() {
        return role;
    }

    @Override
    public int getProductivity() {
        return productivity;
    }

    @Override
    public int getReliability() {
        return reliability;
    }
}

class Cook implements IServant {
    private String name;
    private double wage;
    private String role;
    private int productivity;
    private int reliability;

    public Cook(String name, double wage, String role, int productivity, int reliability) {
        this.name = name;
        this.wage = wage;
        this.role = role;
        this.productivity = productivity;
        this.reliability = reliability;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public double getWage() {
        return wage;
    }

    @Override
    public String getRole() {
        return role;
    }

    @Override
    public int getProductivity() {
        return productivity;
    }

    @Override
    public int getReliability() {
        return reliability;
    }
}

class RoyalCourt {
    protected List<IServant> servants;

    public RoyalCourt() {
        servants = new ArrayList<>();
    }

    public void addServant(IServant servant) {
        servants.add(servant);
    }

    public void removeServant(IServant servant) {
        if (servant.getReliability() < 50) {
            System.out.println(servant.getName() + " will be fired");
            servants.remove(servant);
        } else {
            System.out.println(servant.getName() + " won't be fired");
        }
    }

    public double getServantsWages() {
        return servants.stream().mapToDouble(IServant::getWage).sum();
    }

    public double getAverageProductivity() {
        double averageProductivity = servants.stream().mapToDouble(IServant::getProductivity).average().orElse(0.0);

        if (averageProductivity < 80) {
            System.out.println("Servants need to put more effort into their tasks");
        } else {
            System.out.println("Servants have done a great job so far...");
        }

        return averageProductivity;
    }

    public String getMinimumReliability() {
        Optional<IServant> servantWithMinimumReliability = servants.stream()
                .min((s1, s2) -> Integer.compare(s1.getReliability(), s2.getReliability()));

        return "The servant " + servantWithMinimumReliability.map(IServant::getName).orElse("") +
                " with role -- " + servantWithMinimumReliability.map(IServant::getRole).orElse("") +
                " -- has the minimum reliability of " + servantWithMinimumReliability.map(IServant::getReliability).orElse(0) + " %";
    }

    public String getMaximumReliability() {
        Optional<IServant> servantWithMaximumReliability = servants.stream()
                .max((s1, s2) -> Integer.compare(s1.getReliability(), s2.getReliability()));

        return "The servant " + servantWithMaximumReliability.map(IServant::getName).orElse("") +
                " with role -- " + servantWithMaximumReliability.map(IServant::getRole).orElse("") +
                " -- has the maximum reliability of " + servantWithMaximumReliability.map(IServant::getReliability).orElse(0) + " %";
    }

    public String toBePromoted() {
        StringBuilder promotionList = new StringBuilder();

        servants.stream()
                .filter(servant -> servant.getProductivity() >= 60)
                .forEach(servant -> promotionList.append(servant.getName())
                        .append(" with role ").append(servant.getRole())
                        .append(" will be promoted with new wage of ").append(servant.getWage() + 50)
                        .append("\n"));

        return promotionList.toString();
    }
}

public class Main {
    public static void main(String[] args) {
        // Arrange Servants, Royal Court, and add servants

        // housemaids
        IServant firstHouseMaid = new Housemaid("Emma", 150, "cleans the hall", 65, 70);
        IServant secondHouseMaid = new Housemaid("Isabella", 180, "cleans the kitchen", 70, 30);
        IServant thirdHouseMaid = new Housemaid("Gilda", 200, "cleans the guest rooms", 50, 90);
        IServant fourthHouseMaid = new Housemaid("Grace", 260, "cleans the bedrooms", 70, 80);

        // cooks
        IServant firstCook = new Cook("Norman", 300, "prepares breakfast Mondays and Fridays", 80, 90);
        IServant secondCook = new Cook("Ray", 280, "prepares dinner Wednesdays and Saturdays", 75, 40);
        IServant thirdCook = new Cook("Don", 250, "prepares desserts", 60, 95);
        IServant fourthCook = new Cook("Phil", 310, "prepares special meals", 90, 90);

        RoyalCourt royalCourt = new RoyalCourt();

        royalCourt.addServant(firstHouseMaid);
        royalCourt.addServant(secondHouseMaid);
        royalCourt.addServant(thirdHouseMaid);
        royalCourt.addServant(fourthHouseMaid);
        royalCourt.addServant(firstCook);
        royalCourt.addServant(secondCook);
        royalCourt.addServant(thirdCook);
        royalCourt.addServant(fourthCook);

        royalCourt.removeServant(firstHouseMaid);
        royalCourt.removeServant(secondHouseMaid);
        royalCourt.removeServant(thirdHouseMaid);
        royalCourt.removeServant(fourthHouseMaid);
        royalCourt.removeServant(firstCook);
        royalCourt.removeServant(secondCook);
        royalCourt.removeServant(thirdCook);
        royalCourt.removeServant(fourthCook);

        System.out.println("The sum of servants' wages for all servants is: " + royalCourt.getServantsWages());
        System.out.println("The average productivity for all servants is: " + String.format("%.2f", royalCourt.getAverageProductivity()));
        System.out.println("The minimum reliability among all servants is: " + royalCourt.getMinimumReliability());
        System.out.println("The maximum reliability among all servants is: " + royalCourt.getMaximumReliability());
        System.out.println("Servants to be promoted:\n" + royalCourt.toBePromoted());
    }
}