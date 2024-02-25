import java.util.*;

enum WallType {
    ModernWall,
    Plaster,
    DryWall
}

enum DoorType {
    SlidingDoor,
    WoodDoor,
    PaneledDoor
}

enum WindowType {
    EndVentSlider,
    DoubleHung,
    DoubleCasement
}

enum RoomNumber {
    Five,
    Four,
    Three
}

enum TerraceNumber {
    Four,
    One,
    Two
}

enum InteriorAccessory {
    Fireplace,
    HomeCinema,
    Garden
}

interface IApartmentBuilder {
    void buildWalls();
    void buildDoors();
    void buildWindows();
    void buildRooms();
    void buildTerraces();
    void buildInteriorAccessories();
    Apartment getApartment();
}

class Apartment {
    private String apartmentType;
    private WallType wall;
    private DoorType door;
    private WindowType window;
    private RoomNumber rooms;
    private TerraceNumber terraces;
    private InteriorAccessory interiorAccessory;

    public Apartment(String apartmentType) {
        this.apartmentType = apartmentType;
    }

    public String getApartmentType() {
        return apartmentType;
    }

    public WallType getWall() {
        return wall;
    }

    public void setWall(WallType wall) {
        this.wall = wall;
    }

    public DoorType getDoor() {
        return door;
    }

    public void setDoor(DoorType door) {
        this.door = door;
    }

    public WindowType getWindow() {
        return window;
    }

    public void setWindow(WindowType window) {
        this.window = window;
    }

    public RoomNumber getRooms() {
        return rooms;
    }

    public void setRooms(RoomNumber rooms) {
        this.rooms = rooms;
    }

    public TerraceNumber getTerraces() {
        return terraces;
    }

    public void setTerraces(TerraceNumber terraces) {
        this.terraces = terraces;
    }

    public InteriorAccessory getInteriorAccessory() {
        return interiorAccessory;
    }

    public void setInteriorAccessory(InteriorAccessory interiorAccessory) {
        this.interiorAccessory = interiorAccessory;
    }

    @Override
    public String toString() {
        return String.format("Apartment Type: %s\nWall Type: %s\nDoor Type: %s\nWindow Type: %s\n" +
                        "Room Number: %s\nTerrace Number: %s\nInterior Accessories: %s\n",
                apartmentType, wall, door, window, rooms, terraces, interiorAccessory
        );
    }
}

class LuxuriousApartmentBuilder implements IApartmentBuilder {
    private Apartment apartment;

    public LuxuriousApartmentBuilder() {
        apartment = new Apartment("Luxurious apartment");
    }

    @Override
    public void buildDoors() {
        apartment.setDoor(DoorType.SlidingDoor);
    }

    @Override
    public void buildInteriorAccessories() {
        apartment.setInteriorAccessory(InteriorAccessory.Garden);
    }

    @Override
    public void buildRooms() {
        apartment.setRooms(RoomNumber.Five);
    }

    @Override
    public void buildTerraces() {
        apartment.setTerraces(TerraceNumber.Four);
    }

    @Override
    public void buildWalls() {
        apartment.setWall(WallType.ModernWall);
    }

    @Override
    public void buildWindows() {
        apartment.setWindow(WindowType.DoubleCasement);
    }

    @Override
    public Apartment getApartment() {
        return apartment;
    }
}

class ExpedientApartmentBuilder implements IApartmentBuilder {
    private Apartment apartment;

    public ExpedientApartmentBuilder() {
        apartment = new Apartment("Expedient apartment");
    }

    @Override
    public void buildDoors() {
        apartment.setDoor(DoorType.PaneledDoor);
    }

    @Override
    public void buildInteriorAccessories() {
        apartment.setInteriorAccessory(InteriorAccessory.HomeCinema);
    }

    @Override
    public void buildRooms() {
        apartment.setRooms(RoomNumber.Four);
    }

    @Override
    public void buildTerraces() {
        apartment.setTerraces(TerraceNumber.Two);
    }

    @Override
    public void buildWalls() {
        apartment.setWall(WallType.DryWall);
    }

    @Override
    public void buildWindows() {
        apartment.setWindow(WindowType.DoubleHung);
    }

    @Override
    public Apartment getApartment() {
        return apartment;
    }
}

class CheapApartmentBuilder implements IApartmentBuilder {
    private Apartment apartment;

    public CheapApartmentBuilder() {
        apartment = new Apartment("Cheap Apartment");
    }

    @Override
    public void buildDoors() {
        apartment.setDoor(DoorType.WoodDoor);
    }

    @Override
    public void buildInteriorAccessories() {
        apartment.setInteriorAccessory(InteriorAccessory.Fireplace);
    }

    @Override
    public void buildRooms() {
        apartment.setRooms(RoomNumber.Three);
    }

    @Override
    public void buildTerraces() {
        apartment.setTerraces(TerraceNumber.One);
    }

    @Override
    public void buildWalls() {
        apartment.setWall(WallType.Plaster);
    }

    @Override
    public void buildWindows() {
        apartment.setWindow(WindowType.EndVentSlider);
    }

    @Override
    public Apartment getApartment() {
        return apartment;
    }
}

class Architect {
    public void construct(IApartmentBuilder apartmentBuilder) {
        apartmentBuilder.buildDoors();
        apartmentBuilder.buildInteriorAccessories();
        apartmentBuilder.buildRooms();
        apartmentBuilder.buildTerraces();
        apartmentBuilder.buildWalls();
        apartmentBuilder.buildWindows();
    }
}

public class Main {
    public static void main(String[] args) {
        Architect architect = new Architect();

        IApartmentBuilder apartmentBuilder = new LuxuriousApartmentBuilder();
        architect.construct(apartmentBuilder);
        System.out.println("Luxurious apartment built: " + apartmentBuilder.getApartment().toString());

        apartmentBuilder = new ExpedientApartmentBuilder();
        architect.construct(apartmentBuilder);
        System.out.println("Expedient apartment built: " + apartmentBuilder.getApartment().toString());

        apartmentBuilder = new CheapApartmentBuilder();
        architect.construct(apartmentBuilder);
        System.out.println("Cheap apartment built: " + apartmentBuilder.getApartment().toString());
    }
}