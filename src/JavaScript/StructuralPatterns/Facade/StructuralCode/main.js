
class SubSystemOne {
    methodOne() {
        console.log("SubSystemOne Method");
    }
}

class SubSystemTwo {
    methodTwo() {
        console.log("SubSystemTwo Method");
    }
}

class SubSystemThree {
    methodThree() {
        console.log("SubSystemThree Method");
    }
}

class SubSystemFour {
    methodFour() {
        console.log("SubSystemFour Method");
    }
}

class Facade {
    constructor() {
        this.subSystemOne = new SubSystemOne();
        this.subSystemTwo = new SubSystemTwo();
        this.subSystemThree = new SubSystemThree();
        this.subSystemFour = new SubSystemFour();
    }

    methodA() {
        console.log("\nMethodA() ---- ");
        this.subSystemOne.methodOne();
        this.subSystemTwo.methodTwo();
        this.subSystemFour.methodFour();
    }

    methodB() {
        console.log("\nMethodB() ---- ");
        this.subSystemTwo.methodTwo();
        this.subSystemThree.methodThree();
    }
}

const facade = new Facade();

facade.methodA();
facade.methodB();