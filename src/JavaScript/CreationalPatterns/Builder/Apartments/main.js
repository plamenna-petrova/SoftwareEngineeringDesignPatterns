
const WallType = {
    ModernWall: 'ModernWall',
    Plaster: 'Plaster',
    DryWall: 'DryWall'
};

const DoorType = {
    SlidingDoor: 'SlidingDoor',
    WoodDoor: 'WoodDoor',
    PaneledDoor: 'PaneledDoor'
};

const WindowType = {
    EndVentSlider: 'EndVentSlider',
    DoubleHung: 'DoubleHung',
    DoubleCasement: 'DoubleCasement'
};

const RoomNumber = {
    Five: 'Five',
    Four: 'Four',
    Three: 'Three'
};

const TerraceNumber = {
    Four: 'Four',
    One: 'One',
    Two: 'Two'
};

const InteriorAccessory = {
    Fireplace: 'Fireplace',
    HomeCinema: 'HomeCinema',
    Garden: 'Garden'
};

class ApartmentBuilder {
    buildWalls() { }

    buildDoors() { }

    buildWindows() { }

    buildRooms() { }

    buildTerraces() { }

    buildInteriorAccessories() { }

    get apartment() { }
}

class Apartment {
    constructor(apartmentType) {
        this.apartmentType = apartmentType;
    }

    toString() {
        return `Apartment Type: ${this.apartmentType}\n Wall Type: ${this.wall}\n Door Type: ${this.door}\n Window Type: ${this.window}\n Room Number: ${this.rooms}\n Terrace Number: ${this.terraces}\n Interior Accessories: ${this.interiorAccessory}`;
    }
}

class LuxuriousApartmentBuilder extends ApartmentBuilder {
    constructor() {
        super();
        this.apartment = new Apartment('Luxurious apartment');
    }

    buildDoors() {
        this.apartment.door = DoorType.SlidingDoor;
    }

    buildInteriorAccessories() {
        this.apartment.interiorAccessory = InteriorAccessory.Garden;
    }

    buildRooms() {
        this.apartment.rooms = RoomNumber.Five;
    }

    buildTerraces() {
        this.apartment.terraces = TerraceNumber.Four;
    }

    buildWalls() {
        this.apartment.wall = WallType.ModernWall;
    }

    buildWindows() {
        this.apartment.window = WindowType.DoubleCasement;
    }

    get apartment() {
        return this._apartment;
    }

    set apartment(value) {
        this._apartment = value;
    }
}

class ExpedientApartmentBuilder extends ApartmentBuilder {
    constructor() {
        super();
        this.apartment = new Apartment('Expedient apartment');
    }

    buildDoors() {
        this.apartment.door = DoorType.PaneledDoor;
    }

    buildInteriorAccessories() {
        this.apartment.interiorAccessory = InteriorAccessory.HomeCinema;
    }

    buildRooms() {
        this.apartment.rooms = RoomNumber.Four;
    }

    buildTerraces() {
        this.apartment.terraces = TerraceNumber.Two;
    }

    buildWalls() {
        this.apartment.wall = WallType.DryWall;
    }

    buildWindows() {
        this.apartment.window = WindowType.DoubleHung;
    }

    get apartment() {
        return this._apartment;
    }

    set apartment(value) {
        this._apartment = value;
    }
}

class CheapApartmentBuilder extends ApartmentBuilder {
    constructor() {
        super();
        this.apartment = new Apartment('Cheap Apartment');
    }

    buildDoors() {
        this.apartment.door = DoorType.WoodDoor;
    }

    buildInteriorAccessories() {
        this.apartment.interiorAccessory = InteriorAccessory.Fireplace;
    }

    buildRooms() {
        this.apartment.rooms = RoomNumber.Three;
    }

    buildTerraces() {
        this.apartment.terraces = TerraceNumber.One;
    }

    buildWalls() {
        this.apartment.wall = WallType.Plaster;
    }

    buildWindows() {
        this.apartment.window = WindowType.EndVentSlider;
    }

    get apartment() {
        return this._apartment;
    }

    set apartment(value) {
        this._apartment = value;
    }
}

class Architect {
    construct(apartmentBuilder) {
        apartmentBuilder.buildDoors();
        apartmentBuilder.buildInteriorAccessories();
        apartmentBuilder.buildRooms();
        apartmentBuilder.buildTerraces();
        apartmentBuilder.buildWalls();
        apartmentBuilder.buildWindows();
    }
}

const architect = new Architect();

let apartmentBuilder = new LuxuriousApartmentBuilder();
architect.construct(apartmentBuilder);
console.log(`Luxurious apartment built: ${apartmentBuilder.apartment.toString()}\n`);

apartmentBuilder = new ExpedientApartmentBuilder();
architect.construct(apartmentBuilder);
console.log(`Expedient apartment built: ${apartmentBuilder.apartment.toString()}\n`);

apartmentBuilder = new CheapApartmentBuilder();
architect.construct(apartmentBuilder);
console.log(`Cheap apartment built: ${apartmentBuilder.apartment.toString()}`);