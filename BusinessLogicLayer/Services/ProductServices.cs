using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services;
public class ProductServices : IProductService
{
    private readonly IProdcutRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductServices( IProdcutRepository prodcutRepository, IMapper mapper)
    {
        _productRepository = prodcutRepository;
        _mapper = mapper;
    }

    public async Task<ProductResponse> AddProductAsync(AddProductRequest addProductRequest)
    {
        Product product = _mapper.Map<Product>(addProductRequest);
        Product? productAdded = await _productRepository.AddProdduct(product);

        if (productAdded == null)
        {
            return null;
        }
        return _mapper.Map<ProductResponse>(productAdded);
    }

    public async Task<ProductResponse> DeleteProduct(ProductDeleteRequest product)
    {
        Product? productToDelete = await _productRepository.DeleteProduct(product);

        if (product == null)
        {
            return null;
        }

        return _mapper.Map<ProductResponse>(productToDelete);
    }

    public async Task<ProductResponse> GetProductByid(Guid id)
    {
        Product? product = await _productRepository.GetProductById(id);

        if (product == null)
        {
            return null;
        }
        return _mapper.Map<ProductResponse>(product);
    }

    public async Task<IEnumerable<ProductResponse>> GetProductBySearchString(string? searchString)
    {
        IEnumerable<Product?> products = await _productRepository.GetProductBySearchString(searchString);

        if (products.Count() == 0)
        {
            return null;
        }

        return _mapper.Map<IEnumerable<ProductResponse>>(products);
    }

    public async Task<IEnumerable<ProductResponse>> GetProductsAsync()
    {
        IEnumerable<Product?> products = await _productRepository.GetProducts();

        if (products == null)
        {
            return null;
        }

        return _mapper.Map<IEnumerable<ProductResponse>>(products);
    }

    public async Task<ProductResponse> UpdateProductAsync(ProductUpdateRequest updateRequest)
    {
        Product product = _mapper.Map<Product>(updateRequest);

        Product? productModified = await _productRepository.UpdateProduct(product);

        if (productModified == null)
        {
            return null;
        }
        return _mapper.Map<ProductResponse>(productModified);
    }
}
