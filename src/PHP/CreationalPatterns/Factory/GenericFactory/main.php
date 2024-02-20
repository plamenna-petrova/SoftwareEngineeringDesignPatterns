<?php

class Alpha
{
    public string $description;
}

class Bravo
{
    public string $name;
}

class FactoryBase
{
    public function create() {
        return null;
    }
}

class AlphaFactory extends FactoryBase
{
    public function create(): Alpha
    {
        $alpha = new Alpha();
        $alpha->description = "Alpha Here";
        return $alpha;
    }
}

class BravoFactory extends FactoryBase
{
    public function create(): Bravo
    {
        $bravo = new Bravo();
        $bravo->name = "Bravo";
        return $bravo;
    }
}

class ServiceLocator
{
    public static function getFactory($type): AlphaFactory|BravoFactory
    {
        if ($type == "Alpha") {
            return new AlphaFactory();
        }

        if ($type == "Bravo") {
            return new BravoFactory();
        }

        throw new InvalidArgumentException("No factory defined for type $type");
    }
}

/*
    PHP does not have the concept of generics in the same way as C#. PHP is a dynamically typed language,
    and it uses type hinting to specify the type of variable or parameter. While PHP allows you to use a
    generic-like approach by using abstract classes or interfaces, it doesn't have native support for generics
    as found in languages like C# or Java.

    ===============================================================================================================================

    In the provided PHP code, a common base class (FactoryBase) is used for both Alpha and Bravo factories.
    This is a workaround to achieve a similar effect to generics, but it's not the same as C# generics.
    The actual type is determined at runtime, and dynamic typing and type hinting is used to ensure the correct usage of classes.
*/

$alphaFactory = ServiceLocator::getFactory("Alpha");
$alphaObject = $alphaFactory->create();
echo "Description: " . $alphaObject->description . PHP_EOL;

$bravoFactory = ServiceLocator::getFactory("Bravo");
$bravoObject = $bravoFactory->create();
echo "Name: " . $bravoObject->name . PHP_EOL;
