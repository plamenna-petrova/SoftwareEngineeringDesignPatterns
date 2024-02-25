package ConcreteFactories;

import Interfaces.IFurniture;
import Interfaces.IFurnitureFactory;
import Products.ClassicCabinet;
import Products.ClassicChair;
import Products.ClassicDiningTable;

public class ClassicFurnitureFactory implements IFurnitureFactory {
    @Override
    public IFurniture createCabinet() {
        return new ClassicCabinet();
    }

    @Override
    public IFurniture createChair() {
        return new ClassicChair();
    }

    @Override
    public IFurniture createDiningTable() {
        return new ClassicDiningTable();
    }
}
