package ConcreteFactories;

import Abstraction.EraObject;
import Abstraction.EraObjectStylesFactory;
import Products.MedievalShip;
import Products.RenaissanceShip;
import Products.VictorianShip;

public class ShipFactory extends EraObjectStylesFactory {
    @Override
    public EraObject createMedievalStyleObject() {
        return new MedievalShip();
    }

    @Override
    public EraObject createRenaissanceStyleObject() {
        return new RenaissanceShip();
    }

    @Override
    public EraObject createVictorianEraStyleObject() {
        return new VictorianShip();
    }
}
