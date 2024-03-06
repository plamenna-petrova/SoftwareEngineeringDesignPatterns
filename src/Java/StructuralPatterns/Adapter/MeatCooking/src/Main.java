import java.util.HashMap;
import java.util.Map;

class Meat {
    protected String meatName;
    protected double safeCookingTemperatureInFahrenheit;
    protected double safeCookingTemperatureInCelsius;
    protected double caloriesPerOunce;
    protected double caloriesPerGram;
    protected double proteinPerOunce;
    protected double proteinPerGram;

    public Meat(String meatName) {
        this.meatName = meatName;
    }

    public void loadData() {
        System.out.printf("\nMeat: %s %s%n", meatName, new String(new char[7]).replace('\0', '-'));
    }
}

class MeatDetails extends Meat {

    public MeatDetails(String meatName) {
        super(meatName);
    }

    @Override
    public void loadData() {
        MeatDatabase meatDatabase = new MeatDatabase();

        safeCookingTemperatureInFahrenheit = meatDatabase.getSafeCookingTemperature(meatName);
        safeCookingTemperatureInCelsius = fahrenheitToCelsius(safeCookingTemperatureInFahrenheit);
        caloriesPerOunce = meatDatabase.getCaloriesPerOunce(meatName);
        caloriesPerGram = poundsToGrams(caloriesPerOunce);
        proteinPerOunce = meatDatabase.getProteinPerOunce(meatName);
        proteinPerGram = poundsToGrams(proteinPerOunce);

        super.loadData();

        String meatDetails = String.format(
                " Safe Cooking Temperature (Fahrenheit) : %.2f%n" +
                        " Safe Cooking Temperature (Celsius) : %.2f%n" +
                        " Calories per Ounce: %.2f%n" +
                        " Calories per Gram: %.2f%n" +
                        " Protein per Ounce: %.2f%n" +
                        " Protein per gram: %.2f%n",
                safeCookingTemperatureInFahrenheit, safeCookingTemperatureInCelsius,
                caloriesPerOunce, caloriesPerGram,
                proteinPerOunce, proteinPerGram);

        System.out.println(meatDetails);
    }

    private double fahrenheitToCelsius(double temperatureInFahrenheit) {
        return (temperatureInFahrenheit - 32) * 0.55555;
    }

    private double poundsToGrams(double pounds) {
        return pounds * 0.0283 / 1000;
    }
}

class MeatDatabase {
    private final Map<String, Float> safeCookingTemperatures = new HashMap<>();
    private final Map<String, Integer> caloriesPerOunce = new HashMap<>();
    private final Map<String, Double> proteinPerOunce = new HashMap<>();

    public MeatDatabase() {
        safeCookingTemperatures.put("beef", 145f);
        safeCookingTemperatures.put("pork", 145f);
        safeCookingTemperatures.put("chicken", 165f);
        safeCookingTemperatures.put("turkey", 165f);

        caloriesPerOunce.put("beef", 71);
        caloriesPerOunce.put("pork", 69);
        caloriesPerOunce.put("chicken", 66);
        caloriesPerOunce.put("turkey", 38);

        proteinPerOunce.put("beef", 7.33);
        proteinPerOunce.put("pork", 7.67);
        proteinPerOunce.put("chicken", 8.57);
        proteinPerOunce.put("turkey", 8.5);
    }

    public double getSafeCookingTemperature(String meat) {
        return safeCookingTemperatures.getOrDefault(meat.toLowerCase(), 0.0F);
    }

    public int getCaloriesPerOunce(String meat) {
        return caloriesPerOunce.getOrDefault(meat.toLowerCase(), 0);
    }

    public double getProteinPerOunce(String meat) {
        return proteinPerOunce.getOrDefault(meat.toLowerCase(), 0.0);
    }
}

class Main {
    public static void main(String[] args) {
        Meat unknownBeef = new Meat("Beef");
        unknownBeef.loadData();

        MeatDetails beef = new MeatDetails("Beef");
        beef.loadData();

        MeatDetails chicken = new MeatDetails("Chicken");
        chicken.loadData();

        MeatDetails turkey = new MeatDetails("Turkey");
        turkey.loadData();
    }
}