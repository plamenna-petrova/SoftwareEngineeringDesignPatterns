import java.util.HashMap;

class Prototype implements Cloneable {
    public int X;

    public Prototype(int x) {
        this.X = x;
    }

    public void PrintData() {
        System.out.println("with value: " + X);
    }

    @Override
    protected Object clone() throws CloneNotSupportedException {
        return super.clone();
    }
}

class Program {
    public static void main(String[] args) {
        Prototype prototype = new Prototype(10);

        HashMap<String, Prototype> clonesDictionary = new HashMap<>();

        String name = "Object";

        for (int i = 1; i < 11; i++) {
            String identifier = name + i;
            try {
                clonesDictionary.put(identifier, (Prototype) prototype.clone());
                clonesDictionary.get(identifier).X *= i;
                System.out.printf("%s ", identifier);
                clonesDictionary.get(identifier).PrintData();
            } catch (CloneNotSupportedException cloneNotSupportedException) {
                throw new RuntimeException(cloneNotSupportedException);
            }
        }
    }
}
