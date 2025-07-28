using APIRestful.Models.Dto.AddMovieDto;
using APIRestful.Models.Dto.Category;
using APIRestful.Models.Dto.Movie;
using FluentValidation;

namespace APIRestful.Validators.MovieValidators
{
    public class MovieInsertValidator : AbstractValidator<MovieInsertDto>
    {
        public MovieInsertValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category name is required");
            RuleFor(x => x.Name).Length(2, 30).WithMessage("Category name lenght allowed is 2 to 30 characters");
        }
    }
}
