package ConcreteFactories;

import Interfaces.IFurniture;
import Interfaces.IFurnitureFactory;
import Products.ContemporaryCabinet;
import Products.ContemporaryChair;
import Products.ContemporaryDiningTable;

public class ContemporaryFurnitureFactory implements IFurnitureFactory {
    @Override
    public IFurniture createCabinet() {
        return new ContemporaryCabinet();
    }

    @Override
    public IFurniture createChair() {
        return new ContemporaryChair();
    }

    @Override
    public IFurniture createDiningTable() {
        return new ContemporaryDiningTable();
    }
}
