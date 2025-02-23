using Microsoft.EntityFrameworkCore;
using movie_API.Data;
using movie_API.Models;

public class MovieRepository : IMovieRepository
{
    private readonly AppDbContext _context;

    public MovieRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetMovies() => await _context.Movies.ToListAsync();

    public async Task<Movie?> GetMovieById(int id)  // Alterado para permitir null
    {
        return await _context.Movies.FindAsync(id);
    }

    public async Task AddMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMovie(Movie movie)
    {
        _context.Entry(movie).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
