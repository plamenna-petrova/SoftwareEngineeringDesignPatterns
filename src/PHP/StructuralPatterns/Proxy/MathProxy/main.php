<?php

interface IMath {
    public function add($x, $y);
    public function sub($x, $y);
    public function mul($x, $y);
    public function div($x, $y);
}

class Math implements IMath {
    public function add($x, $y) { return $x + $y; }
    public function sub($x, $y) { return $x - $y; }
    public function mul($x, $y) { return $x * $y; }
    public function div($x, $y) { return $x / $y; }
}

class MathProxy implements IMath {
    private Math $math;

    public function __construct() {
        $this->math = new Math();
    }

    public function add($x, $y) { return $this->math->add($x, $y); }
    public function sub($x, $y) { return $this->math->sub($x, $y); }
    public function mul($x, $y) { return $this->math->mul($x, $y); }
    public function div($x, $y) { return $this->math->div($x, $y); }
}

$mathProxy = new MathProxy();

echo "4 + 2 = " . $mathProxy->add(4, 2) . "\n";
echo "4 - 2 = " . $mathProxy->sub(4, 2) . "\n";
echo "4 * 2 = " . $mathProxy->mul(4, 2) . "\n";
echo "4 / 2 = " . $mathProxy->div(4, 2) . "\n";
