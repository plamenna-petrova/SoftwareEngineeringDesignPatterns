public class Main {
    public static void main(String[] args) {
        System.out.println("Building the medieval ship cog");

        MedievalShipTemplate medievalShipTemplate = new Cog();
        medievalShipTemplate.buildMedievalShip();

        System.out.println();

        System.out.println("Building the medieval ship caravel");
        medievalShipTemplate = new Caravel();
        medievalShipTemplate.buildMedievalShip();
    }
}