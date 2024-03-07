<?php

namespace StructuralPatterns\Composite\WindowsFormsApplication\Leaves;

class ComboBox extends BaseControlLeaf
{
    public function __construct($name, $width, $height, $foreColor, $backColor)
    {
        parent::__construct($name, $width, $height, $foreColor, $backColor);
    }
}