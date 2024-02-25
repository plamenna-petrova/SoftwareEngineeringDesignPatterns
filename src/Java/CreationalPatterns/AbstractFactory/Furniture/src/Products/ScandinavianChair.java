package Products;

import Interfaces.IFurniture;

public class ScandinavianChair implements IFurniture {
    @Override
    public void showFurnitureStyle() {
        System.out.println("I am a Scandinavian chair");
    }
}
