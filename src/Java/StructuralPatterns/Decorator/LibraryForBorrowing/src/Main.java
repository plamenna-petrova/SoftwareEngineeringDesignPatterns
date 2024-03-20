import java.util.ArrayList;
import java.util.List;

abstract class LibraryItem {
    protected int numberOfCopies;

    public abstract void display();
}

class Book extends LibraryItem {
    private final String author;
    private final String title;

    public Book(String author, String title, int numberOfCopies) {
        this.author = author;
        this.title = title;
        this.numberOfCopies = numberOfCopies;
    }

    @Override
    public void display() {
        System.out.println("\nBook ----- ");
        System.out.println(" Author: " + author);
        System.out.println(" Title: " + title);
        System.out.println(" # Copies: " + numberOfCopies);
    }
}

class Video extends LibraryItem {
    private final String director;
    private final String title;
    private final int playTime;

    public Video(String director, String title, int numberOfCopies, int playTime) {
        this.director = director;
        this.title = title;
        this.numberOfCopies = numberOfCopies;
        this.playTime = playTime;
    }

    @Override
    public void display() {
        System.out.println("\nVideo ----- ");
        System.out.println(" Director: " + director);
        System.out.println(" Title: " + title);
        System.out.println(" # Copies: " + numberOfCopies);
        System.out.println(" Playtime: " + playTime);
    }
}

abstract class LibraryItemDecorator extends LibraryItem {
    protected LibraryItem libraryItem;

    public LibraryItemDecorator(LibraryItem libraryItem) {
        this.libraryItem = libraryItem;
    }

    @Override
    public void display() {
        libraryItem.display();
    }
}

class BorrowableItemConcreteDecorator extends LibraryItemDecorator {
    private final List<String> borrowers = new ArrayList<>();

    public BorrowableItemConcreteDecorator(LibraryItem libraryItem) {
        super(libraryItem);
    }

    public void borrowItem(String borrower) {
        borrowers.add(borrower);
        libraryItem.numberOfCopies--;
    }

    public void returnItem(String borrower) {
        borrowers.remove(borrower);
        libraryItem.numberOfCopies++;
    }

    @Override
    public void display() {
        super.display();
        System.out.println();
        for (String borrower : borrowers) {
            System.out.println("Borrower: " + borrower);
        }
    }
}

public class Main {
    public static void main(String[] args) {
        Book book = new Book("Worley", "Inside ASP.NET", 10);
        book.display();

        Video video = new Video("Spielberg", "Jaws", 23, 92);
        video.display();

        System.out.println("\nMaking videos borrowable: ");
        BorrowableItemConcreteDecorator borrowableItemConcreteDecorator = new BorrowableItemConcreteDecorator(video);
        borrowableItemConcreteDecorator.borrowItem("Customer #1");
        borrowableItemConcreteDecorator.borrowItem("Customer #2");
        borrowableItemConcreteDecorator.display();
    }
}