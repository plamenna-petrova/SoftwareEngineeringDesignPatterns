package Products;

import Interfaces.IFurniture;

public class ContemporaryCabinet implements IFurniture {
    @Override
    public void showFurnitureStyle() {
        System.out.println("I am a contemporary cabinet");
    }
}
