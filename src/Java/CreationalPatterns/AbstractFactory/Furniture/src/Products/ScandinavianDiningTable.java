package Products;

import Interfaces.IFurniture;

public class ScandinavianDiningTable implements IFurniture {
    @Override
    public void showFurnitureStyle() {
        System.out.println("I am a Scandinavian dining table");
    }
}
