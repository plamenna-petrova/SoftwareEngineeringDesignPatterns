<?php

interface IStar {
    public function printStar();
}

class WhiteDwarf implements IStar {
    public function printStar(): void
    {
        echo "Print white dwarf\n";
    }
}

class RedGiant implements IStar {
    public function printStar(): void
    {
        echo "Print red giant\n";
    }
}

class StarsFactory {
    private array $stars = [];

    public function getStar(string $starType): ?IStar {
        $star = null;

        if (array_key_exists($starType, $this->stars)) {
            $star = $this->stars[$starType];
        } else {
            if ($starType === "White Dwarf") {
                $star = new WhiteDwarf();
            } else {
                $star = new RedGiant();
            }
            $this->stars[$starType] = $star;
        }

        return $star;
    }

    public function getStarsCount(): int {
        return count($this->stars);
    }
}

$starsFactory = new StarsFactory();

$star = $starsFactory->getStar("White Dwarf");
$star->printStar();
$star = $starsFactory->getStar("White Dwarf");
$star->printStar();
$star = $starsFactory->getStar("White Dwarf");
$star->printStar();

echo "-------------------------------\n";

$star = $starsFactory->getStar("Red Giant");
$star->printStar();
$star = $starsFactory->getStar("Red Giant");
$star->printStar();
$star = $starsFactory->getStar("Red Giant");
$star->printStar();

echo "Get stars count : " . $starsFactory->getStarsCount() . "\n";
