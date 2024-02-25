package ConcreteFactories;

import Abstraction.EraObject;
import Abstraction.EraObjectStylesFactory;
import Products.MedievalHouse;
import Products.RenaissanceHouse;
import Products.VictorianHouse;

public class HouseFactory extends EraObjectStylesFactory {
    @Override
    public EraObject createMedievalStyleObject() {
        return new MedievalHouse();
    }

    @Override
    public EraObject createRenaissanceStyleObject() {
        return new RenaissanceHouse();
    }

    @Override
    public EraObject createVictorianEraStyleObject() {
        return new VictorianHouse();
    }
}
