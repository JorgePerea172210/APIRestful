using APIRestful.Models.Dto.Category;
using FluentValidation;

namespace APIRestful.Validators.CategoryValidators
{
    public class CategoryInsertValidator : AbstractValidator<CategoryInsertDto>
    {
        public CategoryInsertValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category name is required");
            RuleFor(x => x.Name).Length(2, 30).WithMessage("Category name lenght allowed is 2 to 30 characters");
        }
    }
}
