<?php

namespace StructuralPatterns\Composite\WindowsFormsApplication\Leaves;

class Button extends BaseControlLeaf
{
    public function __construct($name, $width, $height, $foreColor, $backColor)
    {
        parent::__construct($name, $width, $height, $foreColor, $backColor);
    }
}