<?php

class WallType {
    const ModernWall = 'ModernWall';
    const Plaster = 'Plaster';
    const DryWall = 'DryWall';
}

class DoorType {
    const SlidingDoor = 'SlidingDoor';
    const WoodDoor = 'WoodDoor';
    const PaneledDoor = 'PaneledDoor';
}

class WindowType {
    const EndVentSlider = 'EndVentSlider';
    const DoubleHung = 'DoubleHung';
    const DoubleCasement = 'DoubleCasement';
}

class RoomNumber {
    const Five = 'Five';
    const Four = 'Four';
    const Three = 'Three';
}

class TerraceNumber {
    const Four = 'Four';
    const One = 'One';
    const Two = 'Two';
}

class InteriorAccessory {
    const Fireplace = 'Fireplace';
    const HomeCinema = 'HomeCinema';
    const Garden = 'Garden';
}

class Apartment {
    public string $apartmentType;
    public string $wall;
    public string $door;
    public string $window;
    public string $rooms;
    public string $terraces;
    public string $interiorAccessory;

    public function __construct(string $apartmentType) {
        $this->apartmentType = $apartmentType;
    }

    public function __toString(): string {
        return sprintf("Apartment Type: %s\n Wall Type: %s\n Door Type: %s\n Window Type: %s\n Room Number: %s\n Terrace Number: %s\n Interior Accessories: %s\n",
            $this->apartmentType, $this->wall, $this->door, $this->window, $this->rooms, $this->terraces, $this->interiorAccessory
        );
    }
}

interface IApartmentBuilder {
    public function buildWalls();
    public function buildDoors();
    public function buildWindows();
    public function buildRooms();
    public function buildTerraces();
    public function buildInteriorAccessories();
    public function getApartment(): Apartment;
}

class LuxuriousApartmentBuilder implements IApartmentBuilder {
    private Apartment $apartment;

    public function __construct() {
        $this->apartment = new Apartment("Luxurious apartment");
    }

    public function buildDoors(): void
    {
        $this->apartment->door = DoorType::SlidingDoor;
    }

    public function buildInteriorAccessories(): void
    {
        $this->apartment->interiorAccessory = InteriorAccessory::Garden;
    }

    public function buildRooms(): void
    {
        $this->apartment->rooms = RoomNumber::Five;
    }

    public function buildTerraces(): void
    {
        $this->apartment->terraces = TerraceNumber::Four;
    }

    public function buildWalls(): void
    {
        $this->apartment->wall = WallType::ModernWall;
    }

    public function buildWindows(): void
    {
        $this->apartment->window = WindowType::DoubleCasement;
    }

    public function getApartment(): Apartment {
        return $this->apartment;
    }
}

class ExpedientApartmentBuilder implements IApartmentBuilder {
    private Apartment $apartment;

    public function __construct() {
        $this->apartment = new Apartment("Expedient apartment");
    }

    public function buildDoors(): void
    {
        $this->apartment->door = DoorType::PaneledDoor;
    }

    public function buildInteriorAccessories(): void
    {
        $this->apartment->interiorAccessory = InteriorAccessory::HomeCinema;
    }

    public function buildRooms(): void
    {
        $this->apartment->rooms = RoomNumber::Four;
    }

    public function buildTerraces(): void
    {
        $this->apartment->terraces = TerraceNumber::Two;
    }

    public function buildWalls(): void
    {
        $this->apartment->wall = WallType::DryWall;
    }

    public function buildWindows(): void
    {
        $this->apartment->window = WindowType::DoubleHung;
    }

    public function getApartment(): Apartment {
        return $this->apartment;
    }
}

class CheapApartmentBuilder implements IApartmentBuilder {
    private Apartment $apartment;

    public function __construct() {
        $this->apartment = new Apartment("Cheap Apartment");
    }

    public function buildDoors(): void
    {
        $this->apartment->door = DoorType::WoodDoor;
    }

    public function buildInteriorAccessories(): void
    {
        $this->apartment->interiorAccessory = InteriorAccessory::Fireplace;
    }

    public function buildRooms(): void
    {
        $this->apartment->rooms = RoomNumber::Three;
    }

    public function buildTerraces(): void
    {
        $this->apartment->terraces = TerraceNumber::One;
    }

    public function buildWalls(): void
    {
        $this->apartment->wall = WallType::Plaster;
    }

    public function buildWindows(): void
    {
        $this->apartment->window = WindowType::EndVentSlider;
    }

    public function getApartment(): Apartment {
        return $this->apartment;
    }
}

class Architect {
    public function construct(IApartmentBuilder $apartmentBuilder): void
    {
        $apartmentBuilder->buildDoors();
        $apartmentBuilder->buildInteriorAccessories();
        $apartmentBuilder->buildRooms();
        $apartmentBuilder->buildTerraces();
        $apartmentBuilder->buildWalls();
        $apartmentBuilder->buildWindows();
    }
}

$architect = new Architect();

$apartmentBuilder = new LuxuriousApartmentBuilder();
$architect->construct($apartmentBuilder);
echo "Luxurious apartment built:\n", $apartmentBuilder->getApartment();
echo PHP_EOL;

$apartmentBuilder = new ExpedientApartmentBuilder();
$architect->construct($apartmentBuilder);
echo "Expedient apartment built:", $apartmentBuilder->getApartment();
echo PHP_EOL;

$apartmentBuilder = new CheapApartmentBuilder();
$architect->construct($apartmentBuilder);
echo "Cheap apartment built:\n", $apartmentBuilder->getApartment();