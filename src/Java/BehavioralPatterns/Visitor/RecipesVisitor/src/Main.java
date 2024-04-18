import java.util.ArrayList;
import java.util.List;

interface IVisitor {
    void visitRecipe(Recipe recipe);
    void visitButter(Butter butter);
    void visitSalt(Salt salt);
    void visitFlour(Flour flour);
    void visitSugar(Sugar sugar);
}

class CaloriesCalculator implements IVisitor {
    private double totalCalories;

    public CaloriesCalculator() {
        totalCalories = 0;
    }

    public double getTotalCalories() {
        return totalCalories;
    }

    public void visitRecipe(Recipe recipe) {
        for (Ingredient ingredient : recipe.getIngredients()) {
            ingredient.accept(this);
        }
    }

    public void visitButter(Butter butter) {
        double calories = butter.getFatContent() * butter.getQuantity();
        totalCalories += calories;
    }

    public void visitSalt(Salt salt) {
        // No calorie calculation for salt
    }

    public void visitFlour(Flour flour) {
        double calories = switch (flour.getFlourType()) {
            case "All-Purpose" -> 3.64 * flour.getQuantity();
            case "Whole Wheat" -> 3.39 * flour.getQuantity();
            default -> 0;
        };

        totalCalories += calories;
    }

    public void visitSugar(Sugar sugar) {
        double calories = 4.0 * sugar.getSweetnessLevel() * sugar.getQuantity();
        totalCalories += calories;
    }
}

abstract class Element {
    public abstract void accept(IVisitor visitor);
}

abstract class Ingredient extends Element {
    private String name;
    private double quantity;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getQuantity() {
        return quantity;
    }

    public void setQuantity(double quantity) {
        this.quantity = quantity;
    }
}

class Butter extends Ingredient {
    private double fatContent;

    public double getFatContent() {
        return fatContent;
    }

    public void setFatContent(double fatContent) {
        this.fatContent = fatContent;
    }

    @Override
    public void accept(IVisitor visitor) {
        visitor.visitButter(this);
    }
}

class Salt extends Ingredient {
    private boolean isIodized;

    public boolean isIodized() {
        return isIodized;
    }

    public void setIodized(boolean iodized) {
        isIodized = iodized;
    }

    @Override
    public void accept(IVisitor visitor) {
        visitor.visitSalt(this);
    }
}

class Flour extends Ingredient {
    private String flourType;

    public String getFlourType() {
        return flourType;
    }

    public void setFlourType(String flourType) {
        System.out.println("Setting flour type: " + flourType);
        this.flourType = flourType;
    }

    @Override
    public void accept(IVisitor visitor) {
        visitor.visitFlour(this);
    }
}

class Sugar extends Ingredient {
    private double sweetnessLevel;

    public double getSweetnessLevel() {
        return sweetnessLevel;
    }

    public void setSweetnessLevel(double sweetnessLevel) {
        this.sweetnessLevel = sweetnessLevel;
    }

    @Override
    public void accept(IVisitor visitor) {
        visitor.visitSugar(this);
    }
}

class Recipe extends Element {
    private List<Ingredient> ingredients;

    public List<Ingredient> getIngredients() {
        return ingredients;
    }

    public void setIngredients(List<Ingredient> ingredients) {
        this.ingredients = ingredients;
    }

    @Override
    public void accept(IVisitor visitor) {
        visitor.visitRecipe(this);
    }
}

public class Main {
    public static void main(String[] args) {
        Recipe recipe = new Recipe();
        List<Ingredient> ingredients = new ArrayList<>();
        ingredients.add(new Butter());
        // Commenting out the addition of Salt
        // ingredients.add(new Salt());
        Flour flour = new Flour();
        flour.setFlourType("All-Purpose");
        ingredients.add(flour);
        ingredients.add(new Sugar());
        recipe.setIngredients(ingredients);

        CaloriesCalculator caloriesCalculator = new CaloriesCalculator();
        recipe.accept(caloriesCalculator);

        double totalCalories = caloriesCalculator.getTotalCalories();
        System.out.println(totalCalories);
    }
}