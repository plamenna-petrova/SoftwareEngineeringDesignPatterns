package Products;

import Interfaces.IFurniture;

public class ClassicChair implements IFurniture {
    @Override
    public void showFurnitureStyle() {
        System.out.println("I am a classic chair");
    }
}
