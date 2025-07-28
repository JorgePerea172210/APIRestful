using FluentValidation;
using APIRestful.Models.Dto.Movie;

namespace APIRestful.Validators.MovieValidators
{
    public class MovieUpdateValidator : AbstractValidator<MovieUpdateDto>
    {
        public MovieUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Movie name is required");
            RuleFor(x => x.Name).Length(2, 30).WithMessage("Movie name lenght allowed is 2 to 30 characters");
        }
    }
}
