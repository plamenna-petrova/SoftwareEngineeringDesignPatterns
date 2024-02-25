package Products;

import Abstraction.EraObject;
import Constants.GlobalConstants;

public class VictorianHouse extends EraObject {
    @Override
    public void showDetails() {
        System.out.printf((GlobalConstants.HouseMessage) + "%n", "Victorian Era");
    }
}
