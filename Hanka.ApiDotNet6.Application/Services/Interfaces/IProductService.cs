using Hanka.ApiDotNet6.Application.DTOs;

namespace Hanka.ApiDotNet6.Application.Services.Interfaces;

public interface IProductService
{
  Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO);
  Task<ResultService<ProductDTO>> GetByIdAsync(int id);
  Task<ResultService<ICollection<ProductDTO>>> GetAsync();
  Task<ResultService> UpdateAsync(ProductDTO productDTO);
  Task<ResultService> RemoveAsync(int id);
}

