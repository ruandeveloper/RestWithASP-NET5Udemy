using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySQLContext _context;

        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }
        
        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
            return book;
        }

        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;

            var result = FindById(book.Id);

            if (result == null) return book;
            
            try
            {
                _context.Entry(result).CurrentValues.SetValues(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return book;
        }
        
        public void Delete(long bookId)
        {
            var result = FindById(bookId);
            
            if (result == null) return;

            try
            {
                _context.Books.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool Exists(long id)
        {
            return _context.Books.Any(p => p.Id.Equals(id));
        }
    }
}