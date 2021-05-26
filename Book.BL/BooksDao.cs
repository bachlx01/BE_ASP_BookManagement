using Book.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BL
{
    public class BooksDao
    {
        BooksDbContext context = null;
        public BooksDao()
        {
            context = new BooksDbContext();
        }

        public bool AddBook(DM_BOOKS book)
        {
            bool confirm = false;
            context.DM_BOOKS.Add(book);
            try
            {
                confirm = true;
            }
            catch (Exception)
            {
                confirm = false;
            }
            return confirm;
        }

        public DM_BOOKS GetBook(string bookId)
        {
            return context.DM_BOOKS.Where<DM_BOOKS>(c => c.BookId == bookId).FirstOrDefault();
        }

        public List<DM_BOOKS> GetBooks()
        {
            return context.DM_BOOKS.ToList();
        }

        public bool DeleteBook(DM_BOOKS book)
        {
            bool result = false;
            try
            {
                context.DM_BOOKS.Remove(book);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
