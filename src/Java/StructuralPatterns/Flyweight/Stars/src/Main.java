import java.util.HashMap;
import java.util.Map;

interface Star {
    void print();
}

class WhiteDwarf implements Star {
    public void print() {
        System.out.println("Print white dwarf");
    }
}

class RedGiant implements Star {
    public void print() {
        System.out.println("Print red giant");
    }
}

class StarsFactory {
    private final Map<String, Star> stars = new HashMap<>();

    public int getStarsCount() {
        return stars.size();
    }

    public Star getStar(String starType) {
        Star star;

        if (stars.containsKey(starType)) {
            star = stars.get(starType);
        } else {
            if (starType.equals("White Dwarf")) {
                star = new WhiteDwarf();
                stars.put(starType, star);
            } else {
                star = new RedGiant();
                stars.put(starType, star);
            }
        }

        return star;
    }
}

public class Main {
    public static void main(String[] args) {
        StarsFactory starsFactory = new StarsFactory();

        Star star = starsFactory.getStar("White Dwarf");
        star.print();
        star = starsFactory.getStar("White Dwarf");
        star.print();
        star = starsFactory.getStar("White Dwarf");
        star.print();

        System.out.println("-------------------------------");
        star = starsFactory.getStar("Red Giant");
        star.print();
        star = starsFactory.getStar("Red Giant");
        star.print();
        star = starsFactory.getStar("Red Giant");
        star.print();

        System.out.println("Get shapes count : " + starsFactory.getStarsCount());
    }
}