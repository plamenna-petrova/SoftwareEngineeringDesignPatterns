<?php

abstract class DrawingElement
{
    protected string $name;

    public function __construct($name)
    {
        $this->name = $name;
    }

    public abstract function add(DrawingElement $drawingElement);

    public abstract function remove(DrawingElement $drawingElement);

    public abstract function display($indent);
}

class CompositeElement extends DrawingElement
{
    private array $drawingElements = array();

    public function __construct($name)
    {
        parent::__construct($name);
    }

    public function add(DrawingElement $drawingElement): void
    {
        $this->drawingElements[] = $drawingElement;
    }

    public function remove(DrawingElement $drawingElement): void
    {
        $index = array_search($drawingElement, $this->drawingElements);
        if ($index !== false) {
            unset($this->drawingElements[$index]);
        }
    }

    public function display($indent): void
    {
        echo str_repeat('-', $indent) . '+ ' . $this->name . PHP_EOL;

        foreach ($this->drawingElements as $drawingElement) {
            $drawingElement->display($indent + 2);
        }
    }
}

class PrimitiveElement extends DrawingElement
{
    public function __construct($name)
    {
        parent::__construct($name);
    }

    public function add(DrawingElement $drawingElement): void
    {
        echo "Cannot add to a primitive element" . PHP_EOL;
    }

    public function remove(DrawingElement $drawingElement): void
    {
        echo "Cannot remove from a primitive element" . PHP_EOL;
    }

    public function display($indent): void
    {
        echo str_repeat('-', $indent) . ' ' . $this->name . PHP_EOL;
    }
}

$canvas = new CompositeElement("Canvas");
$canvas->add(new PrimitiveElement("Red Line"));
$canvas->add(new PrimitiveElement("Blue Circle"));
$canvas->add(new PrimitiveElement("Green Box"));

$compositeElement = new CompositeElement("Two Circles");
$compositeElement->add(new PrimitiveElement("Black Circle"));
$compositeElement->add(new PrimitiveElement("White Circle"));
$canvas->add($compositeElement);

$primitiveElement = new PrimitiveElement("Orange Line");
$canvas->add($primitiveElement);
$canvas->remove($primitiveElement);

$canvas->display(1);