<?php

interface Shape {
    public function draw();
}

class Circle implements Shape {
    private int $xCoordinate = 10;
    private int $yCoordinate = 20;
    private int $radius = 30;
    private string $color;

    public function setColor(string $color): void {
        $this->color = $color;
    }

    public function draw(): void {
        echo " Circle: Draw() [Color : $this->color, X Coordinate : $this->xCoordinate Y Coordinate : $this->yCoordinate, Radius : $this->radius ]\n";
    }
}

class ShapeFactory {
    private static array $shapes = [];

    public static function getShape(string $shapeType): ?Shape {
        $shape = null;

        if (strcasecmp($shapeType, "circle") === 0) {
            if (!array_key_exists("circle", self::$shapes)) {
                $shape = new Circle();
                self::$shapes["circle"] = $shape;
                echo " Creating circle object with out any color in shape factory \n";
            } else {
                $shape = self::$shapes["circle"];
            }
        }

        return $shape;
    }
}

echo "\n Red color Circles \n";

for ($i = 0; $i < 3; $i++) {
    $circle = ShapeFactory::getShape("circle");
    $circle->setColor("Red");
    $circle->draw();
}

echo "\n Green color Circles \n";

for ($i = 0; $i < 3; $i++) {
    $circle = ShapeFactory::getShape("circle");
    $circle->setColor("Green");
    $circle->draw();
}

echo "\n Blue color Circles \n";

for ($i = 0; $i < 3; ++$i) {
    $circle = ShapeFactory::getShape("circle");
    $circle->setColor("Green");
    $circle->draw();
}

echo "\n Orange color Circles \n";

for ($i = 0; $i < 3; ++$i) {
    $circle = ShapeFactory::getShape("circle");
    $circle->setColor("Orange");
    $circle->draw();
}

echo "\n Black color Circles \n";

for ($i = 0; $i < 3; ++$i) {
    $circle = ShapeFactory::getShape("circle");
    $circle->setColor("Black");
    $circle->draw();
}