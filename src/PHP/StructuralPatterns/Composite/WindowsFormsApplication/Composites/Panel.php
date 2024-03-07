<?php

namespace StructuralPatterns\Composite\WindowsFormsApplication\Composites;

class Panel extends BaseControlComposite
{
    public function __construct($name, $width, $height, $foreColor, $backColor)
    {
        parent::__construct($name, $width, $height, $foreColor, $backColor);
    }
}