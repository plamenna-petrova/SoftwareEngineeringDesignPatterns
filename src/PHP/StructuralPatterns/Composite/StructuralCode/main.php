<?php

abstract class Component
{
    protected string $name;

    public function __construct($name)
    {
        $this->name = $name;
    }

    public abstract function add(Component $component);

    public abstract function remove(Component $component);

    public abstract function display($depth);
}

class Composite extends Component
{
    private array $childComponents = array();

    public function __construct($name)
    {
        parent::__construct($name);
    }

    public function add(Component $component): void
    {
        $this->childComponents[] = $component;
    }

    public function remove(Component $component): void
    {
        $index = array_search($component, $this->childComponents);
        if ($index !== false) {
            unset($this->childComponents[$index]);
        }
    }

    public function display($depth): void
    {
        echo str_repeat('-', $depth) . $this->name . PHP_EOL;

        foreach ($this->childComponents as $childComponent) {
            $childComponent->display($depth + 2);
        }
    }
}

class Leaf extends Component
{
    public function __construct($name)
    {
        parent::__construct($name);
    }

    public function add(Component $component): void
    {
        echo "Cannot add to a leaf" . PHP_EOL;
    }

    public function remove(Component $component): void
    {
        echo "Cannot remove from a leaf" . PHP_EOL;
    }

    public function display($depth): void
    {
        echo str_repeat('-', $depth) . $this->name . PHP_EOL;
    }
}

$root = new Composite("root");
$root->add(new Leaf("Leaf A"));
$root->add(new Leaf("Leaf B"));

$composite = new Composite("Composite X");
$composite->add(new Leaf("Leaf XA"));
$composite->add(new Leaf("Leaf XB"));

$root->add($composite);
$root->add(new Leaf("Leaf C"));

$leaf = new Leaf("Leaf D");
$root->add($leaf);
$root->remove($leaf);

$root->display(1);
