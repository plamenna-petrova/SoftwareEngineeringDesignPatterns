package Products;

import Abstraction.EraObject;
import Constants.GlobalConstants;

public class MedievalHouse extends EraObject {
    @Override
    public void showDetails() {
        System.out.printf((GlobalConstants.HouseMessage) + "%n", "Medieval");
    }
}
