public class Caravel extends MedievalShipTemplate {

    @Override
    protected void buildFoundation() {
        System.out.println("Building foundation, using caravel method of construction");
    }

    @Override
    protected void buildHull() {
        System.out.println("Building a lateen rigged hull");
    }

    @Override
    protected void buildDeck() {
        System.out.println("Building a large deck");
    }

    @Override
    protected void buildMasts() {
        System.out.println("Building three masts");
    }

    @Override
    protected void buildCabins() {
        System.out.println("Building eight cabins");
    }

    @Override
    protected void buildExteriorDetails() {
        System.out.println("Building templar flags ornaments");
    }
}
