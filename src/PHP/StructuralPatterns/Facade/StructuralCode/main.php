<?php

class SubSystemOne {
    public function methodOne(): void
    {
        echo " SubSystemOne Method\n";
    }
}

class SubSystemTwo {
    public function methodTwo(): void
    {
        echo " SubSystemTwo Method\n";
    }
}

class SubSystemThree {
    public function methodThree(): void
    {
        echo " SubSystemThree Method\n";
    }
}

class SubSystemFour {
    public function methodFour(): void
    {
        echo " SubSystemFour Method\n";
    }
}

class Facade {
    private SubSystemOne $subSystemOne;
    private SubSystemTwo $subSystemTwo;
    private SubSystemThree $subSystemThree;
    private SubSystemFour $subSystemFour;

    public function __construct() {
        $this->subSystemOne = new SubSystemOne();
        $this->subSystemTwo = new SubSystemTwo();
        $this->subSystemThree = new SubSystemThree();
        $this->subSystemFour = new SubSystemFour();
    }

    public function methodA(): void
    {
        echo "\nMethodA() ---- \n";
        $this->subSystemOne->methodOne();
        $this->subSystemTwo->methodTwo();
        $this->subSystemFour->methodFour();
    }

    public function methodB(): void
    {
        echo "\nMethodB() ---- \n";
        $this->subSystemTwo->methodTwo();
        $this->subSystemThree->methodThree();
    }
}

$facade = new Facade();
$facade->methodA();
$facade->methodB();