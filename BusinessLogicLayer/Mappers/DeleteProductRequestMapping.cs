using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;


namespace BusinessLogicLayer.Mappers;
public class DeleteProductRequestMapping : Profile
{

    public DeleteProductRequestMapping()
    {
        CreateMap<ProductDeleteRequest, Product>()
            .ForMember(dest => dest.ProductId, opt =>
            opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.ProductName, opt =>
            opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.Category, opt =>
            opt.Ignore())
            .ForMember(dest => dest.UnitPrice, opt =>
            opt.Ignore())
            .ForMember(dest => dest.QuantityInStock, opt =>
            opt.Ignore());
    }
}