using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Data.Converter.Contract;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Data.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null) return null;

            return new Book()
            {
                Id = origin.Id,
                Author = origin.Author,
                Price = origin.Price,
                Title = origin.Title,
                LaunchDate = origin.LaunchDate
            };
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            return origin?.Select(Parse).ToList();
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;

            return new BookVO()
            {
                Id = origin.Id,
                Author = origin.Author,
                Price = origin.Price,
                Title = origin.Title,
                LaunchDate = origin.LaunchDate
            };
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            return origin?.Select(Parse).ToList();
        }
    }
}