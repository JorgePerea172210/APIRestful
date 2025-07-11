using APIRestful.Utilities.Abstractions;

namespace APIRestful.Utilities.Errors
{
    public class CategoryErrors
    {
        public static Error InvalidCategoryId => new("InvalidCategoryId", "Does not exist a category with this ID");
        public static Error CategoryAlreadyExist => new("CategoryAlreadyExist", "Category with this name already exist");
    }
}
