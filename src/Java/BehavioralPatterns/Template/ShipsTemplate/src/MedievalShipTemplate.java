public abstract class MedievalShipTemplate {
    public void buildMedievalShip() {
        buildFoundation();
        buildHull();
        buildDeck();
        buildMasts();
        buildCabins();
        buildExteriorDetails();
        System.out.println("The ship is built.");
    }

    protected abstract void buildFoundation();

    protected abstract void buildHull();

    protected abstract void buildDeck();

    protected abstract void buildMasts();

    protected abstract void buildCabins();

    protected abstract void buildExteriorDetails();
}
