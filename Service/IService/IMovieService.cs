using APIRestful.Models;
using APIRestful.Models.Dto.AddMovieDto;
using APIRestful.Models.Dto.Category;
using APIRestful.Models.Dto.Movie;
using APIRestful.Utilities;

namespace APIRestful.Service.IService
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetMovies();
        Task<MovieDto> GetMovie(int movieId);
        Task<Result<CategoryDto>> CreateMovie(MovieInsertDto insert);
        Task<Result<string>> UpdateMovie(CategoryUpdateDto update, int id);
        Task<Result<string>> DeleteCategory(int categoryId);
        Result<bool> Validate(CategoryInsertDto dto);
        Result<bool> Validate(CategoryUpdateDto dto, int id);
    }
}
