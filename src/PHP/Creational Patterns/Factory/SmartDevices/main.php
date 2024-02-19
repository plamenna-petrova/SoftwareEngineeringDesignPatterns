<?php

abstract class SmartDevice
{
    public abstract function setPrice($price);
    public abstract function getPrice();

    public array $characteristics = [];

    public function __toString()
    {
        return get_class($this) . "'s Details:\nPrice: " . $this->getPrice() . "\nCharacteristics: " . implode(", ", $this->characteristics);
    }
}

class SamsungGalaxyS23Ultra extends SmartDevice
{
    private float $price = 1970.00;

    public function setPrice($price): void
    {
        $this->price = $price;
    }

    public function getPrice(): float
    {
        return $this->price;
    }
}

class XiaomiRedmiNote12Pro extends SmartDevice
{
    private float $price = 630.00;

    public function setPrice($price): void
    {
        $this->price = $price;
    }

    public function getPrice(): float
    {
        return $this->price;
    }
}

class IPhone12ProMax extends SmartDevice
{
    private float $price = 1470.00;

    public function setPrice($price): void
    {
        $this->price = $price;
    }

    public function getPrice(): float
    {
        return $this->price;
    }
}

class GalaxyWatchClassic extends SmartDevice
{
    private float $price = 760.00;

    public function setPrice($price): void
    {
        $this->price = $price;
    }

    public function getPrice(): float
    {
        return $this->price;
    }
}

class XiaomiWatch2Pro extends SmartDevice
{
    private float $price = 620.00;

    public function setPrice($price): void
    {
        $this->price = $price;
    }

    public function getPrice(): float
    {
        return $this->price;
    }
}

class AppleWatchUltra2 extends SmartDevice
{
    private float $price = 830.00;

    public function setPrice($price): void
    {
        $this->price = $price;
    }

    public function getPrice(): float
    {
        return $this->price;
    }
}

class GalaxyBuds2Pro extends SmartDevice
{
    private float $price = 470.00;

    public function setPrice($price): void
    {
        $this->price = $price;
    }

    public function getPrice(): float
    {
        return $this->price;
    }
}

class RedmiAirdotsBasic2 extends SmartDevice
{
    private float $price = 267.00;

    public function setPrice($price): void
    {
        $this->price = $price;
    }

    public function getPrice(): float
    {
        return $this->price;
    }
}

class AirPods extends SmartDevice
{
    private float $price = 950.00;

    public function setPrice($price): void
    {
        $this->price = $price;
    }

    public function getPrice(): float
    {
        return $this->price;
    }
}

class SmartDeviceBrand
{
    const Samsung = 0;
    const Xiaomi = 1;
    const Apple = 2;
}

interface ISmartDeviceCreator
{
    public function createSmartDevice(int $smartDeviceBrand);
}

class SmartPhoneCreator implements ISmartDeviceCreator
{
    public function createSmartDevice(int $smartDeviceBrand): SmartDevice
    {
        return match ($smartDeviceBrand) {
            SmartDeviceBrand::Samsung => new SamsungGalaxyS23Ultra(),
            SmartDeviceBrand::Xiaomi => new XiaomiRedmiNote12Pro(),
            SmartDeviceBrand::Apple => new IPhone12ProMax(),
            default => null,
        };
    }
}

class SmartWatchCreator implements ISmartDeviceCreator
{
    public function createSmartDevice(int $smartDeviceBrand): SmartDevice
    {
        return match ($smartDeviceBrand) {
            SmartDeviceBrand::Samsung => new GalaxyWatchClassic(),
            SmartDeviceBrand::Xiaomi => new XiaomiWatch2Pro(),
            SmartDeviceBrand::Apple => new AppleWatchUltra2(),
            default => null,
        };
    }
}

class EarbudsCreator implements ISmartDeviceCreator
{
    public function createSmartDevice(int $smartDeviceBrand): SmartDevice
    {
        return match ($smartDeviceBrand) {
            SmartDeviceBrand::Samsung => new GalaxyBuds2Pro(),
            SmartDeviceBrand::Xiaomi => new RedmiAirdotsBasic2(),
            SmartDeviceBrand::Apple => new AirPods(),
            default => null,
        };
    }
}

$smartDeviceCreators = [
    new SmartPhoneCreator(),
    new SmartWatchCreator(),
    new EarbudsCreator(),
];

echo "Enter Smart Device Type - Smart Phone, Smart Watch or Earbuds: ";
$smartDeviceType = trim(fgets(STDIN));

while ($smartDeviceType !== "END") {
    $targetSmartDeviceCreator = null;

    foreach ($smartDeviceCreators as $smartDeviceCreator) {
        if (str_starts_with(get_class($smartDeviceCreator), implode('', explode(' ', $smartDeviceType)))) {
            $targetSmartDeviceCreator = $smartDeviceCreator;
            break;
        }
    }

    while ($targetSmartDeviceCreator === null) {
        echo "Enter valid smart device type: ";
        $smartDeviceType = trim(fgets(STDIN));

        foreach ($smartDeviceCreators as $smartDeviceCreator) {
            if (str_starts_with(get_class($smartDeviceCreator), implode('', explode(' ', $smartDeviceType)))) {
                $targetSmartDeviceCreator = $smartDeviceCreator;
                break;
            }
        }
    }

    echo "Enter Smart Device Brand - Samsung, Xiaomi, or Apple: ";
    $smartDeviceBrandInput = trim(fgets(STDIN));

    $smartDeviceBrand = null;

    $smartDeviceBrandReflectionClass = new ReflectionClass(SmartDeviceBrand::class);
    $smartDeviceBrandReflectionClassConstants = $smartDeviceBrandReflectionClass->getConstants();
    $smartDeviceBrandReflectionClassConstantsNames = array_keys($smartDeviceBrandReflectionClassConstants);

    while (!in_array($smartDeviceBrandInput, $smartDeviceBrandReflectionClassConstantsNames)) {
        echo "Enter valid smart device brand: ";
        $smartDeviceBrandInput = trim(fgets(STDIN));
    }

    $smartDeviceBrand = $smartDeviceBrandReflectionClassConstants[$smartDeviceBrandInput];
    $smartDevice = $targetSmartDeviceCreator->createSmartDevice($smartDeviceBrand);

    echo "Enter device characteristics for " . get_class($smartDevice) . " separated by '|' :" . PHP_EOL;
    $smartDeviceCharacteristics = explode('|', trim(fgets(STDIN)));
    $smartDeviceCharacteristics = array_map('trim', $smartDeviceCharacteristics);
    $smartDeviceCharacteristics = array_filter($smartDeviceCharacteristics); // Remove empty elements
    $smartDeviceCharacteristics = array_values($smartDeviceCharacteristics);

    $smartDevice->characteristics = $smartDeviceCharacteristics;

    echo $smartDevice . PHP_EOL;
    echo str_repeat('=', 80) . PHP_EOL;

    echo "Enter Smart Device Type - Smart Phone, Smart Watch or Earbuds : ";
    $smartDeviceType = trim(fgets(STDIN));
}

