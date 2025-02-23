using movie_API.Models;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetMovies();
    Task<Movie?> GetMovieById(int id);
    Task AddMovie(Movie movie);
    Task UpdateMovie(Movie movie);
    Task DeleteMovie(int id);
}