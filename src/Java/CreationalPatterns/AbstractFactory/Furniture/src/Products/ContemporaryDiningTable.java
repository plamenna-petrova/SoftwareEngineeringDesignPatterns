package Products;

import Interfaces.IFurniture;

public class ContemporaryDiningTable implements IFurniture {
    @Override
    public void showFurnitureStyle() {
        System.out.println("I am a contemporary dining table");
    }
}

