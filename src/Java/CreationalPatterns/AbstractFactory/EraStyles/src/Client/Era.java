package Client;

import Abstraction.EraObject;
import Abstraction.EraObjectStylesFactory;

public class Era {
    private EraObject eraObject;

    public Era(EraObjectStylesFactory stylesFactory, char era) {
        switch (era) {
            case 'M':
                eraObject = stylesFactory.createMedievalStyleObject();
                break;
            case 'R':
                eraObject = stylesFactory.createRenaissanceStyleObject();
                break;
            case 'V':
                eraObject = stylesFactory.createVictorianEraStyleObject();
                break;
        }
    }

    public void info() {
        eraObject.showDetails();
    }
}
