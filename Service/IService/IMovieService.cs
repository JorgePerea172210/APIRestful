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
        Task<IEnumerable<MovieDto>> GetMoviesByCategory(int categoryId);
        Task<MovieDto> SearchMovie(string name);
        Task<Result<MovieDto>> GetMovie(int movieId);
        Task<Result<MovieDto>> CreateMovie(MovieInsertDto insert);
        Task<Result<string>> UpdateMovie(MovieUpdateDto update, int id);
        Task<Result<string>> DeleteMovie(int categoryId);
        Result<bool> Validate(MovieInsertDto dto);
        Result<bool> Validate(MovieUpdateDto dto, int id);
    }
}
