<?php

namespace StructuralPatterns\Composite\WindowsFormsApplication\Leaves;

use StructuralPatterns\Composite\WindowsFormsApplication\Component\Control;

abstract class BaseControlLeaf extends Control
{
    public function __construct($name, $width, $height, $foreColor, $backColor)
    {
        parent::__construct($name, $width, $height, $foreColor, $backColor);
    }

    public function getControls(): array
    {
        return [];
    }

    public function add(Control $control): void
    {
        echo "Cannot add control to " . get_class($this) . PHP_EOL;
    }

    public function remove(Control $control): void
    {
        echo "Cannot remove control from " . get_class($this) . PHP_EOL;
    }

    public function getHierarchicalLevel($depthIndicator): string
    {
        return parent::getHierarchicalLevel($depthIndicator) . PHP_EOL;
    }
}
