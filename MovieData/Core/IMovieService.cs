using MovieData.Tables;

namespace MovieData.Core
{
    public interface IMovieService
    {
        List<tb_Movie> GetAllMovies();
        tb_Movie GetMovieById(int id);
        tb_Movie AddMovie(tb_Movie movie);
        void UpdateMovie(tb_Movie updatedMovie);
        void DeleteMovie(int id);
    }
}
