import java.util.ArrayList;
import java.util.List;

abstract class Stock {
    private double price;
    private final List<IInvestor> investors = new ArrayList<>();
    private final String symbol;

    public Stock(String symbol, double price) {
        this.symbol = symbol;
        this.price = price;
    }

    public String getSymbol() {
        return symbol;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        if (this.price != price) {
            this.price = price;
            notifyObservers();
        }
    }

    public void attach(IInvestor investor) {
        investors.add(investor);
    }

    public void detach(IInvestor investor) {
        investors.remove(investor);
    }

    public void notifyObservers() {
        for (IInvestor investor : investors) {
            investor.update(this);
        }
        System.out.println();
    }
}

class IBM extends Stock {
    public IBM(String symbol, double price) {
        super(symbol, price);
    }
}

interface IInvestor {
    void update(Stock stock);
}

class Investor implements IInvestor {
    private final String name;
    private Stock stock;

    public Investor(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public Stock getStock() {
        return stock;
    }

    public void setStock(Stock stock) {
        this.stock = stock;
    }

    public void update(Stock stock) {
        System.out.printf("Notified %s of %s's change to %.2f%n", name, stock.getSymbol(), stock.getPrice());
    }
}

public class Main {
    public static void main(String[] args) {
        IBM ibm = new IBM("IBM", 120.00);

        ibm.attach(new Investor("Sorros"));
        ibm.attach(new Investor("Berkshire"));

        ibm.setPrice(120.10);
        ibm.setPrice(121.00);
        ibm.setPrice(120.50);
        ibm.setPrice(120.75);
    }
}