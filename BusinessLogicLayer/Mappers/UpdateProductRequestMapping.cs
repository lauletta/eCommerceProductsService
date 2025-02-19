﻿using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mappers;
public class UpdateProductRequestMapping : Profile
{
    public UpdateProductRequestMapping()
    {
        CreateMap<ProductUpdateRequest, Product>()
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
