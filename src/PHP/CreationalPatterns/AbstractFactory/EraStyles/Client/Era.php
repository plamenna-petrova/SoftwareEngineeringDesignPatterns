<?php

namespace CreationalPatterns\AbstractFactory\EraStyles\Client;

use CreationalPatterns\AbstractFactory\EraStyles\Abstraction\EraObject;
use CreationalPatterns\AbstractFactory\EraStyles\Abstraction\EraObjectStylesFactory;

class Era {
    private EraObject $eraObject;

    public function __construct(EraObjectStylesFactory $stylesFactory, $era) {
        switch ($era) {
            case 'M':
                $this->eraObject = $stylesFactory->CreateMedievalStyleObject();
                break;
            case 'R':
                $this->eraObject = $stylesFactory->CreateRenaissanceStyleObject();
                break;
            case 'V':
                $this->eraObject = $stylesFactory->CreateVictorianEraStyleObject();
                break;
        }
    }

    public function info(): void
    {
        $this->eraObject->ShowDetails();
    }
}
