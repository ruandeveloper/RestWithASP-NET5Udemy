using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Repository
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book FindById(long bookId);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long bookId);
        bool Exists(long id);
    }
}