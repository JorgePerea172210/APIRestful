using APIRestful.Data;
using APIRestful.Models;
using APIRestful.Models.Dto.AddMovieDto;
using APIRestful.Models.Dto.Category;
using APIRestful.Models.Dto.Movie;
using APIRestful.Repository.IRepository;
using APIRestful.Service.IService;
using APIRestful.Utilities;
using APIRestful.Utilities.Abstractions;
using APIRestful.Utilities.Errors;
using AutoMapper;


namespace APIRestful.Service
{
    public class MovieService : IMovieService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        private IMovieRepository _repository;

        public MovieService(AppDbContext context, IMapper mapper, IMovieRepository repository)
        {
            _context = context;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<MovieDto>> CreateMovie(MovieInsertDto insert)
        {
            try
            {
                var movie = _mapper.Map<Movie>(insert);

                await _repository.Add(movie);
                await _repository.Save();

                var film = _mapper.Map<MovieDto>(movie);

                return Result<MovieDto>.Success(film);
            }
            catch (Exception ex)
            {
                return Result<MovieDto>.Failure(new Error("ERROR.createMovie", $"Error while creating the movie: {ex.Message}"));
            }
            
        }

        public async Task<Result<string>> DeleteMovie(int categoryId)
        {
            var movie = await _repository.GetById(categoryId);

            if (movie != null)
            {
                _repository.Delete(movie);
                await _repository.Save();

                return Result<string>.Success("Movie deleted correctly");
            }
            return Result<string>.Failure(MovieErrors.InvalidMovieId);
        }

        public async Task<Result<MovieDto>> GetMovie(int movieId)
        {
            var movie = await _repository.GetById(movieId);

            if (movie != null)
            {
                var dto = _mapper.Map<MovieDto>(movie);
                return Result<MovieDto>.Success(dto);
            }
            return Result<MovieDto>.Failure(MovieErrors.InvalidMovieId);
        }

        public async Task<IEnumerable<MovieDto>> GetMovies()
        {
            var movies = await _repository.Get();
            var moviesDto = movies.Select(movie => _mapper.Map<MovieDto>(movie));
            return moviesDto;
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByCategory(int categoryId)
        {
            var movies = await _repository.GetByCategory(categoryId);
            var moviesDto = movies.Select(movie => _mapper.Map<MovieDto>(movie));
            return moviesDto;
        }

        public async Task<MovieDto> SearchMovie(string name)
        {
            var movie = await _repository.SearchMovie(name);
            var dto = _mapper.Map<MovieDto>(movie);
            return dto;
        }

        public Task<Result<string>> UpdateMovie(CategoryUpdateDto update, int id)
        {
            throw new NotImplementedException();
        }

        public Result<bool> Validate(CategoryInsertDto dto)
        {
            throw new NotImplementedException();
        }

        public Result<bool> Validate(CategoryUpdateDto dto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
