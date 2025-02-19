using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using AutoMapper;

namespace BusinessLogicLayer.Mappers;
public class AddProductRequestMapping : Profile
{
    public AddProductRequestMapping()
    {
        CreateMap<AddProductRequest, Product>()
            .ForMember(dest => dest.ProductId, opt =>
            opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.ProductName, opt =>
            opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.Category, opt =>
            opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.UnitPrice, opt =>
            opt.MapFrom(src => src.UnitPrice))
            .ForMember(dest => dest.QuantityInStock, opt =>
            opt.MapFrom(src => src.QuantityInStock));
    }
}