interface IMath {
    double add(double x, double y);

    double sub(double x, double y);

    double mul(double x, double y);

    double div(double x, double y);
}

class Math implements IMath {
    @Override
    public double add(double x, double y) {
        return x + y;
    }

    @Override
    public double sub(double x, double y) {
        return x - y;
    }

    @Override
    public double mul(double x, double y) {
        return x * y;
    }

    @Override
    public double div(double x, double y) {
        return x / y;
    }
}

class MathProxy implements IMath {
    private final Math math = new Math();

    @Override
    public double add(double x, double y) {
        return math.add(x, y);
    }

    @Override
    public double sub(double x, double y) {
        return math.sub(x, y);
    }

    @Override
    public double mul(double x, double y) {
        return math.mul(x, y);
    }

    @Override
    public double div(double x, double y) {
        return math.div(x, y);
    }
}

public class Main {
    public static void main(String[] args) {
        MathProxy mathProxy = new MathProxy();

        System.out.println("4 + 2 = " + mathProxy.add(4, 2));
        System.out.println("4 - 2 = " + mathProxy.sub(4, 2));
        System.out.println("4 * 2 = " + mathProxy.mul(4, 2));
        System.out.println("4 / 2 = " + mathProxy.div(4, 2));
    }
}