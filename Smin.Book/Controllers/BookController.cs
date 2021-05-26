using Book.BL;
using Book.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Smin.Book.Controllers
{
    [RoutePrefix("api/book")]
    public class BookController : ApiController
    {
        // GET: api/Book
        //[Route("getbook")]
        public IEnumerable<DM_BOOKS> Get()
        {
            BooksDao db = new BooksDao();
            return db.GetBooks();
        }

        // GET: api/Book/5
        [Route("{bookId}")]
        public DM_BOOKS Get(string bookId)
        {
            BooksDao db = new BooksDao();
            return db.GetBook(bookId);
        }

        // POST: api/Book
        public bool Post([FromBody]DM_BOOKS book)
        {
            BooksDao db = new BooksDao();
            if (db.AddBook(book))
            {
                db.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        // PUT: api/Book/5
        public bool Put([FromBody]DM_BOOKS book)
        {
            BooksDao db = new BooksDao();
            DM_BOOKS bookDb = db.GetBook(book.BookId);
            if (bookDb == null)
            {
                return false;
            }
            else
            {
                if (db.DeleteBook(bookDb))
                {
                    db.AddBook(book);
                    db.Save();
                    return true;
                }
                else
                {
                    return true;
                }                
            }

        }

        // DELETE: api/Book/5
        [Route("{bookId}")]
        public bool Delete(string bookId)
        {
            BooksDao db = new BooksDao();
            DM_BOOKS book = db.GetBook(bookId);
            if (book == null)
            {
                return false;
            }
            else
            {
                bool res = db.DeleteBook(book);
                db.Save();
                return res;
            }
        }
    }
}
