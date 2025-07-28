using APIRestful.Utilities.Abstractions;

namespace APIRestful.Utilities.Errors
{
    public class MovieErrors
    {
        public static Error InvalidMovieId => new("InvalidMovieId", "Does not exist a movie with this ID");
        public static Error MovieAlreadyExist => new("MovieAlreadyExist", "Movie with this name already exist");
    }
}
