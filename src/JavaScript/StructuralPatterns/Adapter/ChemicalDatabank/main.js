
class Compound {
    constructor() {
        this.boilingPoint = 0;
        this.meltingPoint = 0;
        this.molecularWeight = 0;
        this.molecularFormula = "";
    }

    display() {
        console.log("\nCompound: Unknown: -------");
    }
}

class RichCompound extends Compound {
    constructor(chemical) {
        super();
        this.chemical = chemical;
        this.chemicalDatabank = new ChemicalDatabank();
    }

    display() {
        this.boilingPoint = this.chemicalDatabank.getCriticalPoint(this.chemical, "B");
        this.meltingPoint = this.chemicalDatabank.getCriticalPoint(this.chemical, "M");
        this.molecularWeight = this.chemicalDatabank.getMolecularWeight(this.chemical);
        this.molecularFormula = this.chemicalDatabank.getMolecularStructure(this.chemical);

        const richCompoundDetails = [
            `Compound :  ${"-".repeat(7)} ${this.chemical}`,
            ` Formula : ${this.molecularFormula}`,
            ` Weight : ${this.molecularWeight}`,
            ` Melting Point: ${this.meltingPoint}`,
            ` Boiling Point: ${this.boilingPoint}\n`
        ];

        console.log(richCompoundDetails.join("\n"));
    }
}

class ChemicalDatabank {
    getCriticalPoint(compound, point) {
        let criticalPoint = 0;

        switch (point) {
            case "B":
                criticalPoint = (compound.toLowerCase() === "water") ? 100.0 :
                                (compound.toLowerCase() === "benzene") ? 80.1 :
                                (compound.toLowerCase() === "ethanol") ? 78.3 : 0;
                break;
            case "M":
                criticalPoint = (compound.toLowerCase() === "water") ? 0.0 :
                                (compound.toLowerCase() === "benzene") ? 5.5 :
                                (compound.toLowerCase() === "ethanol") ? -114.1 : 0;
                break;
            default:
                break;
        }

        return criticalPoint;
    }

    getMolecularStructure(compound) {
        return compound.toLowerCase() === "water" ? "H20" :
               compound.toLowerCase() === "benzene" ? "C6H6" :
               compound.toLowerCase() === "ethanol" ? "C2H50H" : "";
    }

    getMolecularWeight(compound) {
        return compound.toLowerCase() === "water" ? 18.015 :
               compound.toLowerCase() === "benzene" ? 78.1134 :
               compound.toLowerCase() === "ethanol" ? 46.0688 : 0;
    }
}

const unknownCompound = new Compound();
unknownCompound.display();

console.log();

const water = new RichCompound("Water");
water.display();
const benzene = new RichCompound("Benzene");
benzene.display();
const ethanol = new RichCompound("Ethanol");
ethanol.display();