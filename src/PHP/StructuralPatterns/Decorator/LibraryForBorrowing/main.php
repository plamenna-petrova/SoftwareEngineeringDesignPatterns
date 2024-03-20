<?php

abstract class LibraryItem {
    public int $numberOfCopies;

    public abstract function display();
}

class Book extends LibraryItem {
    public string $author;
    public string $title;

    public function __construct($author, $title, $numberOfCopies) {
        $this->author = $author;
        $this->title = $title;
        $this->numberOfCopies = $numberOfCopies;
    }

    public function display(): void
    {
        echo "\nBook ----- \n";
        echo " Author: $this->author\n";
        echo " Title: $this->title\n";
        echo " # Copies: $this->numberOfCopies\n";
    }
}

class Video extends LibraryItem {
    public string $director;
    public string $title;
    public int $playTime;

    public function __construct($director, $title, $numberOfCopies, $playTime) {
        $this->director = $director;
        $this->title = $title;
        $this->numberOfCopies = $numberOfCopies;
        $this->playTime = $playTime;
    }

    public function display(): void
    {
        echo "\nVideo ----- \n";
        echo " Director: $this->director\n";
        echo " Title: $this->title\n";
        echo " # Copies: $this->numberOfCopies\n";
        echo " Playtime: $this->playTime\n";
    }
}

abstract class LibraryItemDecorator extends LibraryItem {
    protected LibraryItem $libraryItem;

    public function __construct($libraryItem) {
        $this->libraryItem = $libraryItem;
    }

    public function display(): void
    {
        $this->libraryItem->display();
    }
}

class BorrowableItemConcreteDecorator extends LibraryItemDecorator {
    protected array $borrowers = [];

    public function __construct($libraryItem) {
        parent::__construct($libraryItem);
    }

    public function borrowItem($borrower): void
    {
        $this->borrowers[] = $borrower;
        $this->libraryItem->numberOfCopies--;
    }

    public function returnItem($borrower): void
    {
        $key = array_search($borrower, $this->borrowers);

        if ($key !== false) {
            unset($this->borrowers[$key]);
            $this->libraryItem->numberOfCopies++;
        }
    }

    public function display(): void
    {
        parent::display();
        echo "\n";
        foreach ($this->borrowers as $borrower) {
            echo "Borrower: $borrower\n";
        }
    }
}

$book = new Book("Worley", "Inside ASP.NET", 10);
$book->display();

$video = new Video("Spielberg", "Jaws", 23, 92);
$video->display();

echo "\nMaking videos borrowable: \n";
$borrowableItemConcreteDecorator = new BorrowableItemConcreteDecorator($video);
$borrowableItemConcreteDecorator->borrowItem("Customer #1");
$borrowableItemConcreteDecorator->borrowItem("Customer #2");

$borrowableItemConcreteDecorator->display();