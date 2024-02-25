package Products;

import Abstraction.EraObject;
import Constants.GlobalConstants;

public class MedievalClothing extends EraObject {
    @Override
    public void showDetails() {
        System.out.printf((GlobalConstants.ClothingMessage) + "%n", "Medieval");
    }
}
