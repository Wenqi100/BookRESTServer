using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookClassLibrary;

namespace BookRestServer.Managers
{
    public class BookManager
    {
        private static string _isbn;
        private static readonly List<Book> _books = new List<Book>
        {
            new Book("C# Basic","Philip",350,"ISBN11111111"),
            new Book("C# Advanced","Philip",450,"ISBN22222222"),
            new Book("Python Basic","Tommy",550,"ISBN33333333"),
            new Book("Python Advanced","Tommy",650,"ISBN44444444")
        };
        public List<Book> GetAll()
        {
            return new List<Book>(_books);
            // copy constructor
            // Callers should no get a reference to the Data object, but rather get a copy
        }

        public Book GetBookByISBN(string isbn)
        {
            Book book = _books.Find(b => b.ISBN13 == isbn);
            return book;
        }

        public Book Add(Book newBook)
        {
            _books.Add(newBook);
            return newBook;
        }


        public IEnumerable<Book> Delete(string isbn)
        {
            Book book = _books.Find(b => b.ISBN13 == isbn);
            if (book == null) return null;
            _books.Remove(book);
            return _books;
        }

        public Book Update(string isbn, Book updates)
        {
            Book book = _books.Find(b => b.ISBN13 == isbn);
            if (book == null) return null;
            book.Title = updates.Title;
            book.Author = updates.Author;
            book.PageNumber = updates.PageNumber;
            book.ISBN13 = updates.ISBN13;
            return book;
        }
    }
}
