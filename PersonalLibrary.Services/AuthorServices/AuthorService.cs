using PersonalLibrary.Data;
using PersonalLibrary.Models.AuthorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Services.AuthorServices
{
    public class AuthorService
    {

        public bool CreateAuthor(AuthorCreate newAuthor)
        {
            var entity =
                new Author()
                {
                    AuthorId = newAuthor.AuthorId,
                    FirstName = newAuthor.FirstName,
                    LastName = newAuthor.LastName,
                    BirthDate = newAuthor.BirthDate,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Authors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AuthorListDetail> GetAuthors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Authors
                    .Select(a => new AuthorListDetail
                    {
                        AuthorId = a.AuthorId,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Books = a.Books
                    });
                return query.ToArray();
            }
        }
        public AuthorDetail GetAuthorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Authors.Single(a => a.AuthorId == id);
                return
                    new AuthorDetail
                    {
                        AuthorId = entity.AuthorId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        BirthDate = entity.BirthDate,
                        Books = entity.Books
                    };
            }
        }
        public bool UpdateAuthor(AuthorEdit author)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Authors.Single(a => a.AuthorId == author.AuthorId);
                entity.FirstName = author.FirstName;
                entity.LastName = author.LastName;
                entity.BirthDate = author.BirthDate;

                return ctx.SaveChanges() == 1;
                
            }
        }
        public bool DeleteAuthor(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Authors.Single(a => a.AuthorId == id);

                ctx.Authors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        
    }
}
