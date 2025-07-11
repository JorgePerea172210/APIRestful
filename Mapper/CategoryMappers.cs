using APIRestful.Models;
using APIRestful.Models.Dto.Category;
using AutoMapper;

namespace APIRestful.Mapper
{
    public class CategoryMappers : Profile
    {
        public CategoryMappers()
        {
            CreateMap<Category, CategoryInsertDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
        }
    }
}
