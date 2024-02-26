<?php

namespace CreationalPatterns\Builder\Laptops\Product;

class Laptop
{
    public string $model;
    public string $cpuSeries;
    public string $gpuModel;
    public string $ramType;
    public float $ramSize;
    public string $displayType;
    public string $ssdType;
    public float $ssdCapacity;
    public array $extras = [];

    public function showDetails(): void
    {
        $stringBuilder = str_repeat('-', 40) . PHP_EOL;
        $stringBuilder .= "Model: {$this->model}" . PHP_EOL;
        $stringBuilder .= "CPU Model: {$this->cpuSeries}" . PHP_EOL;
        $stringBuilder .= "GPU Model: {$this->gpuModel}" . PHP_EOL;
        $stringBuilder .= "RAM Type: {$this->ramType}" . PHP_EOL;
        $stringBuilder .= "RAM Size: {$this->ramSize} GB" . PHP_EOL;
        $stringBuilder .= "Display Type: {$this->displayType}" . PHP_EOL;
        $stringBuilder .= "SSD Type: {$this->ssdType}" . PHP_EOL;
        $stringBuilder .= "SSD Capacity: {$this->ssdCapacity} TB" . PHP_EOL;
        $stringBuilder .= "Extras: " . PHP_EOL;
        $stringBuilder .= implode(PHP_EOL, array_map(function ($e, $i) {
                return "Extra #" . ($i + 1) . ": $e";
            }, $this->extras, array_keys($this->extras))) . PHP_EOL;
        $stringBuilder .= str_repeat('-', 40) . PHP_EOL;
        echo $stringBuilder;
    }
}