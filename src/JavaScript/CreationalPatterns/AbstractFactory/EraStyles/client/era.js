
class Era {
    constructor(stylesFactory, era) {
        switch (era) {
            case 'M':
                this._eraObject = stylesFactory.createMedievalStyleObject();
                break;
            case 'R':
                this._eraObject = stylesFactory.createRenaissanceStyleObject();
                break;
            case 'V':
                this._eraObject = stylesFactory.createVictorianEraStyleObject();
                break;
        }
    }

    info() {
        this._eraObject.showDetails();
    }
}

module.exports = Era;