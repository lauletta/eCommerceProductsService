using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RepositoryContracts;
public interface IProdcutRepository
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProductById(Guid id);
    Task<IEnumerable<Product>> GetProductBySearchString(string? searchString);
    Task<Product> AddProdduct(Product product);
    Task<Product> DeleteProduct(ProductDeleteRequest product);
    Task<Product> UpdateProduct (Product product); 
}
