package Products;

import Interfaces.IFurniture;

public class ContemporaryChair implements IFurniture {
    @Override
    public void showFurnitureStyle() {
        System.out.println("I am a contemporary chair");
    }
}
