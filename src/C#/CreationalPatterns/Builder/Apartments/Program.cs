using System;

namespace Apartments
{
    public enum WallType
    {
        ModernWall,
        Plaster,
        DryWall
    }

    public enum DoorType
    {
        SlidingDoor,
        WoodDoor,
        PaneledDoor
    }

    public enum WindowType
    {
        EndVentSlider,
        DoubleHung,
        DoubleCasement
    }

    public enum RoomNumber
    {
        Five,
        Four,
        Three
    }

    public enum TerraceNumber
    {
        Four,
        One,
        Two
    }

    public enum InteriorAccessory
    {
        Fireplace,
        HomeCinema,
        Garden
    }

    public interface IApartmentBuilder
    {
        void BuildWalls();

        void BuildDoors();

        void BuildWindows();

        void BuildRooms();

        void BuildTerraces();

        void BuildInteriorAccessories();

        Apartment Apartment { get; }
    }

    public class Apartment
    {
        public Apartment(string apartmentType)
        {
            ApartmentType = apartmentType;
        }

        public string ApartmentType { get; set; }

        public WallType Wall { get; set; }

        public DoorType Door { get; set; }

        public WindowType Window { get; set; }

        public RoomNumber Rooms { get; set; }

        public TerraceNumber Terraces { get; set; }

        public InteriorAccessory InteriorAccessory { get; set; }

        public override string ToString()
        {
            return string.Format("Apartment Type : {0}\n Wall Type : {1}\n Door Type : {2}\n Window Type : " +
                "{3}\n Room Number : {4}\n Terrace Number : {5}\n Interior Accessories : {6}\n", 
                ApartmentType, Wall, Door, Window, Rooms, Terraces, InteriorAccessory
            );
        }
    }

    public class LuxuriousApartmentBuilder : IApartmentBuilder
    {
        public LuxuriousApartmentBuilder()
        {
            Apartment = new Apartment("Luxurious apartment");
        }

        public Apartment Apartment { get; set; }

        public void BuildDoors()
        {
            Apartment.Door = DoorType.SlidingDoor;
        }

        public void BuildInteriorAccessories()
        {
            Apartment.InteriorAccessory = InteriorAccessory.Garden;
        }

        public void BuildRooms()
        {
            Apartment.Rooms = RoomNumber.Five;
        }

        public void BuildTerraces()
        {
            Apartment.Terraces = TerraceNumber.Four;
        }

        public void BuildWalls()
        {
            Apartment.Wall = WallType.ModernWall;
        }

        public void BuildWindows()
        {
            Apartment.Window = WindowType.DoubleCasement;
        }
    }

    public class ExpedientApartmentBuilder : IApartmentBuilder
    {
        public ExpedientApartmentBuilder()
        {
            Apartment = new Apartment("Expedient apartment");
        }

        public Apartment Apartment { get; set; }

        public void BuildDoors()
        {
            Apartment.Door = DoorType.PaneledDoor;
        }

        public void BuildInteriorAccessories()
        {
            Apartment.InteriorAccessory = InteriorAccessory.HomeCinema;
        }

        public void BuildRooms()
        {
            Apartment.Rooms = RoomNumber.Four;
        }

        public void BuildTerraces()
        {
            Apartment.Terraces = TerraceNumber.Two;
        }

        public void BuildWalls()
        {
            Apartment.Wall = WallType.DryWall;
        }

        public void BuildWindows()
        {
            Apartment.Window = WindowType.DoubleHung;
        }
    }

    public class CheapApartmentBuilder : IApartmentBuilder
    {
        public CheapApartmentBuilder()
        {
            Apartment = new Apartment("Cheap Apartment");
        }

        public Apartment Apartment { get; set; }

        public void BuildDoors()
        {
            Apartment.Door = DoorType.WoodDoor;
        }

        public void BuildInteriorAccessories()
        {
            Apartment.InteriorAccessory = InteriorAccessory.Fireplace;
        }

        public void BuildRooms()
        {
            Apartment.Rooms = RoomNumber.Three;
        }

        public void BuildTerraces()
        {
            Apartment.Terraces = TerraceNumber.One;
        }

        public void BuildWalls()
        {
            Apartment.Wall = WallType.Plaster;
        }

        public void BuildWindows()
        {
            Apartment.Window = WindowType.EndVentSlider;
        }
    }

    public class Architect
    {
        public void Construct(IApartmentBuilder apartmentBuilder)
        {
            apartmentBuilder.BuildDoors();
            apartmentBuilder.BuildInteriorAccessories();
            apartmentBuilder.BuildRooms();
            apartmentBuilder.BuildTerraces();
            apartmentBuilder.BuildWalls();
            apartmentBuilder.BuildWindows();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Architect architect = new Architect();

            IApartmentBuilder apartmentBuilder = new LuxuriousApartmentBuilder();
            architect.Construct(apartmentBuilder);
            Console.WriteLine("Luxurious apartment built : {0}", apartmentBuilder.Apartment.ToString());

            apartmentBuilder = new ExpedientApartmentBuilder();
            architect.Construct(apartmentBuilder);
            Console.WriteLine("Expedient apartment built : {0}", apartmentBuilder.Apartment.ToString());

            apartmentBuilder = new CheapApartmentBuilder();
            architect.Construct(apartmentBuilder);
            Console.WriteLine("Cheap apartment built : {0}", apartmentBuilder.Apartment.ToString());
        }
    }
}
