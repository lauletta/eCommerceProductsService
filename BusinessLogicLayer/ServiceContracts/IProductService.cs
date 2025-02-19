using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServiceContracts;
public interface IProductService
{
    Task<IEnumerable<ProductResponse>> GetProductsAsync();
    Task<ProductResponse> GetProductByid(Guid id);
    Task<IEnumerable<ProductResponse>> GetProductBySearchString(string? searchString);
    Task<ProductResponse> DeleteProduct(ProductDeleteRequest product);
    Task<ProductResponse> AddProductAsync(AddProductRequest addProductRequest);
    Task<ProductResponse> UpdateProductAsync(ProductUpdateRequest updateRequest);
}
