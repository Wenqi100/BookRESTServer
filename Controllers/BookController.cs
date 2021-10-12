using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookClassLibrary;
using BookRestServer.Managers;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookRestServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {       
        //GET <BookController>/5

        private BookManager _manager = new BookManager();

        #region MyDraft
        /*        
        private static List<Book> _books = new List<Book>()
        {
            new Book("C# Basic","Philip",350,"ISBN11111111"),
            new Book("C# Advanced","Philip",450,"ISBN22222222"),
            new Book("Python Basic","Tommy",550,"ISBN33333333"),
            new Book("Python Advanced","Tommy",650,"ISBN44444444")
        };
          
        [HttpGet]
        public IEnumerable<Book> GetAllBooks(string title = "", string author = "", string isbn = "")
        {
            title ??= string.Empty;
            author ??= string.Empty;
            isbn ??= string.Empty;
            var result = _books
                .Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                .Where(b => b.ISBN13.Contains(isbn, StringComparison.OrdinalIgnoreCase));

            return result;
        }
        */

        #endregion

        //GET: <BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _manager.GetAll(); 
        }

        [HttpGet("{isbn13}")]
        public Book GetBookByISBN(string isbn13)
        {
            return _manager.GetBookByISBN(isbn13);
        }

        // POST <BookController>
        [HttpPost]
        public Book Post([FromBody] Book value)
        {
            return _manager.Add(value);
        }

        // PUT <BookController>/5
        [HttpPut("{isbn13}")]
        public Book Put(string isbn13, [FromBody] Book value)
        {
            return _manager.Update(isbn13, value);
        }

        // DELETE <BookController>
        [HttpDelete("{isbn13}")]
        public IEnumerable<Book> Delete(string isbn13)
        {
            _manager.Delete(isbn13);
            return _manager.GetAll();
        }
    }
}
