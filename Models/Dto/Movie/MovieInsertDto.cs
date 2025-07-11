using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static APIRestful.Models.Movie;

namespace APIRestful.Models.Dto.AddMovieDto
{
    public record MovieInsertDto
    (
        string Name,
        string Description,
        int Last,
        string ImageURL,
        ClassificationType Classification,
        //Relation with Category table
        int CategoryId
    );
}
