using Hanka.ApiDotNet6.Domain.Entities;

namespace Hanka.ApiDotNet6.Domain
{
  public interface IProductRepository
  {

    Task<Product> GetByIdAsync(int id);
    Task<ICollection<Product>> GetProductsAsync();
    Task<Product> CreateAsync(Product product);
    Task EditAsync(Product product);
    Task DeleteAsync(Product product);
    Task<int> GetIdByCodErpAsync(string codeErp);
  }
}
