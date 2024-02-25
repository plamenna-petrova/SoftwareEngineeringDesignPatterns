package Products;

import Interfaces.IFurniture;

public class ScandinavianCabinet implements IFurniture {
    @Override
    public void showFurnitureStyle() {
        System.out.println("I am a Scandinavian cabinet");
    }
}
