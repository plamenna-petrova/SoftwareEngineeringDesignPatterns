package Products;

import Abstraction.EraObject;
import Constants.GlobalConstants;

public class VictorianShip extends EraObject {
    @Override
    public void showDetails() {
        System.out.printf((GlobalConstants.ShipMessage) + "%n", "Victorian Era");
    }
}