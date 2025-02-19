using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer;
public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductServices>();
        services.AddValidatorsFromAssemblyContaining<AddProductRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateProductRequestValidator>();

        #region Mappers
        /*
        services.AddAutoMapper(typeof(ProductMapping).Assembly);
        services.AddAutoMapper(typeof(AddProductRequestMapping).Assembly);
        services.AddAutoMapper(typeof(UpdateProductRequestMapping).Assembly);
        services.AddAutoMapper(typeof(DeleteProductRequestMapping).Assembly);
        */
        #endregion
        return services;
    }
}
