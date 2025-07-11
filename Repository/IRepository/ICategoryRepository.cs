using APIRestful.Models;
using APIRestful.Models.Dto.Category;

namespace APIRestful.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> Get();
        Task<Category> GetById(int categoryId);
        Task Add(Category insert);
        Task Update(Category update);
        void Delete(Category delete);
        Task Save();
        IEnumerable<Category> Search(Func<Category, bool> filter);
    }
}
