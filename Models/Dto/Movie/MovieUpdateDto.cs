using static APIRestful.Models.Movie;

namespace APIRestful.Models.Dto.Movie
{
    public record MovieUpdateDto
    (
        string Name,
        string Description,
        int Last,
        string ImageURL,
        ClassificationType Classification,
        int CategoryId
    );
}
