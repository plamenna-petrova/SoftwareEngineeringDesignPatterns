package Products;

import Abstraction.EraObject;
import Constants.GlobalConstants;

public class VictorianClothing extends EraObject {
    @Override
    public void showDetails() {
        System.out.printf((GlobalConstants.ClothingMessage) + "%n", "Victorian Era");
    }
}
