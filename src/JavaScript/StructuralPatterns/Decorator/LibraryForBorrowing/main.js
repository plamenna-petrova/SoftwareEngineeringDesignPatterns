
class LibraryItem {
    constructor(numberOfCopies) {
        this.numberOfCopies = numberOfCopies;
    }

    display() {
        console.log("\nLibrary Item ----- ");
        console.log(` # Copies: ${this.numberOfCopies}`);
    }
}

class Book extends LibraryItem {
    constructor(author, title, numberOfCopies) {
        super(numberOfCopies);
        this.author = author;
        this.title = title;
    }

    display() {
        console.log("\nBook ----- ");
        console.log(` Author: ${this.author}`);
        console.log(` Title: ${this.title}`);
        super.display();
    }
}

class Video extends LibraryItem {
    constructor(director, title, numberOfCopies, playTime) {
        super(numberOfCopies);
        this.director = director;
        this.title = title;
        this.playTime = playTime;
    }

    display() {
        console.log("\nVideo ----- ");
        console.log(` Director: ${this.director}`);
        console.log(` Title: ${this.title}`);
        console.log(` Playtime: ${this.playTime}`);
        super.display();
    }
}

class BorrowableItemConcreteDecorator extends LibraryItem {
    constructor(libraryItem) {
        super(libraryItem.numberOfCopies);
        this.libraryItem = libraryItem;
        this.borrowers = [];
    }

    borrowItem(borrower) {
        this.borrowers.push(borrower);
        this.libraryItem.numberOfCopies--;
    }

    returnItem(borrower) {
        const index = this.borrowers.indexOf(borrower);
        if (index !== -1) {
            this.borrowers.splice(index, 1);
            this.libraryItem.numberOfCopies++;
        }
    }

    display() {
        this.libraryItem.display();
        console.log("\nBorrowers: ");
        this.borrowers.forEach(borrower => console.log(`- ${borrower}`));
    }
}

const book = new Book("Worley", "Inside ASP.NET", 10);
book.display();

const video = new Video("Spielberg", "Jaws", 23, 92);
video.display();

console.log("\nMaking videos borrowable: ");
const borrowableVideo = new BorrowableItemConcreteDecorator(video);
borrowableVideo.borrowItem("Customer #1");
borrowableVideo.borrowItem("Customer #2");
borrowableVideo.display();