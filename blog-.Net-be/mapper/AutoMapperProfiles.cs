using AutoMapper;
using blog_.Net_be.dto;
using blog_.Net_be.Models;

namespace blog_.Net_be.mapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Blog,BlogDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
