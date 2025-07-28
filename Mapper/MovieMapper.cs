using APIRestful.Models;
using APIRestful.Models.Dto.AddMovieDto;
using APIRestful.Models.Dto.Movie;
using AutoMapper;

namespace APIRestful.Mapper
{
    public class MovieMapper : Profile
    {
        public MovieMapper()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, MovieInsertDto>().ReverseMap();
            CreateMap<MovieInsertDto, MovieDto>().ReverseMap();
            CreateMap<MovieUpdateDto, MovieDto>().ReverseMap();
        }
    }
}
