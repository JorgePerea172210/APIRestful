using APIRestful.Models;
using APIRestful.Models.Dto.Category;
using APIRestful.Utilities;

namespace APIRestful.Service.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<CategoryDto> GetCategory(int categoryId);
        Task<Result<Category>> CreateCategory(CategoryInsertDto insert);
        Task<Result<string>> UpdateCategory(CategoryUpdateDto update, int id);
        Task<Result<string>> DeleteCategory(int categoryId);
        Result<bool> Validate(CategoryInsertDto dto);
        Result<bool> Validate(CategoryUpdateDto dto, int id);
    }
}
