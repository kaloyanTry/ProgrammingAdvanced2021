using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int index;

            public LibraryIterator(List<Book> books)
            {
                this.books = books;
                index = -1;
            }

            public bool MoveNext()
            {
                index++;

                if (index < books.Count)
                {
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                index = -1;
            }

            public Book Current
            {
                get => books[index];
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {

            }
        }

        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
            this.books = books.OrderBy(b => b).ToList();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            LibraryIterator iter = new LibraryIterator(books);

            return iter;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}