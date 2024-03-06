<?php

class Compound {
    protected $boilingPoint;
    protected $meltingPoint;
    protected $molecularWeight;
    protected $molecularFormula;

    public function display(): void
    {
        echo "\nCompound: Unknown: -------\n";
    }
}

class RichCompound extends Compound {
    private string $chemical;

    public function __construct($chemical) {
        $this->chemical = $chemical;
    }

    public function display(): void
    {
        $chemicalDatabank = new ChemicalDatabank();

        $this->boilingPoint = $chemicalDatabank->getCriticalPoint($this->chemical, "B");
        $this->meltingPoint = $chemicalDatabank->getCriticalPoint($this->chemical, "M");
        $this->molecularWeight = $chemicalDatabank->getMolecularWeight($this->chemical);
        $this->molecularFormula = $chemicalDatabank->getMolecularStructure($this->chemical);

        echo "Compound :  " . str_repeat('-', 7) . " {$this->chemical}" . PHP_EOL;
        echo " Formula : {$this->molecularFormula}" . PHP_EOL;
        echo " Weight : {$this->molecularWeight}" . PHP_EOL;
        echo " Melting Point: {$this->meltingPoint}" . PHP_EOL;
        echo " Boiling Point: {$this->boilingPoint}" . PHP_EOL;
        echo PHP_EOL;
    }
}

class ChemicalDatabank {
    public function getCriticalPoint($compound, $point): float|int
    {
        $criticalPoint = 0;

        switch ($point) {
            case "B":
                $criticalPoint = match (strtolower($compound)) {
                    "water" => 100.0,
                    "benzene" => 80.1,
                    "ethanol" => 78.3,
                    default => 0,
                };
                break;
            case "M":
                $criticalPoint = match (strtolower($compound)) {
                    "water" => 0.0,
                    "benzene" => 5.5,
                    "ethanol" => -114.1,
                    default => 0,
                };
                break;
        }

        return $criticalPoint;
    }

    public function getMolecularStructure($compound): string
    {
        return match (strtolower($compound)) {
            "water" => "H20",
            "benzene" => "C6H6",
            "ethanol" => "C2H50H",
            default => "",
        };
    }

    public function getMolecularWeight($compound): float|int
    {
        return match (strtolower($compound)) {
            "water" => 18.015,
            "benzene" => 78.1134,
            "ethanol" => 46.0688,
            default => 0,
        };
    }
}

$unknownCompound = new Compound();
$unknownCompound->display();

echo PHP_EOL;

$water = new RichCompound("Water");
$water->display();
$benzene = new RichCompound("Benzene");
$benzene->display();
$ethanol = new RichCompound("Ethanol");
$ethanol->display();