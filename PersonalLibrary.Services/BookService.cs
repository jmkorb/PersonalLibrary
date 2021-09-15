using PersonalLibrary.Data;
using PersonalLibrary.Models.BookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Services
{
    public class BookService
    {
        private readonly int _bookId;

        public BookService(int bookId)
        {
            _bookId = bookId;
        }

        public bool CreateBook(BookCreate model)
        {
            var entity =
                new Book()
                {
                    Id = _bookId,
                    Title = model.Title,
                    Summary = model.Summary,
                    DatePublished = model.DatePublished,
                    Author = model.Author,
                    Genre = model.Genre
                };
            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BookListDetail> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Books
                        .Where(b => b.Id == _bookId)
                        .Select(
                            b =>
                                new BookListDetail
                                {
                                    Id = b.Id,
                                    Title = b.Title,
                                    DatePublished = b.DatePublished,
                                    Author = b.Author,
                                    Genre = b.Genre
                                }
                        );
                return query.ToArray();                 
            }
        }
        public BookDetail GetBookById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Books
                    .Single(b => b.Id == id && b.Id == _bookId);
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Summary = entity.Summary,
                        BestSeller = entity.BestSeller,
                        DatePublished = entity.DatePublished,
                        Author = entity.Author,
                        Genre = entity.Genre
                    };
            }
        }

        public bool UpdateBook(BookEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Books
                    .Single(b => b.Id == model.Id && b.Id == _bookId);
                entity.Id = model.Id;
                entity.Title = model.Title;
                entity.Summary = model.Summary;
                entity.BestSeller = model.BestSeller;
                entity.DatePublished = model.DatePublished;
                entity.Author = model.Author;
                entity.Genre = model.Genre;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBook(int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Books
                    .Single(b => b.Id == bookId && b.Id == _bookId);
                ctx.Books.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }


    }
}
