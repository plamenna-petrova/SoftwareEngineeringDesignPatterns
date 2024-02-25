package ConcreteFactories;

import Abstraction.EraObject;
import Abstraction.EraObjectStylesFactory;
import Products.MedievalClothing;
import Products.RenaissanceClothing;
import Products.VictorianClothing;

public class ClothingFactory extends EraObjectStylesFactory {
    @Override
    public EraObject createMedievalStyleObject() {
        return new MedievalClothing();
    }

    @Override
    public EraObject createRenaissanceStyleObject() {
        return new RenaissanceClothing();
    }

    @Override
    public EraObject createVictorianEraStyleObject() {
        return new VictorianClothing();
    }
}
