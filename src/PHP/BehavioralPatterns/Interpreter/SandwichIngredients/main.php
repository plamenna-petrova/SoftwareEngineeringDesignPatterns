<?php

interface IExpression {
    public function interpret(Context $context);
}

interface ICondiment extends IExpression {}

interface IIngredient extends IExpression {}

class Context {
    public string $output = '';
}

class KetchupCondiment implements ICondiment {
    public function interpret(Context $context): void
    {
        $context->output .= " Ketchup ";
    }
}

class MayonnaiseCondiment implements ICondiment {
    public function interpret(Context $context): void
    {
        $context->output .= " Mayonnaise ";
    }
}

class MustardCondiment implements ICondiment {
    public function interpret(Context $context): void
    {
        $context->output .= " Mustard ";
    }
}

class CondimentsList implements IExpression {
    private array $condiments;

    public function __construct(array $condiments) {
        $this->condiments = $condiments;
    }

    public function interpret(Context $context): void
    {
        foreach ($this->condiments as $condiment) {
            $condiment->interpret($context);
        }
    }
}

class LettuceIngredient implements IIngredient {
    public function interpret(Context $context): void
    {
        $context->output .= " Lettuce ";
    }
}

class ChickenIngredient implements IIngredient {
    public function interpret(Context $context): void
    {
        $context->output .= " Chicken ";
    }
}

class IngredientsList implements IExpression {
    private array $ingredients;

    public function __construct(array $ingredients) {
        $this->ingredients = $ingredients;
    }

    public function interpret(Context $context): void
    {
        foreach ($this->ingredients as $ingredient) {
            $ingredient->interpret($context);
        }
    }
}

interface IBread extends IExpression {}

class WheatBread implements IBread {
    public function interpret(Context $context): void
    {
        $context->output .= " Wheat-Bread ";
    }
}

class WhiteBread implements IBread {
    public function interpret(Context $context): void
    {
        $context->output .= " White-Bread ";
    }
}

class Sandwich implements IExpression {
    private IBread $topBread;
    private CondimentsList $topCondiments;
    private IngredientsList $ingredients;
    private CondimentsList $bottomCondiments;
    private IBread $bottomBread;

    public function __construct(
        IBread $topBread,
        CondimentsList $topCondiments,
        IngredientsList $ingredients,
        CondimentsList $bottomCondiments,
        IBread $bottomBread
    ) {
        $this->topBread = $topBread;
        $this->topCondiments = $topCondiments;
        $this->ingredients = $ingredients;
        $this->bottomCondiments = $bottomCondiments;
        $this->bottomBread = $bottomBread;
    }

    public function interpret(Context $context): void
    {
        $context->output .= "|";
        $this->topBread->interpret($context);
        $context->output .= "|<--";
        $this->topCondiments->interpret($context);
        $context->output .= "-";
        $this->ingredients->interpret($context);
        $context->output .= "-";
        $this->bottomCondiments->interpret($context);
        $context->output .= "-->";
        $context->output .= "|";
        $this->bottomBread->interpret($context);
        $context->output .= "|";
        echo $context->output . "\n";
    }
}

$sandwich = new Sandwich(
    new WheatBread(),
    new CondimentsList([new MayonnaiseCondiment(), new MustardCondiment()]),
    new IngredientsList([new LettuceIngredient(), new ChickenIngredient()]),
    new CondimentsList([new KetchupCondiment()]),
    new WhiteBread()
);

$sandwich->interpret(new Context());

