package Products;

import Abstraction.EraObject;
import Constants.GlobalConstants;

public class RenaissanceClothing extends EraObject {
    @Override
    public void showDetails() {
        System.out.printf((GlobalConstants.ClothingMessage) + "%n", "Renaissance");
    }
}
