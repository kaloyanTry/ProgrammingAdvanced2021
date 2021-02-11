using System;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Book bookFirst = new Book("Animal Farm", 2003, "George Orwell");
            Book bookSecond = new Book("The Documents in the case", 2002, "Dororthy Sayers", "Robert Eutace");
            Book bookThird = new Book("The Documents in the case", 1930);

            Library libraryFirst = new Library();
            Library librarySecond = new Library(bookFirst, bookSecond, bookThird);

            foreach (var book in librarySecond)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
