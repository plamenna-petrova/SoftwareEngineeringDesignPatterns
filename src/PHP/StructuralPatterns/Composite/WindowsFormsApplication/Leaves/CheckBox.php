<?php

namespace StructuralPatterns\Composite\WindowsFormsApplication\Leaves;

class CheckBox extends BaseControlLeaf
{
    public function __construct($name, $width, $height, $foreColor, $backColor)
    {
        parent::__construct($name, $width, $height, $foreColor, $backColor);
    }
}