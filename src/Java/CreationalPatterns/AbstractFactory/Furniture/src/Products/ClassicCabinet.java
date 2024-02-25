package Products;

import Interfaces.IFurniture;

public class ClassicCabinet implements IFurniture {
    @Override
    public void showFurnitureStyle() {
        System.out.println("I am a classic cabinet");
    }
}