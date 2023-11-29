using MovieData.Core;
using MovieData;
using MovieData.Tables;

namespace MovieApi.Core
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext context)
        {
            _context = context;
        }

        public List<tb_Movie> GetAllMovies()
        {
            return _context.tb_Movie.ToList();
        }

        public tb_Movie GetMovieById(int id)
        {
            return _context.tb_Movie.Find(id);
        }

        public tb_Movie AddMovie(tb_Movie movie)
        {
            _context.tb_Movie.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public void UpdateMovie(tb_Movie updatedMovie)
        {
            if (updatedMovie.Id > 0)
            {
                var movie = _context.tb_Movie.Find(updatedMovie.Id);
                if (movie == null)
                    return;

                movie.Title = updatedMovie.Title;
                movie.Year = updatedMovie.Year;

                _context.SaveChanges();
            }
        }

        public void DeleteMovie(int id)
        {
            if (id > 0)
            {
                var movie = _context.tb_Movie.Find(id);
                if (movie == null)
                    return;

                _context.tb_Movie.Remove(movie); //veri bütünlüğünü bozmamak adına, tablo yapısını ayarlayıp isDeleted gibi bir alanı güncellemek daha mantıklı olacaktır.
                _context.SaveChanges();
            }
        }
    }
}
