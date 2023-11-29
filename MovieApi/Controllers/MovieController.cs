using Microsoft.AspNetCore.Mvc;
using MovieData.Core;
using MovieData.Tables;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IEnumerable<tb_Movie> GetMovies()
        {
            return _movieService.GetAllMovies();
        }

        [HttpGet("{id}")]
        public tb_Movie GetMovieById(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
                return new tb_Movie();

            return movie;
        }

        [HttpPost]
        public tb_Movie AddMovie(tb_Movie movie)
        {
            var addedMovie = _movieService.AddMovie(movie);
            return addedMovie;
        }

        [HttpPut]
        public void UpdateMovie(tb_Movie updatedMovie)
        {
            _movieService.UpdateMovie(updatedMovie);
        }

        [HttpDelete("{id}")]
        public void DeleteMovie(int id)
        {
            _movieService.DeleteMovie(id);
        }
    }
}