package ConcreteFactories;

import Interfaces.IFurniture;
import Interfaces.IFurnitureFactory;
import Products.ScandinavianCabinet;
import Products.ScandinavianChair;
import Products.ScandinavianDiningTable;

public class ScandinavianFurnitureFactory implements IFurnitureFactory {
    @Override
    public IFurniture createCabinet() {
        return new ScandinavianCabinet();
    }

    @Override
    public IFurniture createChair() {
        return new ScandinavianChair();
    }

    @Override
    public IFurniture createDiningTable() {
        return new ScandinavianDiningTable();
    }
}
