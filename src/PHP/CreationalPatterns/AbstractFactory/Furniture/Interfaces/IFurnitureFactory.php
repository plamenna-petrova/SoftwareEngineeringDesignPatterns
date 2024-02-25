<?php

namespace CreationalPatterns\AbstractFactory\Furniture\Interfaces;

interface IFurnitureFactory {
    public function createCabinet(): IFurniture;
    public function createChair(): IFurniture;
    public function createDiningTable(): IFurniture;
}