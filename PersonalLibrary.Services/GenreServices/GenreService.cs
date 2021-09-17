using PersonalLibrary.Data;
using PersonalLibrary.Models.GenreModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Services.GenreServices
{
    public class GenreService
    {
        public async Task<bool> CreateGenre(GenreCreate genre)
        {
            var entity = new Genre
            { 
                GenreType = genre.GenreType
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Genres.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<IEnumerable<GenreListDetail>> GetAllGenres()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .Genres
                    .Select(g => new GenreListDetail
                    {
                        Id = g.Id,
                        GenreType = g.GenreType
                    }).ToListAsync();

                return query;
            }
        }

        public async Task<GenreDetail> GetAllGenresById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var genre =
                    await
                    ctx
                    .Genres
                    .SingleOrDefaultAsync(g => g.Id == id);
                if(genre == null)
                {
                    return null;
                }
                return new GenreDetail
                {
                    Id = genre.Id,
                    GenreType = genre.GenreType,
                    ListOfBooks = genre.ListOfBooks,
                };
            }
        }

        public async Task<GenreDetail> GetAllGenresByGenreType(string genreType)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var genre =
                    await
                    ctx
                    .Genres
                    .SingleOrDefaultAsync(g => g.GenreType == genreType);
                if(genre == null)
                {
                    return null;
                }
                return new GenreDetail
                {
                    Id = genre.Id,
                    GenreType = genre.GenreType,
                    ListOfBooks = genre.ListOfBooks,
                };
            }
        }

        public async Task<bool> UpdateGenre(GenreEdit genre, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldGenre = await ctx.Genres.FindAsync(id);
                if(oldGenre == null)
                {
                    return false;
                }
                oldGenre.GenreType = genre.GenreType;

                return await ctx.SaveChangesAsync() > 1;
            }
        }

        public async Task<bool> DeleteGenreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldGenre = await ctx.Genres.FindAsync(id);
                if (oldGenre == null)
                {
                    return false;
                }
                ctx.Genres.Remove(oldGenre);
                return await ctx.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> DeleteGenreByGenreType(string genreType)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldGenre = await ctx.Genres.FindAsync(genreType);
                if(oldGenre == null)
                {
                    return false;
                }
                ctx.Genres.Remove(oldGenre);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
