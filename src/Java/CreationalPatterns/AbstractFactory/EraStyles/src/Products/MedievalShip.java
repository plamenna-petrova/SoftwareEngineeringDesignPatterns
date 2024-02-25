package Products;

import Abstraction.EraObject;
import Constants.GlobalConstants;

public class MedievalShip extends EraObject {
    @Override
    public void showDetails() {
        System.out.printf((GlobalConstants.ShipMessage) + "%n", "Medieval");
    }
}
