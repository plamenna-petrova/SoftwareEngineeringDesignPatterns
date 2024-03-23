using System;
using System.Collections.Generic;

namespace LibraryForBorrowing
{
    public abstract class LibraryItem
    {
        public int NumberOfCopies { get; set; }

        public abstract void Display();
    }

    public class Book : LibraryItem
    {
        public Book(string author, string title, int numberOfCopies)
        {
            Author = author;
            Title = title;
            NumberOfCopies = numberOfCopies;
        }

        public string Author { get; set; }

        public string Title { get; set; }

        public override void Display()
        {
            Console.WriteLine($"\nBook ----- ");
            Console.WriteLine($" Author: {Author}");
            Console.WriteLine($" Title: {Title}");
            Console.WriteLine($" # Copies: {NumberOfCopies}");
        }
    }

    public class Video : LibraryItem
    {
        public Video(string director, string title, int numberOfCopies, int playTime)
        {
            Director = director;
            Title = title;
            NumberOfCopies = numberOfCopies;
            PlayTime = playTime;
        }

        public string Director { get; set; }

        public string Title { get; set; }

        public int PlayTime { get; set; }

        public override void Display()
        {
            Console.WriteLine("\nVideo ----- ");
            Console.WriteLine($" Director {Director}");
            Console.WriteLine($" Title: {Title}");
            Console.WriteLine($" # Copies: {NumberOfCopies}");
            Console.WriteLine($" Playtime \n {PlayTime}");
        }
    }

    public abstract class LibraryItemDecorator : LibraryItem
    {
        protected LibraryItem libraryItem;

        public LibraryItemDecorator(LibraryItem libraryItem)
        {
            this.libraryItem = libraryItem;                
        }

        public override void Display() => libraryItem.Display();
    }

    public class BorrowableItemConcreteDecorator : LibraryItemDecorator
    {
        protected readonly List<string> borrowers = new List<string>();

        public BorrowableItemConcreteDecorator(LibraryItem libraryItem) : base(libraryItem)
        {
                 
        }

        public void BorrowItem(string borrower)
        {
            borrowers.Add(borrower);
            libraryItem.NumberOfCopies--;
        }

        public void ReturnItem(string borrower)
        {
            borrowers.Remove(borrower);
            libraryItem.NumberOfCopies++;
        }

        public override void Display()
        {
            base.Display();

            Console.WriteLine();

            foreach (var borrower in borrowers)
            {
                Console.WriteLine($"Borrower: {borrower}");
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Worley", "Inside ASP.NET", 10);
            book.Display();

            Video video = new Video("Spielberg", "Jaws", 23, 92);
            video.Display();

            Console.WriteLine("\nMaking videos borrowable: ");

            BorrowableItemConcreteDecorator borrowableItemConcreteDecorator = new BorrowableItemConcreteDecorator(video);
            borrowableItemConcreteDecorator.BorrowItem("Customer #1");
            borrowableItemConcreteDecorator.BorrowItem("Customer #2");

            borrowableItemConcreteDecorator.Display();
        }
    }
}
