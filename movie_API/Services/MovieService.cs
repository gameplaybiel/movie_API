using movie_API.Data;
using movie_API.Models;
using System.Linq;

namespace movie_API.Services
{
    public class MovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public Movie AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public IQueryable<Movie> GetAllMovies()
        {
            return _context.Movies;
        }

        public Movie? GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }

        public Movie UpdateMovie(int id, Movie updatedMovie)
        {
            var existingMovie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (existingMovie == null)
            {
                throw new InvalidOperationException("Movie not found.");
            }

            existingMovie.Title = updatedMovie.Title;
            existingMovie.Year = updatedMovie.Year;
            existingMovie.Director = updatedMovie.Director;
            existingMovie.Poster = updatedMovie.Poster;
            _context.SaveChanges();

            return existingMovie;
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new InvalidOperationException("Movie not found.");
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
