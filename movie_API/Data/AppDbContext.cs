using Microsoft.EntityFrameworkCore;
using movie_API.Models;

namespace movie_API.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }

        public DbSet<Movie> Movies { get; set; }
    }
}