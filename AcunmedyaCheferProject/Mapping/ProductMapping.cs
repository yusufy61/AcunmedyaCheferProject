using AcunmedyaCheferProject.DTOs.ProductDTOs;
using AcunmedyaCheferProject.Entities;
using AutoMapper;

namespace AcunmedyaCheferProject.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product,CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
        }
    }
}
