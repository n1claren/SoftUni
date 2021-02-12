using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] booksInput)
        {
            books = new List<Book>(booksInput);
        }

        public void Add(Book book)
        {
            books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new BookIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class BookIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int index;

            public BookIterator(List<Book> books)
            {
                this.Reset();

                this.books = books;
            }

            public Book Current
            {
                get { return this.books[this.index]; }
            }

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
              
            }

            public bool MoveNext()
            {
                return ++this.index > this.books.Count;
            }

            public void Reset()
            {
                this.index = -1;
            }
        }
    }
}
