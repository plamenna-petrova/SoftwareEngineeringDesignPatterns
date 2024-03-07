<?php

namespace StructuralPatterns\Composite\WindowsFormsApplication\Composites;

class Form extends BaseControlComposite
{
    public function __construct($name, $width, $height, $foreColor, $backColor)
    {
        parent::__construct($name, $width, $height, $foreColor, $backColor);
    }
}