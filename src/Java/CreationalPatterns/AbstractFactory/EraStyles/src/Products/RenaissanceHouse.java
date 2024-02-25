package Products;

import Abstraction.EraObject;
import Constants.GlobalConstants;

public class RenaissanceHouse extends EraObject {
    @Override
    public void showDetails() {
        System.out.printf((GlobalConstants.HouseMessage) + "%n", "Renaissance");
    }
}
