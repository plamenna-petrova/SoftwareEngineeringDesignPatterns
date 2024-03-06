import java.util.HashMap;
import java.util.Map;

class Compound {
    protected float boilingPoint;
    protected float meltingPoint;
    protected double molecularWeight;
    protected String molecularFormula;

    public void display() {
        System.out.println("\nCompound: Unknown: -------");
    }
}

class RichCompound extends Compound {
    private final String chemical;

    public RichCompound(String chemical) {
        this.chemical = chemical;
    }

    @Override
    public void display() {
        ChemicalDatabank chemicalDatabank = new ChemicalDatabank();

        boilingPoint = chemicalDatabank.getCriticalPoint(chemical, "B");
        meltingPoint = chemicalDatabank.getCriticalPoint(chemical, "M");
        molecularWeight = chemicalDatabank.getMolecularWeight(chemical);
        molecularFormula = chemicalDatabank.getMolecularStructure(chemical);

        StringBuilder stringBuilder = new StringBuilder()
                .append(String.format("Compound :  %s %s%n", new String(new char[7]).replace('\0', '-'), chemical))
                .append(String.format(" Formula : %s%n", molecularFormula))
                .append(String.format(" Weight : %s%n", molecularWeight))
                .append(String.format(" Melting Point: %s%n", meltingPoint))
                .append(String.format(" Boiling Point: %s%n", boilingPoint));

        System.out.println(stringBuilder);
    }
}

class ChemicalDatabank {
    private final Map<String, Float> boilingPoints = new HashMap<>();
    private final Map<String, Float> meltingPoints = new HashMap<>();
    private final Map<String, String> molecularStructures = new HashMap<>();
    private final Map<String, Double> molecularWeights = new HashMap<>();

    public ChemicalDatabank() {
        boilingPoints.put("water", 100.0f);
        boilingPoints.put("benzene", 80.1f);
        boilingPoints.put("ethanol", 78.3f);

        meltingPoints.put("water", 0.0f);
        meltingPoints.put("benzene", 5.5f);
        meltingPoints.put("ethanol", -114.1f);

        molecularStructures.put("water", "H2O");
        molecularStructures.put("benzene", "C6H6");
        molecularStructures.put("ethanol", "C2H5OH");

        molecularWeights.put("water", 18.015);
        molecularWeights.put("benzene", 78.1134);
        molecularWeights.put("ethanol", 46.0688);
    }

    public float getCriticalPoint(String compound, String point) {
        return point.equals("B") ? boilingPoints.getOrDefault(compound.toLowerCase(), 0.0f) :
                meltingPoints.getOrDefault(compound.toLowerCase(), 0.0f);
    }

    public String getMolecularStructure(String compound) {
        return molecularStructures.getOrDefault(compound.toLowerCase(), "");
    }

    public double getMolecularWeight(String compound) {
        return molecularWeights.getOrDefault(compound.toLowerCase(), 0.0);
    }
}

public class Main {
    public static void main(String[] args) {
        Compound unknownCompound = new Compound();
        unknownCompound.display();

        System.out.println();

        Compound water = new RichCompound("Water");
        water.display();
        Compound benzene = new RichCompound("Benzene");
        benzene.display();
        Compound ethanol = new RichCompound("Ethanol");
        ethanol.display();
    }
}