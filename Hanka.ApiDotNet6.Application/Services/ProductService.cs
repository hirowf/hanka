using AutoMapper;
using Hanka.ApiDotNet6.Application.DTOs;
using Hanka.ApiDotNet6.Application.DTOs.Validations;
using Hanka.ApiDotNet6.Application.Services.Interfaces;
using Hanka.ApiDotNet6.Domain;
using Hanka.ApiDotNet6.Domain.Entities;

namespace Hanka.ApiDotNet6.Application.Services
{
  public class ProductService : IProductService
  {
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
      _productRepository = productRepository;
      _mapper = mapper;
    }

    public async Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO)
    {
      if (productDTO == null)
        return ResultService.Fail<ProductDTO>("Object must be informed");

      var result = new ProductDTOValidator().Validate(productDTO);
      if (!result.IsValid)
        return ResultService.RequestError<ProductDTO>("Problem with validation", result);

      var product = _mapper.Map<Product>(productDTO);
      var data = await _productRepository.CreateAsync(product);
      return ResultService.OK<ProductDTO>(_mapper.Map<ProductDTO>(data));
    }

    public async Task<ResultService> RemoveAsync(int id)
    {
      var product = await _productRepository.GetByIdAsync(id);
      if (product == null)
        return ResultService.Fail("Product not found");

      await _productRepository.DeleteAsync(product);
      return ResultService.OK($"Product with id: {id} was removed");
    }
    public async Task<ResultService<ICollection<ProductDTO>>> GetAsync()
    {
      var products = await _productRepository.GetProductsAsync();
      return ResultService.OK<ICollection<ProductDTO>>(_mapper.Map<ICollection<ProductDTO>>(products));

    }

    public async Task<ResultService<ProductDTO>> GetByIdAsync(int id)
    {
      var product = await _productRepository.GetByIdAsync(id);
      if (product == null)
        return ResultService.Fail<ProductDTO>("Product not found");

      return ResultService.OK<ProductDTO>(_mapper.Map<ProductDTO>(product));
    }

    public async Task<ResultService> UpdateAsync(ProductDTO productDTO)
    {
      if (productDTO == null)
        return ResultService.Fail("Object product must be informed");

      var validation = new ProductDTOValidator().Validate(productDTO);
      if (!validation.IsValid)
        return ResultService.RequestError("Validation problems", validation);

      var product = await _productRepository.GetByIdAsync(productDTO.id);
      if (product == null)
        return ResultService.Fail("Product not found");

      product = _mapper.Map<ProductDTO, Product>(productDTO, product);
      await _productRepository.EditAsync(product);
      return ResultService.OK($"Product wit id: {product.Id} updated");
    }
  }

}
