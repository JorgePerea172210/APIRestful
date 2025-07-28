using APIRestful.Data;
using APIRestful.Models;
using APIRestful.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace APIRestful.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Movie insert)
            => await _context.Movie.AddAsync(insert);

        public void Delete(Movie delete)
            => _context.Movie.Remove(delete);

        public async Task<IEnumerable<Movie>> Get()
            => await _context.Movie.OrderBy(c => c.Name).ToListAsync();

        public async Task<IEnumerable<Movie>> GetByCategory(int categoryId)
            => await _context.Movie.Where(m => m.CategoryId == categoryId).ToListAsync();

        public async Task<Movie> GetById(int movieId)
            => await _context.Movie.FindAsync(movieId);

        public async Task Save()
            => await _context.SaveChangesAsync();

        public IEnumerable<Movie> Search(Func<Movie, bool> filter)
            => _context.Movie.Where(filter).ToList();

        public async Task<Movie> SearchMovie(string name)
            => await _context.Movie.Where(m => m.Name == name).FirstOrDefaultAsync();

        public async Task Update(Movie update)
        {
            _context.Movie.Attach(update);
            _context.Entry(update).State = EntityState.Modified;
        }
    }
}
