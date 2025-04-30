using AcunmedyaCheferProject.DTOs.CategoryDTOs;
using AcunmedyaCheferProject.Entities;
using AutoMapper;

namespace Chefer.API.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
        }
    }
}
