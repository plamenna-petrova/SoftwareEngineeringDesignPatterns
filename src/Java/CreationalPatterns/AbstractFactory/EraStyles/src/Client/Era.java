package Client;

import Abstraction.EraObject;
import Abstraction.EraObjectStylesFactory;

public class Era {
    private EraObject eraObject;

    public Era(EraObjectStylesFactory eraObjectStylesFactory, char era) {
        switch (era) {
            case 'M':
                eraObject = eraObjectStylesFactory.createMedievalStyleObject();
                break;
            case 'R':
                eraObject = eraObjectStylesFactory.createRenaissanceStyleObject();
                break;
            case 'V':
                eraObject = eraObjectStylesFactory.createVictorianEraStyleObject();
                break;
        }
    }

    public void info() {
        eraObject.showDetails();
    }
}
