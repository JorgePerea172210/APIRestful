using APIRestful.Data;
using APIRestful.Mapper;
using APIRestful.Models;
using APIRestful.Models.Dto.Category;
using APIRestful.Repository.IRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIRestful.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Category insert)
            => await _context.Category.AddAsync(insert);

        public void Delete(Category delete)
            => _context.Category.Remove(delete);

        public async Task<IEnumerable<Category>> Get()
            => await _context.Category.OrderBy(c => c.Name).ToListAsync();

        public async Task<Category> GetById(int categoryId)
            => await _context.Category.FindAsync(categoryId);

        public async Task Save()
            => await _context.SaveChangesAsync();

        public IEnumerable<Category> Search(Func<Category, bool> filter)
            => _context.Category.Where(filter).ToList();

        public async Task Update(Category update)
        {
            _context.Category.Attach(update);
            _context.Entry(update).State = EntityState.Modified;
        }
    }
}
