package Products;

import Abstraction.EraObject;
import Constants.GlobalConstants;

public class RenaissanceShip extends EraObject {
    @Override
    public void showDetails() {
        System.out.printf((GlobalConstants.ShipMessage) + "%n", "Renaissance");
    }
}
