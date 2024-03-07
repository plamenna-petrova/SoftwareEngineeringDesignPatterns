<?php

namespace StructuralPatterns\Composite\WindowsFormsApplication\Composites;

use InvalidArgumentException;
use StructuralPatterns\Composite\WindowsFormsApplication\Component\Control;

abstract class BaseControlComposite extends Control
{
    protected array $controls = array();

    public function __construct($name, $width, $height, $foreColor, $backColor)
    {
        parent::__construct($name, $width, $height, $foreColor, $backColor);
    }

    public function getControls(): array
    {
        return $this->controls ?? [];
    }

    public function add(Control $control): void
    {
        $this->controls[] = $control;
    }

    public function remove(Control $control): void
    {
        $index = array_search($control, $this->controls, true);

        if ($index !== false) {
            unset($this->controls[$index]);
        } else {
            throw new InvalidArgumentException("Control not found.");
        }
    }

    public function getHierarchicalLevel(int $depthIndicator): string
    {
        $controlHierarchicalInfo = sprintf(
            "%s+ Name: %s, Width: %d, Fore Color: (%d, %d, %d), Back Color: (%d, %d, %d)\r\n",
            str_repeat('-', $depthIndicator),
            $this->getName(),
            $this->getWidth(),
            $this->getForeColor()->red,
            $this->getForeColor()->green,
            $this->getForeColor()->blue,
            $this->getBackColor()->red,
            $this->getBackColor()->green,
            $this->getBackColor()->blue
        );

        foreach ($this->getControls() as $control) {
            $controlHierarchicalInfo .= rtrim($control->getHierarchicalLevel($depthIndicator + 2), "\r\n") . "\r\n";
        }

        return $controlHierarchicalInfo;
    }
}