package Products;

import Interfaces.IFurniture;

public class ClassicDiningTable implements IFurniture {
    @Override
    public void showFurnitureStyle() {
        System.out.println("I am a classic dining table");
    }
}
