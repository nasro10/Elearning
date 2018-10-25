using Data;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BookService
    {
        MyFinanceContext ctx = null;
        public BookService()
        {
            ctx = new MyFinanceContext();
        }
        public void Add(Book b)
        {
            ctx.Books.Add(b);
            ctx.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return ctx.Books;
        }

        public Book GetBookById(int? id)
        {
            return ctx.Books.Find(id);
        }

        public void Delete(Book b)
        {
            ctx.Books.Remove(b);
            ctx.SaveChanges();
        }

        public void Update(Book b)
        {
            ctx.Entry(b).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}

