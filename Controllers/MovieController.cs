using APIRestful.Models.Dto.AddMovieDto;
using APIRestful.Models.Dto.Category;
using APIRestful.Models.Dto.Movie;
using APIRestful.Service;
using APIRestful.Service.IService;
using APIRestful.Utilities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRestful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private IValidator<MovieInsertDto> _insertValidator;
        private IValidator<MovieUpdateDto> _updateValidator;
        private IMapper _mapper;

        public MovieController(IMovieService movieService, IValidator<MovieInsertDto> insertValidator, IValidator<MovieUpdateDto> updateValidator, IMapper mapper)
        {
            _movieService = movieService;
            _insertValidator = insertValidator;
            _updateValidator = updateValidator;
            _mapper = mapper;
        }

        [HttpGet("GetMovies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<MovieDto>> GetMovies()
            => await _movieService.GetMovies();

        [HttpGet("GetMovieById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MovieDto>> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovie(id);

            //return category != null ? Ok(category) : NotFound();
            if (movie.IsSuccess)
            {
                return Ok(movie.Value);
            }
            return NotFound(movie.Error);
        }

        [HttpPost("AddMovie")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MovieDto>> CreateMovie(MovieInsertDto insert)
        {
            var validationsResult = await _insertValidator.ValidateAsync(insert);

            if (!validationsResult.IsValid)
            {
                return BadRequest(validationsResult.Errors);
            }

            var valresult = _movieService.Validate(insert);

            if (!valresult.IsSuccess)
            {
                return BadRequest(valresult.Error.Message);
            }

            var movieResult = await _movieService.CreateMovie(insert);

            if (!movieResult.IsSuccess)
            {
                return BadRequest(movieResult.Error.Message);
            }

            var movie = movieResult.Value;

            return CreatedAtAction("GetMovieById", new { id = movie.Id }, movie);
        }
    }
}
