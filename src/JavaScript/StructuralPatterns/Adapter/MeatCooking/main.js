class Meat {
    constructor(meatName) {
        this.meatName = meatName;
        this.safeCookingTemperatureInFahrenheit = 0;
        this.safeCookingTemperatureInCelsius = 0;
        this.caloriesPerOunce = 0;
        this.caloriesPerGram = 0;
        this.proteinPerOunce = 0;
        this.proteinPerGram = 0;
    }

    loadData() {
        console.log(`\nMeat: ${this.meatName} ${"-".repeat(7)}`);
    }
}

class MeatDetails extends Meat {
    constructor(meatName) {
        super(meatName);
        this.meatDatabase = new MeatDatabase();
    }

    loadData() {
        this.safeCookingTemperatureInFahrenheit = this.meatDatabase.getSafeCookingTemperature(this.meatName);
        this.safeCookingTemperatureInCelsius = this.fahrenheitToCelsius(this.safeCookingTemperatureInFahrenheit);
        this.caloriesPerOunce = this.meatDatabase.getCaloriesPerOunce(this.meatName);
        this.caloriesPerGram = this.poundsToGrams(this.caloriesPerOunce);
        this.proteinPerOunce = this.meatDatabase.getProteinPerOunce(this.meatName);
        this.proteinPerGram = this.poundsToGrams(this.proteinPerOunce);

        super.loadData();

        const meatDetails = [
            ` Safe Cooking Temperature (Fahrenheit) : ${this.safeCookingTemperatureInFahrenheit.toFixed(2)}`,
            ` Safe Cooking Temperature (Celsius) : ${this.safeCookingTemperatureInCelsius.toFixed(2)}`,
            ` Calories per Ounce: ${this.caloriesPerOunce.toFixed(2)}`,
            ` Calories per Gram: ${this.caloriesPerGram.toFixed(2)}`,
            ` Protein per Ounce: ${this.proteinPerOunce.toFixed(2)}`,
            ` Protein per gram: ${this.proteinPerGram.toFixed(2)}`
        ].join("\n");

        console.log(meatDetails);
    }

    fahrenheitToCelsius(temperatureInFahrenheit) {
        return (temperatureInFahrenheit - 32) * 0.55555;
    }

    poundsToGrams(pounds) {
        return pounds * 0.0283 / 1000;
    }
}

class MeatDatabase {
    getSafeCookingTemperature(meat) {
        switch (meat.toLowerCase()) {
            case "beef":
            case "pork":
                return 145;
            case "chicken":
            case "turkey":
                return 165;
            default:
                return 165;
        }
    }

    getCaloriesPerOunce(meat) {
        switch (meat.toLowerCase()) {
            case "beef":
                return 71;
            case "pork":
                return 69;
            case "chicken":
                return 66;
            case "turkey":
                return 38;
            default:
                return 0;
        }
    }

    getProteinPerOunce(meat) {
        switch (meat.toLowerCase()) {
            case "beef":
                return 7.33;
            case "pork":
                return 7.67;
            case "chicken":
                return 8.57;
            case "turkey":
                return 8.5;
            default:
                return 0;
        }
    }
}

const unknownBeef = new Meat("Beef");
unknownBeef.loadData();

const beef = new MeatDetails("Beef");
beef.loadData();

const chicken = new MeatDetails("Chicken");
chicken.loadData();

const turkey = new MeatDetails("Turkey");
turkey.loadData();