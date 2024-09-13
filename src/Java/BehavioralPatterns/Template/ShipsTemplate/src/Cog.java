public class Cog extends MedievalShipTemplate {
    @Override
    protected void buildFoundation() {
        System.out.println("Building foundation with oak");
    }

    @Override
    protected void buildHull() {
        System.out.println("Building a double-ended hull");
    }

    @Override
    protected void buildDeck() {
        System.out.println("Building a small deck");
    }

    @Override
    protected void buildMasts() {
        System.out.println("Building one mast");
    }

    @Override
    protected void buildCabins() {
        System.out.println("Building four cabins");
    }

    @Override
    protected void buildExteriorDetails() {
        System.out.println("Building a rear tower");
    }
}
