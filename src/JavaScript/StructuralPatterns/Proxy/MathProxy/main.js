
class Math {
    add(x, y) {
        return x + y;
    }

    sub(x, y) {
        return x - y;
    }

    mul(x, y) {
        return x * y;
    }

    div(x, y) {
        return x / y;
    }
}

class MathProxy {
    constructor() {
        this.math = new Math();
    }

    add(x, y) {
        return this.math.add(x, y);
    }

    sub(x, y) {
        return this.math.sub(x, y);
    }

    mul(x, y) {
        return this.math.mul(x, y);
    }

    div(x, y) {
        return this.math.div(x, y);
    }
}

const mathProxy = new MathProxy();

console.log("4 + 2 = " + mathProxy.add(4, 2));
console.log("4 - 2 = " + mathProxy.sub(4, 2));
console.log("4 * 2 = " + mathProxy.mul(4, 2));
console.log("4 / 2 = " + mathProxy.div(4, 2));