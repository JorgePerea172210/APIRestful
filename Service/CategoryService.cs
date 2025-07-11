using APIRestful.Models;
using APIRestful.Models.Dto.Category;
using APIRestful.Repository.IRepository;
using APIRestful.Service.IService;
using APIRestful.Utilities;
using APIRestful.Utilities.Errors;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace APIRestful.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private IMapper _mapper;

        public CategoryService(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<Category>> CreateCategory(CategoryInsertDto insert)
        {
            var category = _mapper.Map<Category>(insert);

            await _repository.Add(category);
            await _repository.Save();

            return Result<Category>.Success(category);
        }

        public async Task<CategoryDto> GetCategory(int categoryId)
        {
            var category = await _repository.GetById(categoryId);

            if (category != null)
            {
                var categoryDto = _mapper.Map<CategoryDto>(category);
                return categoryDto;
            }

            return null;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = await _repository.Get();
            var categorieDtos = categories.Select(category => _mapper.Map<CategoryDto>(category));
            return categorieDtos;
        }

        public async Task<Result<string>> DeleteCategory(int categoryId)
        {
            var category = await _repository.GetById(categoryId);

            if (category != null)
            {
                _repository.Delete(category);
                await _repository.Save();

                return Result<string>.Success("Category deleted correctly");
            }
            return Result<string>.Failure(CategoryErrors.InvalidCategoryId);
        }

        public async Task<Result<string>> UpdateCategory(CategoryUpdateDto update, int id)
        {
            var category = await _repository.GetById(id);

            if (category != null)
            {
                category.UpdatedAt = DateTime.Now;
                category = _mapper.Map<CategoryUpdateDto, Category>(update, category);

                _repository.Update(category);
                await _repository.Save();

                return Result<string>.Success("Category updated correctly");
            }
            return Result<string>.Failure(CategoryErrors.InvalidCategoryId);
        }

        public Result<bool> Validate(CategoryInsertDto dto)
        {
            if (_repository.Search( c => c.Name == dto.Name ).Count() > 0)
            {
                return Result<bool>.Failure(CategoryErrors.CategoryAlreadyExist);
            }
            return Result<bool>.Success(true);
        }

        public Result<bool> Validate(CategoryUpdateDto dto, int id)
        {
            if (_repository.Search(c => c.Name == dto.Name && id != c.Id).Count() > 0)
            {
                return Result<bool>.Failure(CategoryErrors.CategoryAlreadyExist);
            }
            return Result<bool>.Success(true);
        }
    }
}
