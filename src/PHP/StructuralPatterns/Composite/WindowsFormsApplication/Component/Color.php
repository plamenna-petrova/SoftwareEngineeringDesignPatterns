<?php

namespace StructuralPatterns\Composite\WindowsFormsApplication\Component;

class Color
{
    public int $red;
    public int $green;
    public int $blue;

    public function __construct($red, $green, $blue)
    {
        $this->red = $red;
        $this->green = $green;
        $this->blue = $blue;
    }
}