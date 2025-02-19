using BusinessLogicLayer.DTO;
using DataAccessLayer.ApplicationDbContext;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Repositories;
public class ProductsRepository : IProdcutRepository
{
    private readonly ProductDbContext _dbContext;

    public ProductsRepository(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Product?> AddProdduct(Product product)
    {
        if (product != null)
        {
            product.ProductId = Guid.NewGuid();
            product.ProductName = product.ProductName;
            product.Category = product.Category;
            product.UnitPrice = product.UnitPrice;
            product.QuantityInStock = product.QuantityInStock;

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }
        else
        {
            return null;
        }
    }

    public async Task<Product> DeleteProduct(ProductDeleteRequest product)
    {
        Product? productToDelete = await GetProductById(product.ProductId);

        _dbContext.Products.Remove(productToDelete);
        await _dbContext.SaveChangesAsync();

        return productToDelete;
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        Product? productToUpdate = await GetProductById(product.ProductId);

        productToUpdate.ProductId = product.ProductId;
        productToUpdate.ProductName = product.ProductName;
        productToUpdate.Category = product.Category;
        productToUpdate.UnitPrice = product.UnitPrice;
        productToUpdate.QuantityInStock= product.QuantityInStock;

        _dbContext.Update(productToUpdate);
        await _dbContext.SaveChangesAsync();

        return productToUpdate;
    }

    public async Task<Product> GetProductById(Guid id)
    {
        Product? product = _dbContext.Products.Where(prd => prd.ProductId == id).FirstOrDefault();

        if (product == null)
        {
            return null;
        }
        return product;
    }

    public async Task<IEnumerable<Product>> GetProductBySearchString(string? searchString)
    {
        IEnumerable<Product?> products = _dbContext.Products.Where(prd => prd.ProductName.Contains(searchString) || prd.Category.Contains(searchString));

        if (products == null)
        {
            return null;
        }

        return products;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        IEnumerable<Product> products = await _dbContext.Products.ToListAsync();

        return products;
    }
}
