using FluentValidation;
using APIRestful.Models.Dto.Category;

namespace APIRestful.Validators.CategoryValidators
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Movie name is required");
            RuleFor(x => x.Name).Length(2, 30).WithMessage("Movie name lenght allowed is 2 to 30 characters");
        }
    }
}
