using Microsoft.AspNet.Identity;
using PersonalLibrary.Models.GenreModels;
using PersonalLibrary.Services.GenreServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PersonalLibrary.WebAPI.Controllers.GenreController
{
    public class GenreController : ApiController
    {
        private GenreService CreateGenreService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GenreService(userId);
            return service;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(GenreCreate genre)
        {
            if (genre == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGenreService();
            var success = await service.CreateGenre(genre);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var service = CreateGenreService();
            var genres = await service.GetAllGenres();
            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            if (id < 1)
                return BadRequest();

            var service = CreateGenreService();
            var genre = await service.GetAllGenresById(id);
            return Ok(genre);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetByType(string genreType)
        {
            if (genreType == null)
                return BadRequest();

            var service = CreateGenreService();
            var genre = await service.GetAllGenresByGenreType(genreType);
            return Ok();
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(GenreEdit genre, int id)
        {
            if (id < 1 || id != genre.Id || genre == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGenreService();
            var success = await service.UpdateGenre(genre, id);
            if (success)
                return Ok();

            return InternalServerError();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteById(int id)
        {
            if (id < 1)
                return BadRequest();

            var service = CreateGenreService();
            var success = await service.DeleteGenreById(id);
            if (success)
                return Ok("The Genre was Deleted.");

            return InternalServerError();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteByType(string genreType)
        {
            if (genreType == null)
                return BadRequest();

            var service = CreateGenreService();
            var success = await service.DeleteGenreByGenreType(genreType);
            if (success)
                return Ok("The Genre was Deleted.");

            return InternalServerError();
        }
    }
}
