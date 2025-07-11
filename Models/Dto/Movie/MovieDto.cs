using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static APIRestful.Models.Movie;

namespace APIRestful.Models.Dto.Movie
{
    public record MovieDto
    (
        int Id,
        string Name,
        string Description,
        int Last,
        string ImageURL,
        ClassificationType Classification,
        DateTime CreatedAt,
        //Relation with Category table
        int CategoryId
    );
}
