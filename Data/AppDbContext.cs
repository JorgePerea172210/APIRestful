using APIRestful.Models;
using Microsoft.EntityFrameworkCore;

namespace APIRestful.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Class
        public DbSet<Category> Category { get; set; }
        public DbSet<Movie> Movie { get; set; }

    }
}
